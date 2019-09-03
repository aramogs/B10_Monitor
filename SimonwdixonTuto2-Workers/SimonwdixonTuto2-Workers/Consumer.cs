using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using SimonwdixonTuto2_Workers.arribo;
using SimonwdixonTuto2_Workers.mysql;
using SimonwdixonTuto2_Workers.Util;
using SimonwdixonTuto2_Workers.ws;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonwdixonTuto2_Workers
{
    class Consumer
    {

        private ProducerToEx prodToEx = new ProducerToEx();
        
        protected IModel Model;
        protected IConnection Connection;
        protected string QueueName;

        ConnectionFactory connectionFactory;

        public bool isConsuming;
        
        public delegate void onReceiveMessage(byte[] message);
        public event         onReceiveMessage onMessageReceived;

        public delegate void onReceiveMessage2(byte[] message,bool error);
        public event onReceiveMessage2 onMessageReceived2;

        public Consumer(string hostName, string queueName)
        {
            QueueName = queueName;
            connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            Connection = connectionFactory.CreateConnection();
            Model = Connection.CreateModel();
            Model.BasicQos(0, 1, false);
            bool durable = true;
        
        }

        private delegate void ConsumeDelegate();

        public void StartConsuming()
        {
            try
            {
                isConsuming = true;
                ConsumeDelegate c = new ConsumeDelegate(Consume);
                c.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        
        public static void getSAPSession()
        {
            
            Console.WriteLine("-------------- Session ------------- " );

            Form1.jobeDone = true;

            Process proc = new Process();
            proc.StartInfo.FileName = @"cscript";
        
            proc.StartInfo.Arguments = " Session.vbs ";
            proc.StartInfo.CreateNoWindow = true; //-
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var errors = new StringBuilder();
            var output = new StringBuilder();
            var hadErrors = false;

            // raise events
            proc.EnableRaisingEvents = true;

            // capture normal output
            proc.OutputDataReceived += (s, d) => {
                output.Append(d.Data);
            };

            // Capture error output
            proc.ErrorDataReceived += (s, d) => {
                if (!hadErrors)
                {
                    hadErrors = !String.IsNullOrEmpty(d.Data);
                }
                errors.Append(d.Data);
            };

            proc.Start();
            // start listening on the stream
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            
            proc.WaitForExit();
            
            string stdout = output.ToString();
            string stderr = errors.ToString();

            if (proc.ExitCode != 0 || hadErrors)
            {
            
                Console.WriteLine("stdout");
                Console.WriteLine(stdout);

                Console.WriteLine("stderr");
                Console.WriteLine(stderr);

                
            }
            
        }


        public string getSAPValiAlmacen(Parte m, string vali, string planta)
        {
            Form1.jobeDone = true;
            string error = "";
            Process proc = new Process();
            proc.StartInfo.FileName = @"cscript";
            string qParams = vali; //////sap + " " + canti + " " + impre;
            proc.StartInfo.Arguments = " mfhu.vbs " + qParams + " " + planta;
            //proc.StartInfo.Arguments = " tet.vbs "; //+ qParams + " " + planta;
            proc.StartInfo.CreateNoWindow = true; //-
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //store outcome of process
            var errors = new StringBuilder();
            var output = new StringBuilder();
            var hadErrors = false;

            // raise events
            proc.EnableRaisingEvents = true;

            // capture normal output
            proc.OutputDataReceived += (s, d) => {
                output.Append(d.Data);
            };

            // Capture error output
            proc.ErrorDataReceived += (s, d) => {
                if (!hadErrors)
                {
                    hadErrors = !String.IsNullOrEmpty(d.Data);
                }
                errors.Append(d.Data);
            };

            proc.Start();

            // start listening on the stream
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            
            proc.WaitForExit();
            
            string stdout = output.ToString();
            string stderr = errors.ToString();

            error = stderr;
            if (proc.ExitCode != 0 || hadErrors)
            {
            
                Console.WriteLine("stdout");
                Console.WriteLine(stdout);

                Console.WriteLine("stderr");
                Console.WriteLine(stderr);
                

            }
            return error;


        }

      
        public string getErrorSAPConnection(Parte m, string sap, int canti, string impre, string station, string empresa,bool printNum)
        {
            Form1.jobeDone = true;
            string error = null;
            Process proc = new Process();
            proc.StartInfo.FileName = @"cscript";
            string qParams = sap + " " + canti + " " + empresa + " " + impre;

         

            if (m.bartender)
            {
                proc.StartInfo.Arguments = "zzmfp11-z_uc.vbs " + qParams;
            }
            else
            {
                proc.StartInfo.Arguments = "zzmfp11-z_uc_del.vbs " + qParams;

            }

            proc.StartInfo.CreateNoWindow = true; //-
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var errors = new StringBuilder();
            var output = new StringBuilder();
            var hadErrors = false;

            // raise events
            proc.EnableRaisingEvents = true;

            // capture normal output
            proc.OutputDataReceived += (s, d) => {
                output.Append(d.Data);
            };

            // Capture error output
            proc.ErrorDataReceived += (s, d) => {
                if (!hadErrors)
                {
                    hadErrors = !String.IsNullOrEmpty(d.Data);
                }
                errors.Append(d.Data);
            };

            proc.Start();
            // start listening on the stream
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
         
            proc.WaitForExit();
         
            string stdout = output.ToString();
            string stderr = errors.ToString();

            

            int i = stdout.IndexOf("-.") + 2;
            int ii = stdout.Length - i;

            Console.WriteLine("" + stdout.Length);
            string resu = stdout.Substring(i, ii - 2);

            error = stdout.Substring(114) + " " + stderr;

            if (resu != "")
            {
         
                Console.WriteLine("stdout");
                Console.WriteLine(stdout);

                Console.WriteLine("stderr");
                Console.WriteLine(stderr);



                //--------------------------
                AccVslidacion v = new AccVslidacion();
                v.noValidacion = resu;
                string cadeV = "";
                cadeV = JsonConvert.SerializeObject(v);
                Console.WriteLine(cadeV);


                Accion a = new Accion();
                string cade = "";
                a.titulo = "Validacion";
                a.dato = cadeV;
                cade = JsonConvert.SerializeObject(a);
                Console.WriteLine(cade);
                
                
                if (m.bartender)
                    LabelsB10.getInstance().send(m.nSAP, resu, m.impresoraBartender,m.dataBase,m.subline);

                 
                else {

                    Thread hs = null;
                    hs = new Thread(() =>  SAPImpre( m.impresora ));
                    hs.Start();
                    hs.Join();
                }

                if (!printNum)
                    prodToEx.SendMessageToEx(System.Text.Encoding.UTF8.GetBytes(cade), "stations", "s" + station);
                
                //---------------------------



                
            }
            else {
                MessageBox.Show("Vacio" , "Numero " + resu);
            }
            return error;
        }



        public string getErrorSAPConnectionG2X(Parte m, string sap, int canti, string impre, string station, string empresa, string param1, string param2)
        {
            string error = null;
            Console.WriteLine("-------------- Impresora: ------------- " + impre);

            Form1.jobeDone = true;

            Process proc = new Process();
            proc.StartInfo.FileName = @"cscript";
            string qParams = sap + " " + canti + " " + empresa  + " " + impre;

            
            if (m.bartender)
            {
                proc.StartInfo.Arguments = "zzmfp11-z_uc.vbs " + qParams;
                
            }
            else
            {
                
                proc.StartInfo.Arguments = " G2X.vbs " + qParams;

            }

            proc.StartInfo.CreateNoWindow = true; 
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //store outcome of process
            var errors = new StringBuilder();
            var output = new StringBuilder();
            var hadErrors = false;

            // raise events
            proc.EnableRaisingEvents = true;

            // capture normal output
            proc.OutputDataReceived += (s, d) => {
                output.Append(d.Data);
            };

            // Capture error output
            proc.ErrorDataReceived += (s, d) => {
                if (!hadErrors)
                {
                    hadErrors = !String.IsNullOrEmpty(d.Data);
                }
                errors.Append(d.Data);
            };

            proc.Start();
            // start listening on the stream
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            
            proc.WaitForExit();
            
            string stdout = output.ToString();
            string stderr = errors.ToString();



            int i = stdout.IndexOf("-.") + 2;
            int ii = stdout.Length - i;

            Console.WriteLine("" + stdout.Length);
            string resu = stdout.Substring(i, ii - 2);

            error = stdout.Substring(114) + " " + stderr;

            if (resu != "")
            {
            
                Console.WriteLine("stdout");
                Console.WriteLine(stdout);

                Console.WriteLine("stderr");
                Console.WriteLine(stderr);


                
                //--------------------------
                AccVslidacion v = new AccVslidacion();
                v.noValidacion = resu;
                string cadeV = "";
                cadeV = JsonConvert.SerializeObject(v);
                Console.WriteLine(cadeV);


                Accion a = new Accion();
                string cade = "";
                a.titulo = "Validacion";
                a.dato = cadeV;
                cade = JsonConvert.SerializeObject(a);
                Console.WriteLine(cade);

                
                if (m.bartender)
                    LabelsB10.getInstance().send(m.nSAP, resu, m.impresoraBartender,m.dataBase,m.subline);

                
                prodToEx.SendMessageToEx(System.Text.Encoding.UTF8.GetBytes(cade), "stations", "s" + station);
                
                //---------------------------

            
            }

            return error;
            
        }




        public void SAPImpre( string impre )
        {
            
            Console.WriteLine("-------------- Impresora: ------------- " + impre);

            Form1.jobeDone = true;

            Process proc = new Process();
            proc.StartInfo.FileName = @"cscript";
            string qParams = " " + impre;

            proc.StartInfo.Arguments = "Z_UC_DELL.vbs " + qParams;
            proc.StartInfo.CreateNoWindow = true; //-
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //store outcome of process
            var errors = new StringBuilder();
            var output = new StringBuilder();
            var hadErrors = false;

            // raise events
            proc.EnableRaisingEvents = true;

            // capture normal output
            proc.OutputDataReceived += (s, d) => {
                output.Append(d.Data);
            };

            // Capture error output
            proc.ErrorDataReceived += (s, d) => {
                if (!hadErrors)
                {
                    hadErrors = !String.IsNullOrEmpty(d.Data);
                }
                errors.Append(d.Data);
            };

            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            
            proc.WaitForExit();
            
            string stdout = output.ToString();
            string stderr = errors.ToString();

            
        }


        RabbitMQ.Client.Events.BasicDeliverEventArgs e;
        QueueingBasicConsumer consumer;

        public void Consume()
        {
            string err = null;
            consumer = new QueueingBasicConsumer(Model);
            bool autoAck = false;
            String consumerTag = Model.BasicConsume(QueueName, autoAck, consumer);
            while (isConsuming)
            {
                try
                {

                    if (consumer != null)
                    {
                        
                        e =
                            (RabbitMQ.Client.Events.BasicDeliverEventArgs)
                                consumer.Queue.Dequeue();

                                

                        IBasicProperties props = e.BasicProperties;
                        byte[] body = e.Body;
                        
                        string cade = System.Text.Encoding.UTF8.GetString(body);
                        Console.WriteLine("cade: " + cade);

                        Parte m = new Parte();

                        try {

                            m = JsonConvert.DeserializeObject<Parte>(
                            System.Text.Encoding.UTF8.GetString(body));

                            Console.WriteLine("--- SAP ---> " + m.nSAP);
                            onMessageReceived(body);

                        }
                        catch (Exception e) {
                            Console.WriteLine("Error: en combertir el JSON");

                        }




                        // ---------------- se lanza hilo -------------------

                        

                        Thread hs = null;
                        if (m == null)
                            return;
                        if (m.nSAP == "" && m.nVali == "") {
                            hs = new Thread(() => getSAPSession());
                        }


                        if (m.nVali != "")
                        {

                            hs = new Thread(() => { err = getSAPValiAlmacen(m, m.nVali, m.empresa); });

                            if (m.nVali != null && !string.IsNullOrEmpty(m.nVali))
                            {
                                hs.Start();
                                hs.Join();
                            }

                            if (!string.IsNullOrEmpty(err) && err != " ")
                            {
                                byte[] bytes = Encoding.ASCII.GetBytes(err);
                                onMessageReceived2(bytes, true);
                            }
                            else
                            {
                                byte[] bytes = Encoding.ASCII.GetBytes(" Vali:" + m.nVali + " Station:" + m.estacion);
                                onMessageReceived2(bytes, false);
                            }
                        
                        }

                        if (m.nVali == "" && m.nSAP != ""  ) // ver por nVali
                        {
                            if (m.nSAP != null)
                            {

                                /* validacion script G2X */

                                if (m.plat != "G2X")
                                    hs = new Thread(() => {
                                        err = getErrorSAPConnection(m, m.nSAP.Substring(1, m.nSAP.Length - 1), m.pckd,
                                                m.impresora, m.estacion, m.empresa,m.PrintNumb);
                                    });

                                else
                                    hs = new Thread(() =>
                                    {
                                      err = getErrorSAPConnectionG2X(m,
                                        m.nSAP.Substring(1, m.nSAP.Length - 1), m.pckd, m.impresora, m.estacion, m.empresa,
                                        m.cust, m.plat);
                                    });
                                if (m.nSAP != null && !string.IsNullOrEmpty(m.nSAP))
                                {
                                    hs.Start();
                                    hs.Join();
                                }
                                if (!string.IsNullOrEmpty(err) && err != " ")
                                {
                                    byte[] bytes = Encoding.ASCII.GetBytes(err);
                                    onMessageReceived2(bytes, true);
                                }
                                else
                                {
                                    byte[] bytes = Encoding.ASCII.GetBytes(" NSap:" + m.nSAP + " Station:" + m.estacion);
                                    onMessageReceived2(bytes, false);
                                }
                            }
                            
                        }
                       
                       
                        Console.WriteLine("fin it consume");
                        Console.WriteLine(err);
                        //Console.WriteLine(erro);
                        //---------------------------------------------------


                        if ( Form1.jobeDone )
                        {
                            onMessageReceived(body);
                            Model.BasicAck(e.DeliveryTag, false);
                        }
                        else
                        {
                            Console.WriteLine("Error in job");
                            Console.WriteLine("Dispouse Consumer");
                            Dispose();
                        }
                    }

                }
                catch (OperationInterruptedException ex)
                {
                    // The consumer was removed, either through
                    // channel or connection closure, or through the
                    // action of IModel.BasicCancel().
                    throw ex;
                    //break;
                }
            }

        }

        
        public void Dispose()
        {
            isConsuming = false;


            if (consumer != null) {
                consumer = null;
            }

            if (Connection.IsOpen)
                Connection.Close();

            if (Model != null)
                Model.Abort();

            if (connectionFactory != null)
                connectionFactory = null;

            if (Connection != null)
                Connection.Abort();

            if (e != null) {
                
                e = null;
            }
                
        }

        
    }
}
