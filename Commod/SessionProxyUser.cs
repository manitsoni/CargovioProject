using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Common
{

    public class SessionProxyUser
    {
        #region Constants
        //User
        public const string USERID = "UserId";
        public const string USERTYPEID = "Usertypeid";
        // public const string USERNAME = "UserName";
        public const string NAME = "Name";
        public const string FIRSTNAME = "FirstName";
        public const string MIDDLENAME = "MiddleName";
        public const string LASTNAME = "LastName";
        public const string ISUSERLOGIN = "IsUserLogin";
        public const string USERTYPE = "UserType";
        public const string USERSTATUS = "UserStatus";
        public const string USEREMAIL = "UserEmail";
        //    public const string APPTYPE = "AppType";
        public const string USERPHOTOID = "Photo";
        public const string ADDRESS1 = "AddressLine1";
        public const string ADDRESS2 = "AddressLine2";
        public const string CITY = "City";
        public const string STATE = "State";
        public const string COUNTRY = "Country";
        public const string PHONE = "Phone";
        public const string PINCODE = "Pincode";
        public const string ADHAAR = "Adhaar";
        public const string VendorID = "Vendorid";
        public const string ProductId = "ProductId";
        //Application
        //   public const string APPNAME = "AppName";
        #endregion

        #region Properties

        private SessionProxyUser()
        {

        }

        public static SessionProxyUser Current
        {
            get
            {
                SessionProxyUser sessionProxy = (SessionProxyUser)HttpContent.Current.Session["__ApplicationSessionAdmin__"];
                if (sessionProxy == null)
                {
                    sessionProxy = new SessionProxyUser();
                    HttpContext.Current.Session["__ApplicationSessionAdmin__"] = sessionProxy;
                }
                return sessionProxy;
            }
            set { SessionProxyUser mysession = (SessionProxyUser)value; }
        }

        #region User

        public static int UserID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[USERID]);
            }
            set
            {
                HttpContext.Current.Session[USERID] = value;
            }
        }
        public static int VendorId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[VendorID]);
            }
            set
            {
                HttpContext.Current.Session[VendorID] = value;
            }
        }
        public static int ProductID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[ProductId]);
            }
            set
            {
                HttpContext.Current.Session[ProductId] = value;
            }
        }
        public static string FirstName
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[FIRSTNAME]);
            }
            set
            {
                HttpContext.Current.Session[FIRSTNAME] = value;
            }
        }
        public static int UserTypeid
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[USERTYPEID]);
            }
            set
            {
                HttpContext.Current.Session[USERTYPEID] = value;
            }
        }

        //public static string UserName
        //{
        //    get
        //    {
        //        return Convert.ToString(HttpContext.Current.Session[USERNAME]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[USERNAME] = value;
        //    }
        //}

        public static bool IsUserLogin
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session[ISUSERLOGIN]);
            }
            set
            {
                HttpContext.Current.Session[ISUSERLOGIN] = value;
            }
        }

        public static string UserType
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[USERTYPE]);
            }
            set
            {
                HttpContext.Current.Session[USERTYPE] = value;
            }
        }

        public static string UserStatus
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[USERTYPE]);
            }
            set
            {
                HttpContext.Current.Session[USERSTATUS] = value;
            }
        }
        public static string MiddleName
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[MIDDLENAME]);
            }
            set
            {
                HttpContext.Current.Session[MIDDLENAME] = value;
            }
        }
        public static string LastName
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[LASTNAME]);
            }
            set
            {
                HttpContext.Current.Session[USERSTATUS] = value;
            }
        }

        public static string Name
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[NAME]);
            }
            set
            {
                HttpContext.Current.Session[NAME] = value;
            }
        }

        public static string UserEmail
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[USEREMAIL]);
            }
            set
            {
                HttpContext.Current.Session[USEREMAIL] = value;
            }
        }
        public static string Address1
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[ADDRESS1]);
            }
            set
            {
                HttpContext.Current.Session[ADDRESS1] = value;
            }
        }
        public static string Address2
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[ADDRESS2]);
            }
            set
            {
                HttpContext.Current.Session[ADDRESS2] = value;
            }
        }
        public static string City
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[CITY]);
            }
            set
            {
                HttpContext.Current.Session[CITY] = value;
            }
        }
        public static string State
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[STATE]);
            }
            set
            {
                HttpContext.Current.Session[STATE] = value;
            }
        }
        public static string Country
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[COUNTRY]);
            }
            set
            {
                HttpContext.Current.Session[COUNTRY] = value;
            }
        }
        public static string Phone
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[PHONE]);
            }
            set
            {
                HttpContext.Current.Session[PHONE] = value;
            }
        }
        public static string Pincode
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[PINCODE]);
            }
            set
            {
                HttpContext.Current.Session[PINCODE] = value;
            }
        }
        public static string Adhaar
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[ADHAAR]);
            }
            set
            {
                HttpContext.Current.Session[ADHAAR] = value;
            }
        }

        public static string Photo { get; set; }

        //public static string Apptype
        //{
        //    get
        //    {
        //        return Convert.ToString(HttpContext.Current.Session[APPTYPE]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[APPTYPE] = value;
        //    }
        //}


        #endregion

        #region Application
        //public static string AppName
        //{
        //    get
        //    {
        //        return Convert.ToString(HttpContext.Current.Session[APPNAME]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[APPNAME] = value;
        //    }
        //}
        #endregion
        #endregion
    }
}
