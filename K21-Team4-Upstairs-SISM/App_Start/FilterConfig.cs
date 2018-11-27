using System.Web;
using System.Web.Mvc;

namespace K21_Team4_Upstairs_SISM
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
