using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Models
{
	public class WorkLog
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public int TimeSpentSeconds { get; set; }
		public string TimeSpent { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public DateTime? Started { get; set; }
		public Author Author { get; set; }

	}

	public class Author
	{
		public string Name { get; set; }
		public string Key { get; set; }
		public string EmailAddress { get; set; }
		public string DisplayName { get; set; }
	}
}
