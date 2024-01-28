namespace SchoolProject.Data.AppMetaData
{
	public static class Router
	{
		public const string root = "Api";
		public const string version = "V1";
		public const string Rule = root + "/" + version + "/";
		public const string singleRoute = "{id}";
		public static class StudentRouting
		{
			public const string Prefix = Rule + "Student/";
			public const string List = Prefix + "List";
			public const string GetById = Prefix + singleRoute;
			public const string Create = Prefix + "Create";
			public const string Edit = Prefix + "Edit";
			public const string Delete = Prefix + singleRoute;
			public const string Paginated = Prefix + "Paginated";
		}
		public static class DepartmentRouting
		{
			public const string Prefix = Rule + "Department/";
			public const string GetById = Prefix + "Id";
		}
		public static class UserRouting
		{
			public const string Prefix = Rule + "User/";
			public const string Create = Prefix + "Create";
			public const string Paginated = Prefix + "Paginated";
			public const string GetById = Prefix + singleRoute;
			public const string Edit = Prefix + "Edit";
			public const string Delete = Prefix + singleRoute;
			public const string ChangePassword = Prefix + "ChangePassword";
		}
	}
}
