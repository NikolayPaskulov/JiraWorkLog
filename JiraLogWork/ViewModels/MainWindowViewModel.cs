
using System.Collections.Generic;
using System.Linq;


namespace JiraLogWork.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public ScreenViewModel ScreenViewModel { get; set; }

		public MainWindowViewModel(IEnumerable<IPresentationViewModel> presentationViewModels, ScreenViewModel screenViewModel)
		{

			ScreenViewModel = screenViewModel;

            var loginView = presentationViewModels.FirstOrDefault(x => x.Page == Pages.Login);
			ScreenViewModel.ChangeView(loginView);
		}
	}
}
