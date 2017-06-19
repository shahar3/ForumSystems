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

		public Admin():base("")
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
