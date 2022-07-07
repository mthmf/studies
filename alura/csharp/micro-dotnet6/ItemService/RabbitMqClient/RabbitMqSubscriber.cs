using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ItemService.RabbitMqClient
{
    public class RabbitMqSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly string _nomeFila;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IProcessaEvento _processaEvento;

        public RabbitMqSubscriber(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitHost"],
                Port = Int32.Parse(_configuration["RabbitHost"])
            }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _nomeFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeFila, exchange: "trigger", routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumidor = new EventingBasicConsumer(_channel);
            consumidor.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var mensagem = Encoding.UTF8.GetString(body.ToArray());
                _processaEvento.Processa(mensagem)
            };
        }
    }
}
