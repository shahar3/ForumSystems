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
        private User user;
        private readonly MyViewModel vm;

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
            var subForum = new SubForum(vm);
            subForum.SubForumNameLbl.Content = forumName;
            switch (forumName)
            {
                case "politics":
                    subForum.Name = user.UserName;
                    mainGrid.Children.Remove(mainForumC);
                    mainGrid.Children.Add(subForum);
                    var topics = vm.getTopics(forumName);
                    foreach (var topic in topics)
                    {
                        var discussion = new Discussion();
                        discussion.SubjectLabel.Content = topic.subject;
                        discussion.nameLabel.Content = topic.messageOwner.UserName;
                        subForum.StackPanel.Children.Add(discussion);
                    }
                    break;
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
    }
}