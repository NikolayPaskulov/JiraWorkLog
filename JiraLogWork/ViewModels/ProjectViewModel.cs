using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraLogWork.Views;
using JiraLogWork.Models;

namespace JiraLogWork.ViewModels
{
	public class ProjectViewModel : ViewModelBase, IPresentationViewModel
	{

		private IEnumerable<IPresentationViewModel> _presentationViewModels;
		private Jira.REST.Jira _jira;
		private IEnumerable<NameValueModel> _boards;

		public ProjectViewModel(IProjectView view, IEnumerable<IPresentationViewModel> presentationViewModels, Jira.REST.Jira jira)
		{
			this.Name = "Project Screen";
			this.Page = Pages.Project;
			this.View = view;
			_presentationViewModels = presentationViewModels;
			_jira = jira;
		}

		public IEnumerable<NameValueModel> Boards
		{
			get { return _boards; }
			set { this.SetField(ref this._boards, value, () => this.Boards); }
		}

		public string Name { get; set; }
		public Pages Page { get; set; }
		public IView View { get; set; }

		public void ViewChanged()
		{
			Boards = _jira.GetAllBoards().Select(x => new NameValueModel
			{
				Name = x.Name,
				Value = x.Id
			});
		}
	}
}
