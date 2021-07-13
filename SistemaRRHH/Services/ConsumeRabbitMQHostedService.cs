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

namespace SistemaRRHH.Services
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private readonly DataContext _context;
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

            string queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(
                queue: queueName,
                exchange: "mantencion",
                routingKey: "rrhh"
            );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested) 
            {
                await ConsumeMessage();
            }
            await Task.CompletedTask;
        }

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

                    Persona persona = context.Personas.FirstOrDefault(p => p.Rut == message.Rut);

                    if (persona == null) 
                    {
                        System.Diagnostics.Debug.WriteLine("Persona is null, doesnt exist in the database");
                        return;
                    }

                    HorasTrabajadas horasTrabajadas = new HorasTrabajadas();
                    horasTrabajadas.Horas = message.Horas;
                    horasTrabajadas.IdPersona = persona.Id;
                    horasTrabajadas.Persona = persona;
                    horasTrabajadas.Fecha = message.Fecha;

                    context.HorasTrabajadas.Add(horasTrabajadas);
                    await context.SaveChangesAsync();
                }
            };

            return Task.CompletedTask;
        }
    }

    public class Message {
        public DateTime Fecha { get; set; }
        public string Rut { get; set; }
        public int Horas { get; set; }
    }
}