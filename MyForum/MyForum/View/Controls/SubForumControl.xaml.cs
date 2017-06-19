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
using MyForum.ViewModel;

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for SubForumControl.xaml
    /// </summary>
    public partial class SubForumControl : UserControl
    {
        private readonly MyViewModel _vm;
        private RegisteredUser m_user;

        public SubForumControl(MyViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
        }

        public string Name { get; set; }

        private void AddDiscussionButton_Click(object sender, RoutedEventArgs e)
        {
            m_user = _vm.GetUser(Name);
            if (Name == null || !m_user.havePermission(SubForumNameLbl.Content.ToString()))
                MessageBox.Show("You dont have premission to add topic in " + SubForumNameLbl.Content.ToString());
            else
            {
                var newTopic = new NewTopic(this);
                newTopic.Show();
            }
        }

        public void addTopic(string content, string subject)
        {
            var TopicSubject = subject;
            var TopicContent = content;
            if (TopicSubject != "" && TopicContent != "")
            {
                sendNotfi(TopicSubject, TopicContent);
                Discussion d = new Discussion();
                d.m_content = TopicContent;
                d.m_subject = TopicSubject;
                d.SubjectLabel.Content = TopicSubject;
                d.nameLabel.Content = Name;
                this.StackPanel.Children.Add(d);
                //add topic to topic dictinary
                _vm.addTopic(new Topic(TopicSubject, TopicContent, m_user), this.SubForumNameLbl.Content.ToString());
            }
        }

        private void sendNotfi(string topicSubject, string topicContent)
        {
            _vm.sendNotification(topicSubject, topicContent, SubForumNameLbl.Content.ToString(), m_user.UserName);
        }



        //follow forum
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m_user = _vm.GetUser(Name);
            if (!m_user.SubForumsList.Contains(SubForumNameLbl.Content.ToString()))
            {
                _vm.follow(m_user, SubForumNameLbl.Content.ToString());
                MessageBox.Show("You are follow " + SubForumNameLbl.Content.ToString() + " forum!");
            }
            else
            {
                MessageBox.Show("You are already follow " + SubForumNameLbl.Content.ToString() + " forum");
            }
        }
    }
}
