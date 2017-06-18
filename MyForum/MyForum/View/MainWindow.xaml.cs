using MyForum.Model;
using MyForum.View;
using MyForum.View.Controls;
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

namespace MyForum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyViewModel vm;
        LogInC loginC;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MyViewModel(new MyModel());
            this.DataContext = vm;
            loginC = new LogInC(vm,this);
            sp.Children.Add(loginC);
            MainForumC mainForumC = new MainForumC(vm,this);
            mainGrid.Children.Add(mainForumC);
        }

        public void openForum(string forumName)
        {
            switch (forumName)
            {
                case "politics":
                    mainGrid.Children.Clear();
                   // PoliticsForumC pf = new PoliticsForumC();
                   // mainGrid.Children.Add(pf);
                    break;
                    
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //openn register window
            Register register = new Register(vm);
            register.Show();
        }

        //this function call after we check in the model if the user are exist
        public void existUser(bool existUser,string userName)
        {
            //check if the user exist
            if (existUser)
            {
                sp.Children.Clear();
                //add welcome message for this user
                displayWelcomeMessage(userName);
            }
            else
            {
                MessageBox.Show("The details are not correct. please try again");
            }
        }

        //create welcome message for specific user name
        public void displayWelcomeMessage(string userName)
        {
            TextBlock tb = new TextBlock();
            tb.Text = "Hello " + userName + ", welcome to SIDY forums";
            sp.Children.Add(tb);
        }
    }
}
