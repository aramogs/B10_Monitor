using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonwdixonTuto2_Workers.Util
{
    class Turno
    {



        public static string getTurno()
        {

            var date = DateTime.Now;
            //date.Hour;
            //date.Minute;

            if (date.Hour >= 7 && date.Hour < 15)
                return "T1";

            if (date.Hour >= 15 && date.Hour < 23)
                return "T2";

            return "T3";
        }


    }
}
