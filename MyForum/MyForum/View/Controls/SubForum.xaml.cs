using System;
using System.Windows;
using System.Windows.Controls;
using MyForum.Model;
using MyForum.ViewModel;

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for SubForum.xaml
    /// </summary>
    public partial class SubForum : UserControl
    {
        private readonly MyViewModel _vm;
        private User m_user;

        public SubForum(MyViewModel vm)
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
                d.SubjectLabel.Content = TopicSubject;
                d.nameLabel.Content = Name;
                this.StackPanel.Children.Add(d);

                //add topic to topic dictinary
                _vm.addTopic(new Topic(TopicSubject, TopicContent, m_user), this.SubForumNameLbl.Content.ToString());
            }
        }

        private void sendNotfi(string topicSubject, string topicContent)
        {
            // throw new NotImplementedException();
        }
    }
}