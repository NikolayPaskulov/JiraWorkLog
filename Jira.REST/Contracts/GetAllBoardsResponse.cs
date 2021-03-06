﻿using Jira.REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Contracts
{
	public class GetAllBoardsResponse
	{
		public int MaxResults { get; set; }

		public int StartAt { get; set; }

		public bool IsLast { get; set; }

		public IEnumerable<Board> Values { get; set; }
	}
}
