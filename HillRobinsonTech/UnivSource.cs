using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace HillRobinsonTech
{
    class UnivSource
    {
        //sql connection
        public static string connectionString = @"Data Source=10.19.107.154, 1433; Database=florent_hillrobinsontech_local; User ID=sa;Password=Mranderson1!";
        //@"Data Source=188.213.133.2,1533; Database=florent_hillrobinsontech; User ID=florent_avitsql;Password=BlackMatza777!!!???";
        //@"Data Source=188.213.132.104,1533; User ID=avitsql;Password=Mranderson1!";
        public static SqlConnection connection = new SqlConnection(connectionString);

        //public static string fullNameConnected = "";
       
    }
}

