using Newtonsoft.Json;
using SimonwdixonTuto2_Workers.arribo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonwdixonTuto2_Workers
{
    public partial class Form1 : Form
    {
        public static Boolean jobeDone = true;
        public static string error = "";
        public string HOST_NAME = "localhost";
        public string QUEUE_NAME = "workQueues";

        private Producer producerSessionSAP;

        private Producer2 prod2 = new Producer2();
        private Consumer consumer;
        

        public Form1()
        {
            InitializeComponent();

            producerSessionSAP = new Producer(HOST_NAME, QUEUE_NAME);

            consumer = new Consumer(HOST_NAME, QUEUE_NAME);
            consumer.onMessageReceived += handleMessage;
            consumer.onMessageReceived2 += handleMessage;
            consumer.StartConsuming();

            threadChek5min();


            // -------------- Hilo blank -----------------------

                ThreadStart delegado = new ThreadStart(CorrerProceso);

                Thread hilo = new Thread(delegado);
                hilo.Start();
            // -------------------------------------------------



            //------------ Hilo de session SAP -----------------

            ThreadStart delegadoSap = new ThreadStart(CorrerProcesoSAP);
            Thread hiloSessionSAP = new Thread(delegadoSap);
            hiloSessionSAP.Start();
            //--------------------------------------------------
        }



        private void CorrerProceso()
        {
            while (true)
            {
                //Hacer que se tarde 10000 milisegundos (10 segundos) 
                //cada 2 minutos
                Thread.Sleep(2 * 60 * 1000);
                string json = "";

                Parte p = new Parte();

                p.nSAP = "";

                json = JsonConvert.SerializeObject(p);

                prod2.SendMessage(System.Text.Encoding.UTF8.GetBytes(json));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private delegate void showMessageDelegate(string message);



        public void handleMessage(byte[] message)
        {

            try
            {
                Parte m = JsonConvert.DeserializeObject<Parte>(System.Text.Encoding.UTF8.GetString(message));

                Console.WriteLine("--- SAP ---> " + m.nSAP);

                showMessageDelegate s = new showMessageDelegate(richTextBox1.AppendText);

                if (m.nSAP != "") 
                    this.Invoke(s, "Station: " + m.estacion + " " + m.nSAP + " " + m.pckd + " in " + m.impresora + 
                    Environment.NewLine);

            }
            catch (Exception e) {

                Console.WriteLine("Error en el objeto");
            }
        }

        public void handleMessage(byte[] message,bool error)
        {

            try
            {
                string m = System.Text.Encoding.UTF8.GetString(message);

                Console.WriteLine("--- Error ---> " + m);

                showMessageDelegate s = new showMessageDelegate(richTextBox1.AppendText);

                if (m != "" && error)
                    this.Invoke(s, "Error: " + m + Environment.NewLine);
                else if (m != "" && !error)
                    this.Invoke(s, "Success: " + m + Environment.NewLine);

            }
            catch (Exception e)
            {

                Console.WriteLine("Error en el objeto");
            }
        }





        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Form1_FormClosed");
            //this.Close();
            this.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Form1_FormClosing");
            //if (consumer != null) { }
             consumer.Dispose();
                
        }


        public void lanzarConsumerHilo()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Console.WriteLine("Procesos lanzarConsumerHilo");
            while (true) {
                
                if (!consumer.isConsuming)
                {
                    consumer = new Consumer(HOST_NAME, QUEUE_NAME);
                    consumer.onMessageReceived += handleMessage;
                    consumer.StartConsuming();

                    Console.WriteLine("if (consumer == null)");
                }

                Console.WriteLine("ini 5 min - Thread.Sleep");
                Thread.Sleep(
                                    //5 * 
                                    10 * 
                                    1000
                             );

                Console.WriteLine("fin 5 min - Thread.Sleep");

            }
        }


        
        public void threadChek5min() {

            

            Console.WriteLine("Boton Hilo 5 min");

            ThreadStart task5min = new ThreadStart(lanzarConsumerHilo);
            Thread h5 = new Thread(task5min);
            h5.Start();
        }
        

        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        
        


        private void button4_Click(object sender, EventArgs e)
        {
            
        }




        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {         
                Hide();
                notifyIcon1.Visible = true;

                Thread.Sleep(3000);
                notifyIcon1.ShowBalloonTip(10000, "Ready", "The Monitor is Ready", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);
        }


        public void Form1_Click() {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            


    }



        bool bande = true;

        private void CorrerProcesoSAP()
        {


            while (true)
            {
                
                    //Hacer que se tarde 10000 milisegundos (10 segundos) 
                    Thread.Sleep(3 * 60 * 1000);
                
                    Parte p = new Parte();

                    p.nSAP = "";


                    String json = JsonConvert.SerializeObject(p);

                    Console.WriteLine(json);
                    try
                    {

                        producerSessionSAP.SendMessageTTL(System.Text.Encoding.UTF8.GetBytes(json));
                    
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error de conn en el RabbitMq");
                    }
                
            }
        }




        ProducerToEx pEx = new ProducerToEx();

        private void button3_Click_1(object sender, EventArgs e)
        {


            
        }

        





    }
}
