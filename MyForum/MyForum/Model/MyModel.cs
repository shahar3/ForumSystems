using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class MyModel:INotifyPropertyChanged
    {
        public MyModel()
        {
            
        }

#region event handler
        public event PropertyChangedEventHandler PropertyChanged;
        public void notifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
#endregion
    }
}
