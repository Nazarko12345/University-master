using System;
using System.Collections.Generic;
using System.Linq;
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
using TaxiDriverApp.DataTypes;
using TaxiDriverApp.IOTypes;
using System.Windows.Threading;
namespace TaxiDriverApp
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private TaxiOrder currentOrder;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private DateTime startTime;
        private TimeSpan elapsedTime;
        public OrderWindow(TaxiOrder _currentOrder)
        {
            InitializeComponent();
            currentOrder = _currentOrder;

            clientNameDesc.Content = currentOrder.Client.Name;
            clientPhoneDesc.Content = currentOrder.Client.PhoneNumber;
            clientFromDesc.Content = currentOrder.Dispatch;
            clientToDesc.Content = currentOrder.Destination;
            clientTimeDesc.Content = currentOrder.ArriveTime.ToString("dd-MM-yyyy HH:mm");
        }
        private void startTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            startTime = DateTime.Now;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            timerDesc.Content = elapsedTime.ToString();
        }
        private void startRoad_Click(object sender, RoutedEventArgs e)
        {
            startTimer();
        }
        private void endRoad_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            currentOrder.RoadTime = (uint)elapsedTime.TotalSeconds;
            currentOrder.IsDone = true;
            currentOrder.Cost = currentOrder.Driver.CostPerMinute * currentOrder.RoadTime / 60;
            roadCostDesc.Content = currentOrder.Cost + " грн";
            MessageBox.Show(String.Format("Вітаємо {0} з вас {1} грн!!!", currentOrder.Client.Name, currentOrder.Cost), "Квитанція");
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Name == "MainTaxiDriverWindow")
                {
                    (item as MainWindow).updateOrders(currentOrder);
                    (item as MainWindow).updateCounter();
                    break;
                }
            }
            Close();
        }
    }
}
