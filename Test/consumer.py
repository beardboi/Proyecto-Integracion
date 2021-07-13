import pika, sys, os
from pika.exchange_type import ExchangeType

def main():
    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    
    channel = connection.channel()
    channel.exchange_declare(
        exchange="mantencion", 
        exchange_type=ExchangeType.direct, durable=True)

    result = channel.queue_declare(queue='bodega', durable=True)
    queue_name = result.method.queue
    channel.queue_bind(
        exchange='mantencion', 
        queue=queue_name)

    print('[*] Waiting for logs. To exit press CTRL+C')

    def callback(ch, method, properties, body):
        print(" [x] %r" % body)

    channel.basic_consume(
        queue=queue_name, 
        on_message_callback=callback, auto_ack=True)

    channel.start_consuming()

if __name__ == '__main__':
    try:
        main()
    except KeyboardInterrupt:
        print('Interrupted')
        try:
            sys.exit(0)
        except SystemExit:
            os._exit(0)
