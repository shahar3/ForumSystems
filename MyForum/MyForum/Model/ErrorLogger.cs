using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class ErrorLogger :Logger
    {
        private string content;

        /**
         * 
         * @param userId
         * @param complainId
         */
        public void sendErrorMessage(int userId, int complainId)
        {
        }

        public void errorMesage()
        {
        }

        public void InvalidOperation()
        {
        }
    }
}
