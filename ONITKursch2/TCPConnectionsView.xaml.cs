using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Windows.Shapes;

namespace ONIT_Kursov_2
{
    /// <summary>
    /// Логика взаимодействия для TCPConnectionsView.xaml
    /// </summary>
    public partial class TCPConnectionsView : Window
    {
        ObservableCollection<ModelTCPConnect> TCPConnections;
        public TCPConnectionsView()
        {
            InitializeComponent();
            this.ContentRendered += TCPConnectionsView_ContentRendered;
        }

        private void TCPConnectionsView_ContentRendered(object sender, EventArgs e)
        {
            TCPConnections = new ObservableCollection<ModelTCPConnect>();
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (var item in tcpConnInfoArray)
            {
                TCPConnections.Add(new ModelTCPConnect(item.LocalEndPoint.Address.ToString(), item.LocalEndPoint.Port.ToString(), item.RemoteEndPoint.Address.ToString(), item.RemoteEndPoint.Port.ToString()));
            }
            gridTCPConnections.ItemsSource = TCPConnections;
            gridTCPConnections.Columns[0].Width = 150;
            gridTCPConnections.Columns[0].IsReadOnly = true;
            gridTCPConnections.Columns[1].Width = 80;
            gridTCPConnections.Columns[1].IsReadOnly = true;

            gridTCPConnections.Columns[2].Width = 150;
            gridTCPConnections.Columns[2].IsReadOnly = true;
            gridTCPConnections.Columns[3].Width = 80;
            gridTCPConnections.Columns[3].IsReadOnly = true;
        }
    }
}
