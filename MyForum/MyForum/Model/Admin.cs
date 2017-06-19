using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class Admin : RegisteredUser
	{
		Forum Manage;

		public Admin(string firstName, string lastName, string email, string password, string userName, bool canDeleteMsg, bool canDeleteTopic, bool canBanUser, List<string> notification, List<string> subForumList) : base(firstName, lastName, email, password, userName, true, true, true, notification, subForumList)
		{

		}


	/**
	 * 
	 * @param managerId
	 * @param forumId
	 */
	public void checkManager(int managerId, int forumId)
		{
		}

		public void sendAppelToManager()
		{
		}

		/**
		 * 
		 * @param UserId
		 */
		public void decideIfYouWantBanUser(int UserId)
		{
		}

		/**
		 * 
		 * @param reportId
		 * @param forumId
		 * @param ModeratorId
		 */
		public void SendReport(int reportId, int forumId, int ModeratorId)
		{
		}

	}
}
