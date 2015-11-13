using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Models
{
	public class Board
	{
		public int Id { get; set; }

		public string Self { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }
	}
}
