using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Common
{
    public static class CommonConstantProc
    {
        //stored procedure of Product
        public static string PROC_GET_ALL_PRODUCT = "execute sp_get_all_product";

        public static string PROC_GET_PRODUCT_BY_ID = "execute sp_get_product_by_id @productID";

        public static string PROC_UPDATE_PRODUCT = "execute sp_update_product @productID, @productName, @productDescription, @productNumberInStock, @categoryID";
        
        public static string PROC_CREATE_PRODUCT = "execute sp_create_product @productName, @productDescription, @productNumberInStock, @categoryID";

        public static string PROC_DELETE_PRODUCT = "execute sp_delete_product @productID";

        //stored procedure of User 
        public static string PROC_GET_ALL_USER = "execute sp_get_all_user";

        public static string PROC_GET_USER_BY_ID = "execute sp_get_user_by_id @userID";

        public static string PROC_DELETE_USER = "execute sp_delete_user @userID";

        public static string PROC_CREATE_USER = "execute sp_create_user @userName, @password, @name, @address, @email, @phone, @createDate, @modifiedDate, @status, @roleID";

        public static string PROC_UPDATE_USER = "execute sp_update_user @ID, @UserName, @Password, @Name, @Address, @Email, @Phone, @CreateDate, @ModifiedDate, @Status, @RoleID";
    
        //stored procedure of Category
        public static string PROC_GET_ALL_CATEGORY = "execute sp_get_all_category";

        public static string PROC_GET_CATEGORY_BY_ID = "execute sp_get_category_by_id @categoryID";
        
    }
}

