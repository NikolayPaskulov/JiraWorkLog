using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraLogWork.Views;
using System.Windows.Controls;

namespace JiraLogWork.ViewModels
{
	public class LoginViewModel : ViewModelBase, IPresentationViewModel
	{

		private string _jiraUrl = "https://t3am0wner.atlassian.net";
		private string _userName;
		private Jira.REST.Jira _jira;
		private IEnumerable<IPresentationViewModel> _presentationViewModels;
		private ScreenViewModel _screenViewModel;

		public LoginViewModel(ILoginView view, IEnumerable<IPresentationViewModel> presentationViewModels, Jira.REST.Jira jira, ScreenViewModel screenViewModel)
		{
			View = view;
			Name = "Login";
			Page = Pages.Login;
			_jira = jira;
			_presentationViewModels = presentationViewModels;
			_screenViewModel = screenViewModel;

			AddCommandsHandlers();
        }

		private void AddCommandsHandlers()
		{
			Logic_Click = new DelegateCommand(async box =>
			{
				try
				{
					var connection = await _jira.Connect(JiraUrl, Username, (box as PasswordBox).Password);
					if(connection)
					{
						var view = _presentationViewModels.FirstOrDefault(x => x.Page == Pages.Project);
						_screenViewModel.ChangeView(view);
					}
				} 
				catch (Exception e)
				{

				}
            });
		}

		public void ViewChanged()
		{

		}

		public string Name { get; set; }

		public Pages Page { get; set; }

		public IView View { get; set; }

		public string JiraUrl
		{
			get { return _jiraUrl; }
			set { this.SetField(ref this._jiraUrl, value, () => this.JiraUrl); }
		}

		public string Username
		{
			get { return _userName; }
			set { this.SetField(ref this._userName, value, () => this.Username); }
		}

		private string Password { get; set; }


		public DelegateCommand Logic_Click { get; private set; }
	}
}
