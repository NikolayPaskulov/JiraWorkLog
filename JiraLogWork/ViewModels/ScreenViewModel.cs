using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraLogWork.ViewModels
{
	public class ScreenViewModel : ViewModelBase
	{
		private IPresentationViewModel _currentPresentation;

		public IPresentationViewModel CurrentPresentation
		{
			get { return _currentPresentation; }
			set { this.SetField(ref this._currentPresentation, value, () => this.CurrentPresentation); }
		}

		public void ChangeView(IPresentationViewModel view)
		{
			if (view != null)
			{
				CurrentPresentation = view;
				view.ViewChanged();
			}
		}
	}
}
