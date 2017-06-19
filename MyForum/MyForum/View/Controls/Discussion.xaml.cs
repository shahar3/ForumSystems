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
    /// Interaction logic for Discussion.xaml
    /// </summary>
    public partial class Discussion : UserControl
    {
        public string m_subject = "";
        public string m_content = "";


        public Discussion()
        {
            InitializeComponent();
        }

        //open new message window
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            messageWindow mw = new messageWindow();
            mw.Subject.Text = m_subject;
            mw.Content.Text = m_content;
            mw.Show();
        }
    }
}
