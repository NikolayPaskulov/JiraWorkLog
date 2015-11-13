using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Models
{
	public class Sprint
	{
		public int Id { get; set; }
		public string Self { get; set; }
		public string State { get; set; }
		public string Name { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? CompleteDate { get; set; }
		public int? OriginBoardId { get; set; }
	}
}
