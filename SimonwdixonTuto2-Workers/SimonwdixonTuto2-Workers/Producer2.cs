using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace SimonwdixonTuto2_Workers
{
    
    class Producer2 : IDisposable
    {
        protected IModel Model;
        protected IConnection Connection;
        protected string QueueName;
        protected ConnectionFactory connectionFactory;

        public Producer2()
        {

                QueueName = "workQueues"; // Program.myConf.queueName;
                connectionFactory = new ConnectionFactory();
                connectionFactory.UserName = "guest"; //= Program.myConf.userMsg;
                                                      
                connectionFactory.Password = "guest"; //Program.myConf.passMsg;
                
                connectionFactory.Port = 5672;
                connectionFactory.VirtualHost = "/";

                connectionFactory.HostName = "localhost"; // Program.myConf.serverMsg;

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

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();

            if (Model != null)
                Model.Abort();

            if (connectionFactory != null)
                connectionFactory = null;
        }
        
    }

}
