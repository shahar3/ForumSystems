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

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for NewTopic.xaml
    /// </summary>
    public partial class NewTopic : Window
    {
        public bool End = false;
        private SubForum sf;

        public NewTopic(SubForum subForum)
        {
            sf = subForum;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            sf.addTopic(this.ContentTextBox.Text, this.SubjectTextBox.Text);
            this.Close();
        }
    }
}