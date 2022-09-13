using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;

namespace ONIT_Kursov_2
{
    /// <summary>
    /// Логика взаимодействия для TCPListenersView.xaml
    /// </summary>
    public partial class TCPListenersView : Window
    {
        ObservableCollection<ModelTCPListener> TCPListeners;
        bool _udp;
        public TCPListenersView(bool UDP)
        {
            _udp = UDP;
            InitializeComponent();
            this.ContentRendered += TCPListenersView_ContentRendered;
        }

        private void TCPListenersView_ContentRendered(object sender, EventArgs e)
        {
            IPEndPoint[] tcpConnInfoArray;
            TCPListeners = new ObservableCollection<ModelTCPListener>();
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            if (_udp)
            {
                tcpConnInfoArray = ipGlobalProperties.GetActiveUdpListeners();
                this.Title = "UDPListenersView";
            }
            else
            {
                tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();
            }
            foreach(var item in tcpConnInfoArray)
            {
                TCPListeners.Add(new ModelTCPListener(item.Address.ToString(), item.Port.ToString()));
            }
            gridTCPListener.ItemsSource = TCPListeners;
            gridTCPListener.Columns[0].Width = 150;
            gridTCPListener.Columns[0].IsReadOnly = true;
            gridTCPListener.Columns[1].Width = 80;
            gridTCPListener.Columns[1].IsReadOnly = true;
        }
    }
}
