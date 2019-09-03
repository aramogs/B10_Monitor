using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace SimonwdixonTuto2_Workers
{
    class DBConnectGNX
    {

        private MySqlConnection connection;
        public static string server = "10.56.98.3";
        public static string database = "b10_bartender";
        public static string uid = "root";
        public static string password = "toor";
        public static string port = "3306";


        public readonly string config =
                string.Format("Server = {0}; Port = {1}; Database = {2}; Uid = {3}; Pwd = {4}; pooling = true; Allow Zero Datetime = False; Min Pool Size = 0; Max Pool Size = 200; ",
                server, port, database, uid, password);

        //Constructor
        private DBConnectGNX()
        {
            Initialize();
        }


        private static DBConnectGNX dBConnect;


        public static DBConnectGNX getInstance()
        {

            if (dBConnect == null)
                dBConnect = new DBConnectGNX();

            return dBConnect;
        }



        //Initialize values
        private void Initialize()
        {
            
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode=none";

            connection = new MySqlConnection(connectionString);
            
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Error MySQL: " + ex.Message);
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string sql)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string sql)
        {
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = sql;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string sql)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }





        public List<string>[] Select(string sql)
        {

            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            list[4] = new List<string>();
            list[5] = new List<string>();

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();


                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["no_sap"] + "");
                    list[2].Add(dataReader["pckd"] + "");
                    list[3].Add(dataReader["no_part"] + "");

                    list[4].Add(dataReader["cust"] + "");
                    list[5].Add(dataReader["plat"] + "");

                    Console.WriteLine();

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }


        public string Select2(string sql, string cust)
        {
            Console.WriteLine("--> " + sql);

            if (cust != "")
            {

                url = url.Replace("{cust}", cust);

                List<string>[] list = new List<string>[4];

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    var cols = new List<string>();

                    while (dataReader.Read())
                    {

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            url += dataReader.GetName(i) + "=" + dataReader[dataReader.GetName(i)] + "&";
                        }

                        url = url.Substring(0, url.Length - 1);
                        
                        break;
                    }


                    dataReader.Close();

                    this.CloseConnection();

                    
                }

            }

            Program.log += "url: " + url + " \n";

            return url;

        }


        public static string url = "http://tftdelsrv004:8086/Integration/{cust}/Execute?";

        public string Select2(string sql, string client, string str)
        {
            List<string>[] list = new List<string>[4];

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();



                var cols = new List<string>();

                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        url += dataReader.GetName(i) + "=" + dataReader[dataReader.GetName(i)] + "&";
            
                    }

            
                    Console.WriteLine("-------------------------------------------");
                    url = url.Substring(0, url.Length - 1);
                    Console.WriteLine(url);


                    break;
                }


                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                //return list;

            }

            return url;

        }


        public List<string> listCustumer(string sql, string no_cust)
        {

            Console.WriteLine("listCustumer");
            //Create a list to store the result
            List<string> custumers = new List<string>();


            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();



                //Read the data and store them in the list
                while (dataReader.Read())
                {



                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        custumers.Add(dataReader[dataReader.GetName(i)].ToString());

                    }



                    Console.WriteLine("-------------------------------------------");



                }


                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

            }

            return custumers;

        }



        public string listCustumer2(string sql, string no_cust)
        {

            string query = "";

            List<string> custumers = new List<string>();


            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                
                        query += "SELECT no_sap, '" + dataReader[dataReader.GetName(i)] + "' as custumer FROM " + database + "."
                            + dataReader[dataReader.GetName(i)] + " where no_sap like '%" + no_cust + "'";

                        query += " union ";
                        
                    }

                    

                }


                query = query.Substring(0, query.Length - 7);

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
                
            }

            return query;

        }


        public string getCustomer(string sql, string no_cust)
        {

            Console.WriteLine("link");
            string query = "";
            string cust = "";

            List<string> custumers = new List<string>();

            bool open = this.OpenConnection();
            
            if (open)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();


                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                
                        query += "SELECT no_sap, '" + dataReader[dataReader.GetName(i)] + "' as custumer FROM " + database + "."
                            + dataReader[dataReader.GetName(i)] + " where no_sap like '%" + no_cust + "'";

                        query += " union ";

                        
                    }

                    
                }


                query = query.Substring(0, query.Length - 7);

                Program.log += "query: " + query + " \n";
                this.CloseConnection();
                this.OpenConnection();

                Console.WriteLine(query);
                //Create Command

                MySqlCommand cmd1 = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();


                //Read the data and store them in the list
                while (dataReader1.Read())
                {

                    
                    cust = dataReader1[dataReader1.GetName(1)].ToString();

                    break;
                    

                }


                //close Data Reader
                dataReader.Close();

                //close Data Reader
                dataReader1.Close();

                //close Connection
                this.CloseConnection();
                
            }

            return cust;

        }



        //Count statement
        public int Count(string sql)
        {
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);


                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
                Console.WriteLine("--> " + ex.Message);
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
                Console.WriteLine("--> " + ex.Message);
            }
        }

    }
}
