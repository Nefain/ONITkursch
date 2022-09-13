using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ONIT_Kursov_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();
            var aa = ipGlobalProperties.GetActiveTcpConnections();
            var bb = ipGlobalProperties.GetActiveUdpListeners();
        }

        private void ShowActiveTCPListeners(object sender, RoutedEventArgs e)
        {
            TCPListenersView listenersView = new TCPListenersView(false);
            listenersView.Show();
        }

        private void ShowActiveTCPConnections(object sender, RoutedEventArgs e)
        {
            TCPConnectionsView connectionsView = new TCPConnectionsView();
            connectionsView.Show();
        }

        private void ShowActiveUDPListeners(object sender, RoutedEventArgs e)
        {
            TCPListenersView listenersView = new TCPListenersView(true);
            listenersView.Show();
        }
    }
}
