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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for addTopic.xaml
    /// </summary>
    public partial class addTopic : UserControl
    {
        public addTopic()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            sendNotification();
            addNewTopic();
        }

        private void addNewTopic()
        {
            throw new NotImplementedException();
        }

        private void sendNotification()
        {
            throw new NotImplementedException();
        }
    }
}
