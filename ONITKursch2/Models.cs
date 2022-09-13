using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT_Kursov_2
{
    class ModelTCPConnect
    {
        public string Ip { get; set; }
        public string Port { get; set; }

        public string Ip_Remote { get; set; }
        public string Port_Remote { get; set; }

        public ModelTCPConnect(string ip, string port, string ip_r, string port_r)
        {
            Ip = ip; Port = port; Ip_Remote = ip_r; Port_Remote = port_r;
        }
        public ModelTCPConnect() { }
    }

    internal class ModelTCPListener
    {
        public string Ip { get; set; }
        public string Port { get; set; }

        public ModelTCPListener(string ip, string port)
        {
            Ip = ip; Port = port;
        }
        public ModelTCPListener() { }
    }
}
