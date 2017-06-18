using MyForum.ViewModel;
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
using MyForum.Model;

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for MainForumC.xaml
    /// </summary>
    public partial class MainForumC : UserControl
    {
        private MyViewModel vm;
        private MainWindow mw;

        public MainForumC(MyViewModel vm, MainWindow mw)
        {
            InitializeComponent();
            this.vm = vm;
            this.mw = mw;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // List<Topic> topics = vm.getTopics("politics");
            mw.openForum("politics");
        }
    }
}