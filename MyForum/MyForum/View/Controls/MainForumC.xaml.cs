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

namespace MyForum.View.Controls
{
    /// <summary>
    /// Interaction logic for MainForumC.xaml
    /// </summary>
    public partial class MainForumC : UserControl
    {
        MyViewModel vm;

        public MainForumC(MyViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }
    }
}
