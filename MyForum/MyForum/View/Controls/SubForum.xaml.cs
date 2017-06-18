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
    /// Interaction logic for SubForum.xaml
    /// </summary>
    public partial class SubForum : UserControl
    {
        private User m_user;
        private string name;
        private MyViewModel _vm;

        public SubForum(MyViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
        }

        private void AddDiscussionButton_Click(object sender, RoutedEventArgs e)
        {
            m_user = _vm.GetUser(name);
            if (!m_user.havePermission(SubForumNameLbl.Content.ToString()) || name == null)
            {
                MessageBox.Show(SubForumNameLbl.Content.ToString());
                //MessageBox.Show("You Not Have The Permission To Add Topic In This Forum");
            }
            else
            {
                addTopic();
            }
        }

        private void addTopic()
        {
            NewTopic newTopic = new NewTopic();
            newTopic.Show();
            string TopicSubject = newTopic.SubjectTextBox.Text;
            string TopicContent = newTopic.ContentTextBox.Text;
            if (TopicSubject != "" && TopicContent != "")
            {
                sendNotfi(TopicSubject, TopicContent);
            }
        }

        private void sendNotfi(string topicSubject, string topicContent)
        {
            throw new NotImplementedException();
        }
    }
}