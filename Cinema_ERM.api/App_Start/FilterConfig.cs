﻿using System.Web;
using System.Web.Mvc;

namespace Cinema_ERM.api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
