using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;

namespace CommonLibrary
{
    public class CommonUserLogin
    {
        private string userID;
        public string UserID
        {
            get { return this.userID; }
        }

        private string supplierID;
        public string SupplierID
        {
            get { return this.supplierID; }
        }

        private string userInitials;
        public string UserInitials
        {
            get { return this.userInitials; }
        }

        private ArrayList menuList;
        public ArrayList MenuList
        {
            get { return menuList; }
        }

        private CommonEnum.UserType userType;
        public CommonEnum.UserType UserType
        {
            get
            { return this.userType; }
        }

        public CommonUserLogin()
        {
        }

        public CommonUserLogin(string UserID, string UserInitials, CommonEnum.UserType UserType, ArrayList menu, string SupplierID)
        {
            userID = UserID;
            userInitials = UserInitials;
            userType = UserType;
            menuList = menu;
            supplierID = SupplierID;
            //setMenuItems();
        }

        #region Developer Designed method

        public static CommonUserLogin getUser()
        {
            if (isUserLoggedIn())
                return ((CommonUserLogin)Thread.GetData(Thread.GetNamedDataSlot("Login")));
            else
                return new CommonUserLogin();
        }

        private static bool isUserLoggedIn()
        {
            return (Thread.GetData(Thread.GetNamedDataSlot("Login")) != null);
        }        
        #endregion

    }
}
