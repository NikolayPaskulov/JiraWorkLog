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
		private IEnumerable<NameValueModel> _sprints;
		private IEnumerable<NameValueModel> _issues;
		private int _selectedBoard;
		private int _selectedSprint;
		private int _selectedIssue;

		public ProjectViewModel(IProjectView view, IEnumerable<IPresentationViewModel> presentationViewModels, Jira.REST.Jira jira)
		{
			this.Name = "Project Screen";
			this.Page = Pages.Project;
			this.View = view;
			_presentationViewModels = presentationViewModels;
			_jira = jira;

			InitCommands();

		}

		private void InitCommands()
		{
			Boards_Changed = new DelegateCommand(_ =>
			{
				int test = SelectedBoard;

				Sprints = _jira.GetBoardSprints(test.ToString())
				.Where(x => x.State == "active")
				.Select(x => new NameValueModel {
					Name = x.Name,
					Value = x.Id
				});
            });
		}

		public IEnumerable<NameValueModel> Boards
		{
			get { return _boards; }
			set { this.SetField(ref this._boards, value, () => this.Boards); }
		}
		public IEnumerable<NameValueModel> Sprints
		{
			get { return _sprints; }
			set { this.SetField(ref this._sprints, value, () => this.Sprints); }
		}

		public int SelectedBoard
		{
			get { return _selectedBoard;  }
			set { this.SetField(ref this._selectedBoard, value, () => this.SelectedBoard); }
		}

		private int SelectedSprint
		{
			get { return _selectedSprint; }
			set { this.SetField(ref this._selectedSprint, value, () => this.SelectedSprint); }
		}

		public string Name { get; set; }
		public Pages Page { get; set; }
		public IView View { get; set; }

		public DelegateCommand Boards_Changed { get; set; }

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
