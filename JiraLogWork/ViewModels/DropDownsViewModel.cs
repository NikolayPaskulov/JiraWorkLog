
using JiraLogWork.Models;
using System.Collections.Generic;

namespace JiraLogWork.ViewModels
{
	public class DropDownsViewModel : ViewModelBase
	{
		private IEnumerable<NameValueModel> _boards;
		private IEnumerable<NameValueModel> _sprints;
		private IEnumerable<NameValueModel> _issues;
		private Jira.REST.Jira _jira;

		public DropDownsViewModel(Jira.REST.Jira jira)
		{
			_jira = jira;
		}

		public void GetBoards()
		{

		}
	}
}
