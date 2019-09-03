using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonwdixonTuto2_Workers
{
    class Producer : IDisposable
    {

        protected IModel Model;
        protected IConnection Connection;
        protected string QueueName;

        public Producer(string hostName, string queueName)
        {
            QueueName = queueName;
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            Connection = connectionFactory.CreateConnection();
            Model = Connection.CreateModel();
            bool durable = true;
            Model.QueueDeclare(QueueName, durable, false, false, null);
        }

        public void SendMessage(byte[] message)
        {
            IBasicProperties basicProperties = Model.CreateBasicProperties();
            basicProperties.SetPersistent(true);
            Model.BasicPublish("", QueueName, basicProperties, message);
        }

        public void SendMessageTTL(byte[] message)
        {
            IBasicProperties basicProperties = Model.CreateBasicProperties();
            basicProperties.Expiration = "60000";
            basicProperties.SetPersistent(true);
            Model.BasicPublish("", QueueName, basicProperties, message);
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
            if (Model != null)
                Model.Abort();
        }

    }
}
