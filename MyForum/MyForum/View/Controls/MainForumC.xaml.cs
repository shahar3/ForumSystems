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
        private RegisteredUser m_user;

        private string currentUserName;

        public string CurrentUserName
        {
            get { return currentUserName; }
            set { currentUserName = value; }
        }


        public MainForumC(MyViewModel vm, MainWindow mw)
        {
            InitializeComponent();
            this.vm = vm;
            this.mw = mw;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // List<Topic> topics = vm.getTopics("politics");
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("politics"))
            {
                MessageBox.Show("You need to follow this forum in order to open the forum");
                return;
            }
            mw.openForum("politics");
        }

        //follow politics
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(currentUserName == "" || currentUserName == null)
            {
                MessageBox.Show("You need to login to perform this action");
                return;
            }
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("politics"))
            {
                vm.follow(m_user, "politics");
                MessageBox.Show("You are follow politics forum!");
            }
            else
            {
                MessageBox.Show("You are already follow politicss forum");
            }
        }

        //follow economics
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentUserName == "" || currentUserName == null)
            {
                MessageBox.Show("You need to login to perform this action");
                return;
            }
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("economics"))
            {
                vm.follow(m_user, "economics");
                MessageBox.Show("You are follow economics forum!");
            }
            else
            {
                MessageBox.Show("You are already follow econonics forum");
            }
        }

        //follow sport
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentUserName == "" || currentUserName == null)
            {
                MessageBox.Show("You need to login to perform this action");
                return;
            }
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("sport"))
            {
                vm.follow(m_user, "sport");
                MessageBox.Show("You are follow sport forum!");
            }
            else
            {
                MessageBox.Show("You are already follow sport forum");
            }
        }

        //follow programming
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (currentUserName == "" || currentUserName == null)
            {
                MessageBox.Show("You need to login to perform this action");
                return;
            }
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("programming"))
            {
                vm.follow(m_user, "programming");
                MessageBox.Show("You are follow programming forum!");
            }
            else
            {
                MessageBox.Show("You are already follow programming forum");
            }
        }

        //follow general
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (currentUserName == "" || currentUserName == null)
            {
                MessageBox.Show("You need to login to perform this action");
                return;
            }
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("general"))
            {
                vm.follow(m_user, "general");
                MessageBox.Show("You are follow general forum!");
            }
            else
            {
                MessageBox.Show("You are already follow general forum");
            }
        }

        //open economics forum
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("economics"))
            {
                MessageBox.Show("You need to follow this forum in order to open the forum");
                return;
            }
            mw.openForum("economics");
        }

        //open sport forum
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("sport"))
            {
                MessageBox.Show("You need to follow this forum in order to open the forum");
                return;
            }
            mw.openForum("sport");
        }

        //open programming forum
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("programming"))
            {
                MessageBox.Show("You need to follow this forum in order to open the forum");
                return;
            }
            mw.openForum("programming");
        }

        //open general forum
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            m_user = vm.GetUser(currentUserName);
            if (!m_user.SubForumsList.Contains("general"))
            {
                MessageBox.Show("You need to follow this forum in order to open the forum");

                return;
            }
            mw.openForum("general");
        }
    }
}