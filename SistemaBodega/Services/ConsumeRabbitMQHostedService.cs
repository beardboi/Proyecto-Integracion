using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SistemaBodega.Data;
using System.Linq;
using Newtonsoft.Json;
using SistemaBodega.Data.Entities;
using System.Text;

namespace SistemaBodega.Services
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

            _channel.QueueDeclare(queue: "bodega",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);            

            _channel.QueueBind(
                queue: "bodega",
                exchange: "mantencion",
                routingKey: "bodega"
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

                    Material material = context.Materiales.FirstOrDefault(p => p.Nombre.ToLower() == message.Material.ToLower());

                    if (material == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Persona is null, doesnt exist in the database");
                        return;
                    }

                    MovimientoMaterial movimiento = new MovimientoMaterial();
                    movimiento.Cantidad = message.Cantidad;
                    movimiento.Fecha = message.FechaMantencion;
                    movimiento.Material = material;
                    movimiento.IdMaterial = material.Id;
                    System.Diagnostics.Debug.WriteLine("Insertando en la db");
                    context.Movimientos_Materiales.Add(movimiento);

                    // Actualizar el stock, no puede ser menor a 0
                    if (material.Stock - message.Cantidad > 0) 
                    {
                        // Restar el material utilizado
                        material.Stock = (material.Stock - message.Cantidad);
                        await context.SaveChangesAsync();
                    }
                    else if (material.Stock - message.Cantidad < 0)
                    {
                        /* 
                            Si la cantidad utilizada a registrar no es correcta, puesto que deja el stock en cifras negativas
                            el sistema de bodega deberia mandar un mensaje devuelta al sistema de mantencion, pero este sistema 
                            solo figura como consumidor y no como productor. Asi que para efectos practicos se dejara en negativo
                            pero se enviara un mensaje de advertencia a la consola.
                        */
                        material.Stock = (material.Stock - message.Cantidad);
                        await context.SaveChangesAsync();
                        System.Diagnostics.Debug.WriteLine("Advertencia: cantidad no valida");
                    }

                    await context.SaveChangesAsync();
                }
            };

            System.Diagnostics.Debug.WriteLine("Tarea completada");
            _channel.BasicConsume(queue: "bodega", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

    }
}