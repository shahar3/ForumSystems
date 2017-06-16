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
using System.Windows.Shapes;

namespace MyForum.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        MyViewModel vm;

        public Register(MyViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //get all the fields
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string email = tbEmail.Text;
            string userName = tbUserName.Text;
            string password = tbPassword.Password;
            //check for a valid input
            if (firstName == "" || lastName == "" || email == "" || userName == "" || password == "")
            {
                MessageBox.Show("You need to fill all the fields");
            }
            else
            {
                vm.register(firstName, lastName, email, userName, password);
            }
        }
    }
}
