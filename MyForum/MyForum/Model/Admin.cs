using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Admin : AManagement
    {
        public Admin(string firstName, string lastName, string email, string password, string userName) : base(firstName, lastName, email, password, userName)
        {
        }
    }
}
