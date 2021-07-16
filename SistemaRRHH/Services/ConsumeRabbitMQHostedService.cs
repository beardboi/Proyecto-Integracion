using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SistemaRRHH.Data;
using System.Linq;
using Newtonsoft.Json;
using SistemaRRHH.Data.Entities;
using System.Text;

namespace SistemaRRHH.Services
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private IConnection _connection;  
        private IModel _channel;
        private IServiceProvider _serviceProvider;

        public ConsumeRabbitMQHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(
                exchange: "mantencion",
                ExchangeType.Direct,
                durable: true);

            _channel.QueueDeclare(queue: "rrhh",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            _channel.QueueBind(
                queue: "rrhh",
                exchange: "mantencion",
                routingKey: "rrhh"
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var content = Encoding.UTF8.GetString(body);
                Message message = JsonConvert.DeserializeObject<Message>(content);
                System.Diagnostics.Debug.WriteLine(message);

                using (var scope = _serviceProvider.CreateScope())
                {
                    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

                    Persona persona = context.Personas.FirstOrDefault(p => p.Rut == message.RutTecnico);

                    if (persona == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Persona is null, doesnt exist in the database");
                        return;
                    }

                    HorasTrabajadas horasTrabajadas = new HorasTrabajadas();
                    horasTrabajadas.Horas = message.HorasTrabajadas;
                    horasTrabajadas.IdPersona = persona.Id;
                    horasTrabajadas.Persona = persona;
                    horasTrabajadas.Fecha = message.FechaMantencion;

                    // Actualizar el stock

                    System.Diagnostics.Debug.WriteLine("Insertando en la db");
                    context.HorasTrabajadas.Add(horasTrabajadas);
                    await context.SaveChangesAsync();
                }
            };

            System.Diagnostics.Debug.WriteLine("Tarea completada");
            _channel.BasicConsume(queue: "rrhh", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        // 
        private Task ConsumeMessage()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                // Mensaje recibido
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                System.Diagnostics.Debug.WriteLine(content);
                Message message = JsonConvert.DeserializeObject<Message>(content);
                System.Diagnostics.Debug.WriteLine(message);

                using (var scope = _serviceProvider.CreateScope())
                {
                    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

                    Persona persona = context.Personas.FirstOrDefault(p => p.Rut == message.RutTecnico);

                    if (persona == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Persona is null, doesnt exist in the database");
                        return;
                    }

                    HorasTrabajadas horasTrabajadas = new HorasTrabajadas();
                    horasTrabajadas.Horas = message.HorasTrabajadas;
                    horasTrabajadas.IdPersona = persona.Id;
                    horasTrabajadas.Persona = persona;
                    horasTrabajadas.Fecha = message.FechaMantencion;

                    context.HorasTrabajadas.Add(horasTrabajadas);
                    await context.SaveChangesAsync();
                }
            };

            _channel.BasicConsume(queue: "rrhh",
                                    autoAck: true,
                                    consumer: consumer);
            return Task.CompletedTask;
        }
    }
}