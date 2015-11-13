

using System;

namespace Jira.REST.Contracts
{
	public class LoginResponseSuccess : IResponse
	{
		public Session Session { get; set; }
		public LoginInfo LoginInfo { get; set; }
	}

	public class Session
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class LoginInfo
	{
		public string FailedLoginCount { get; set; }
		public string LoginCount { get; set; }
		public DateTime LastFailedLoginTime { get; set; }
		public DateTime PreviousLoginTime { get; set; }
	}
}
