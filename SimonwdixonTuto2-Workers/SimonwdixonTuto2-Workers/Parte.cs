using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonwdixonTuto2_Workers
{
   
    class Parte
    {
        public string subline = "";
        public string dataBase = "";

        public string estacion; //1, 2, 3, 4 desde la configuracion

        public string impresora; //  desde la configuracion 

        public string impresoraBartender; //  desde la configuracion 

        public string nSAP; //P7000016313A0

        public int pckd; //10 esta ligado al numero de SAP

        public string nParte; // cadena de parte 935446202 esta ligado al numero de SAP

        public int nProveedor = 19906610; // numero de proovedor 19906610

        public string fecha; // fecha 17423 ver si la saco en auto

        public int nSerieserie; // 00004 un ++


        public string nVali = "";

        private bool printNumb;

        public string empresa = "";


        public string cust = "";
        public string plat = "";


        public bool bartender = false;

        public bool PrintNumb
        {
            get
            {
                return printNumb;
            }

            set
            {
                printNumb = value;
            }
        }

        public Parte()
        {

        }


        public Parte(int pk, string nP)
        {

            nParte = nP;
            pckd = pk;
        }
        
    }
}
