using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MyForum.Model;
using MyForum.View;
using MyForum.View.Controls;
using MyForum.ViewModel;

namespace MyForum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogInC loginC;
        private readonly MainForumC mainForumC;
        private RegisteredUser user;
        private readonly MyViewModel vm;
        private SubForumControl sf;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MyViewModel(new MyModel());
            DataContext = vm;
            loginC = new LogInC(vm, this);
            sp.Children.Add(loginC);
            mainForumC = new MainForumC(vm, this);
            mainGrid.Children.Add(mainForumC);
        }

        public void openForum(string forumName)
        {
            var subForum = new SubForumControl(vm);
            sf = subForum;
            subForum.SubForumNameLbl.Content = forumName;
            if (user != null)
            {
                subForum.Name = user.UserName;
            }
            else
            {
                subForum.Name = null;
            }
            mainGrid.Children.Remove(mainForumC);

            mainGrid.Children.Add(subForum);
            var topics = vm.getTopics(forumName);
            foreach (var topic in topics)
            {
                var discussion = new Discussion();
                discussion.m_content = topic.content;
                discussion.m_subject = topic.subject;
                discussion.SubjectLabel.Content = topic.subject;
                discussion.nameLabel.Content = topic.openedBy.UserName;
                subForum.StackPanel.Children.Add(discussion);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //openn register window
            var register = new Register(vm);
            register.Show();
        }

        //this function call after we check in the model if the user are exist
        public void existUser(bool existUser, string userName)
        {
            //check if the user exist
            if (existUser)
            {
                sp.Children.Clear();
                //add welcome message for this user
                displayWelcomeMessage(userName);
                user = vm.GetUser(userName);
                mainForumC.CurrentUserName = user.UserName;
                foreach (string notification in user.NotificationList)
                {
                    notificationLV.Items.Add(notification);
                }
                //clear the notification list for this user
                vm.clearNotification(userName);
            }
            else
            {
                MessageBox.Show("The details are not correct. please try again");
            }
        }

        //create welcome message for specific user name
        public void displayWelcomeMessage(string userName)
        {
            var tb = new TextBlock();
            tb.Text = "Hello " + userName + ", welcome to SIDY forums";
            sp.Children.Add(tb);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.sf != null)
            {
                this.mainGrid.Children.Remove(this.sf);
                this.mainGrid.Children.Add(this.mainForumC);
            }
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            vm.close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = this.SearchTextBox.Text;

            List<Topic> ansList = new List<Topic>();

            try
            {
                foreach (var subForum in user.SubForumsList)
                {
                    List<Topic> topicList = vm.getTopics(subForum);
                    foreach (var topic in topicList)
                    {
                        if (topic.subject.Contains(query) || topic.content.Contains(query))
                        {
                            ansList.Add(topic);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            if (ansList.Count == 0)
            {
                MessageBox.Show("The search find nothing");
            }

            else
            {
                searchResult sr = new searchResult();

                foreach (var topic in ansList)
                {
                    Discussion d = new Discussion();
                    d.m_content = topic.content;
                    d.m_subject = topic.subject;
                    d.nameLabel.Content = topic.userFirstOpenMsgName;
                    d.SubjectLabel.Content = topic.subject;
                    sr.StackPanel.Children.Add(d);
                }
                
                sr.Show();
            }

            


        }
    }
}