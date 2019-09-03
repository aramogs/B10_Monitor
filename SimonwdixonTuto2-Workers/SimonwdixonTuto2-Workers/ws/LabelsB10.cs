using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonwdixonTuto2_Workers.ws
{
    class LabelsB10
    {
        
        private LabelsB10() { }

        private static  LabelsB10 labelsB10;
        
        public static LabelsB10 getInstance() {

            if (labelsB10 == null)
                labelsB10 = new LabelsB10();


            return labelsB10;
        }



       

        

        public async void send(string no_sap, string serial_num, string printer,string dbName,string line)
        {
            DBConnectWs db = DBConnectWs.getInstance(dbName);
            try
            {
               
                DBConnectWs.server =  "10.56.98.3";
                //DBConnectWs.server = "localhost";
                DBConnectWs.database = (dbName == "" ? "b10_bartender" : dbName); 
                string dbN = "b10_bartender";
                DBConnectWs.uid = "root"; 
                DBConnectWs.password = "toor";
                //DBConnectWs.password = "";

                DBConnectWs.url = "http://tftdelsrv004:8086/Integration/{cust}/Execute?";


                string cust = db.getCustomer("use " + DBConnectWs.database + "; show tables;", no_sap);

                Program.log += "btnEnviar 01: " + "use " + DBConnectWs.database  + "; show tables; " + no_sap + "\n";

                
                HttpCli2 http = new HttpCli2();

                
                if (cust != "")
                {

                    string link = db.Select2("SELECT * FROM " + DBConnectWs.database + "." + cust + " where no_sap like '%" + no_sap + "'", cust);
                    
                    link += "&serial_num=" + serial_num;

                    link += "&printer=" + printer;

                    link += "&line=" + line;

                    string urlContents = await http.GetAsync(link);
                    Console.WriteLine("Web Serive " + urlContents);
                }

            }
            catch (Exception err)
            {

                Console.WriteLine("Error: " + err.Message);
                db.CloseConnection();
            }
        }


    }
}
