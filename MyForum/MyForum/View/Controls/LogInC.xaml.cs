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

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for LogInC.xaml
    /// </summary>
    public partial class LogInC : UserControl
    {
        MyViewModel vm;
        MainWindow mw;

        public LogInC(MyViewModel vm,MainWindow mw)
        {
            InitializeComponent();
            this.vm = vm;
            this.mw = mw;
        }

        //This event triggered when the user press on log in button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool existUser = vm.login(TbUserName.Text,TbPassword.Password);
            mw.existUser(existUser,TbUserName.Text);
        }
    }
}
