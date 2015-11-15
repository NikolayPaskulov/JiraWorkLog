using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using JiraLogWork.ViewModels;
using JiraLogWork.Views;
using System.Threading;

namespace JiraLogWork
{
	static class Bootstrapper
	{

		[STAThread]
		static void Main()
		{
			var container = Bootstrap();

			RunApplication(container);
		}

		private static Container Bootstrap()
		{
			var container = new Container();

			container.RegisterSingleton<Jira.REST.Jira>();

			container.RegisterSingleton<MainWindow>();
			container.RegisterSingleton<MainWindowViewModel>();

			container.RegisterSingleton<LoginViewModel>();
			container.RegisterSingleton<ProjectViewModel>();

			container.RegisterSingleton<ScreenViewModel>();

			container.RegisterCollection<IPresentationViewModel>(
				new[] {
					typeof(LoginViewModel),
					typeof(ProjectViewModel)
				}
			);

			container.RegisterSingleton<ILoginView, LoginView>();
			container.RegisterSingleton<IProjectView, ProjectView>();

			// Register your windows and view models:
			//container.RegisterSingle<MainWindow>();
			//container.RegisterSingle<MainWindowViewModel>();
			//container.RegisterSingle<StatusViewModel>();

			//container.RegisterSingle<TravelTabDbContext>(() => new TravelTabDbContext());

			//container.Register<ITimeZoneManager, TimeZoneManager>();
			//container.Register<ITimeZoneStrategy, GoogleTimeZoneStrategy>();

			//container.Register<ICoordinatesStrategy, GoogleCoordinatesStrategy>();
			//container.Register<ICoordinatesManager, CoordinatesManager>();

			//container.RegisterAll<ICommerceCategoriesStrategy>(typeof(ViatorCommerceCategoriesStrategy), typeof(TravelTabCommerceCategoriesStrategy));

			//container.Register<ICommerceCategoriesManager, CommerceCategoriesManager>();

			//container.RegisterSingle<ICommerceRankingStrategy, ViatorCommerceRankingStrategy>();
			//container.Register<ICommerceRankingManager, CommerceRankingManager>();

			//container.Register<IViatorService>(() => ViatorService.Factory());

			//var allUpdateTasks = AppDomain.CurrentDomain.GetAssemblies()
			//											.SelectMany(x => x.GetTypes())
			//											.Where(mytype => mytype.GetInterfaces()
			//																	.Contains(typeof(IUpdateTask)) &&
			//																	mytype.Name != "UpdateTask");

			//container.RegisterAll<IUpdateTask>(allUpdateTasks);

			container.Verify();

			return container;
		}

		private static void RunApplication(Container container)
		{
			try
			{
				var app = new App();
				var mainWindow = container.GetInstance<MainWindow>();
				app.Run(mainWindow);
			}
			catch (Exception ex)
			{
				//Log the exception and exit
			}
		}
	}
}
