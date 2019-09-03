using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RabbitMQ.Client;
using Newtonsoft.Json;

namespace SimonwdixonTuto2_Workers
{
    class ProducerToEx
    {
        protected IModel channel;
        protected IConnection Connection;
        protected string QueueName;
        protected ConnectionFactory connectionFactory;

        public ProducerToEx()
        {

            QueueName = "workQueues"; // Program.myConf.queueName;
     
            connectionFactory = new ConnectionFactory();
            
            connectionFactory.UserName = "guest"; //= Program.myConf.userMsg;
                                                  
            connectionFactory.Password = "guest"; //Program.myConf.passMsg;
            
            connectionFactory.Port = 5672;
            connectionFactory.VirtualHost = "/";

            connectionFactory.HostName = "localhost"; // Program.myConf.serverMsg;

            Connection = connectionFactory.CreateConnection();

            channel = Connection.CreateModel();
            bool durable = true;
            channel.QueueDeclare(QueueName, durable, false, false, null);
            
        }
        

        public void SendMessage(byte[] message)
        {
            IBasicProperties basicProperties = channel.CreateBasicProperties();
            basicProperties.SetPersistent(true);
            channel.BasicPublish("", QueueName, basicProperties, message);
        }


        public void SendMessageToEx(byte[] message, string ex, string key)
        {
            IBasicProperties basicProperties = channel.CreateBasicProperties();
            basicProperties.SetPersistent(true);
            
            channel.BasicPublish(exchange: ex,
                                 routingKey: key,
                                 basicProperties: null,
                                 body: message);
            
            Console.WriteLine(" [x] Sent {0}", message);
            
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();

            if (channel != null)
                channel.Abort();

            if (connectionFactory != null)
                connectionFactory = null;
        }
        

    }
}
