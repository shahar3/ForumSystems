using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Moderator : AManagement
    {
        public Moderator(string firstName, string lastName, string email, string password, string userName) : base(firstName, lastName, email, password, userName)
        {
        }
    }
}
