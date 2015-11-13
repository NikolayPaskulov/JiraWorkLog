using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraLogWork.ViewModels.Base;
using JiraLogWork.Views;

namespace JiraLogWork.ViewModels
{
	public interface IPresentationViewModel : IViewModel
	{
		string Name { get; set; }
		IView View { get; set; }
		Pages Page { get; set; }
		void ViewChanged();
	}
}
