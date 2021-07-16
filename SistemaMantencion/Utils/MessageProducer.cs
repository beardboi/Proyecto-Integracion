using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System;
using SistemaMantencion.Data.Entities;

namespace SistemaMantencion.Utils
{
    public static class MessageProducer
    {
        // Funcion para
        public static void PublicarMensajeBodega(MantencionMaterial mantencion, DateTime fecha)
        {
            // Configuracion de la conexion
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            // Declarar la conexion, el canal y el exchange.
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(
                exchange: "mantencion",
                ExchangeType.Direct,
                durable: true);

            // Crear la estructura del mensaje.
            var message = new
            {
                FechaMantencion = fecha,
                Material = mantencion.Material.Nombre, // Epa
                Cantidad = mantencion.Cantidad
            };

            // Serializar el mensaje para luego publicarlo en la cola.
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            try 
            {
                channel.BasicPublish("mantencion", "bodega", basicProperties: null, body);
            }
            catch
            {
                // 
            }
            connection.Close();
        }

        // Funcion estatica para enviar mensajes al sistema de RRHH
        public static void PublicarMensajeRRHH(MantencionTecnico mantencion, DateTime fecha)
        {
            // Configuracion de la conexion
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            // Declarar la conexion, el canal y el exchange.
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(
                exchange: "mantencion",
                ExchangeType.Direct,
                durable: true);

            // Crear la estructura del mensaje.
            var message = new
            {
                FechaMantencion = fecha,
                RutTecnico = mantencion.TecnicoRut,
                HorasTrabajadas = mantencion.Horas
            };

            // Serializar el mensaje para luego publicarlo en la cola.
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            try 
            {
                // Publicar mensaje
                channel.BasicPublish("mantencion", "rrhh", basicProperties: null, body);
            } 
            catch 
            {
                System.Diagnostics.Debug.WriteLine("No pasa nada");
            }
        }
    }
}