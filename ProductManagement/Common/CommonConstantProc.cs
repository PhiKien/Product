using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Common
{
    public static class CommonConstantProc
    {
        public static string PROC_GET_ALL_PRODUCT = "execute sp_get_all_product";

        public static string PROC_GET_ALL_USER = "execute sp_get_all_user";

        public static string PROC_GET_ALL_CATEGORY = "execute sp_get_all_category";

        public static string PROC_GET_PRODUCT_BY_ID = "execute sp_get_product_by_id @productID";

        public static string PROC_GET_CATEGORY_BY_ID = "execute sp_get_category_by_id @categoryID";


    }
}