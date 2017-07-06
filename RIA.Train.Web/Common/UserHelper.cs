using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Common
{
    public class UserHelper
    {
        public static ILogger Logger { get; set; }

        private static readonly UserHelper _userHelper = new UserHelper();

        public static UserHelper Instance
        {
            get { return _userHelper; }
        }

        public UserHelper()
        {
            Logger = NullLogger.Instance;
        }

        public string getCookie()
        {
            var cookie = HttpContext.Current.Request.Cookies[Common.AbpWebConst.AuthSaveKey];
            string token = cookie.Value;
            var strTicket = Common.DESEncryptEx.Decrypt(token);
            return strTicket;
        }

        public int getUserId()
        {
            Logger.Debug("当前token" + Common.AbpWebConst.AuthSaveKey);
            var cookie = HttpContext.Current.Request.Cookies[Common.AbpWebConst.AuthSaveKey];
            //解密Ticket
            if (cookie != null)
            {
                string token = cookie.Value;
                Logger.Debug("当前token" + token);
                //var strTicket = FormsAuthentication.Decrypt(token).UserData;
                //Logger.Debug("当前strTicket" + strTicket);
                //if (!string.IsNullOrEmpty(strTicket))
                //{
                //    int userId = int.Parse(strTicket.Split('|')[0]);
                //    return userId;
                //}
                var strTicket = Common.DESEncryptEx.Decrypt(token);
                if (!string.IsNullOrEmpty(strTicket))
                {
                    int userId = int.Parse(strTicket.Split('|')[0]);
                    return userId;
                }
            }
            else
            {
                Logger.Debug("未获取到cookie" + Common.AbpWebConst.AuthSaveKey);
            }
            return 5;
        }

        public string getUserName()
        {
            Logger.Debug("当前token" + Common.AbpWebConst.AuthSaveKey);
            var cookie = HttpContext.Current.Request.Cookies[Common.AbpWebConst.AuthSaveKey];
            //解密Ticket
            if (cookie != null)
            {
                string token = cookie.Value;
                Logger.Debug("当前token" + token);
                //var strTicket = FormsAuthentication.Decrypt(token).UserData;
                //Logger.Debug("当前strTicket" + strTicket);
                //if (!string.IsNullOrEmpty(strTicket))
                //{
                //    int userId = int.Parse(strTicket.Split('|')[0]);
                //    return userId;
                //}
                var strTicket = Common.DESEncryptEx.Decrypt(token);
                if (!string.IsNullOrEmpty(strTicket))
                {
                    return strTicket.Split('|')[2];
                     ;
                }
            }
            else
            {
                Logger.Debug("未获取到cookie" + Common.AbpWebConst.AuthSaveKey);
            }
            return "admin";
        }

        public string[] getAccessToken()
        {
            var cookie = HttpContext.Current.Request.Cookies[AbpWebConst.AuthSaveKey];
            //解密Ticket
            string token = cookie.Value;
            //var strTicket = FormsAuthentication.Decrypt(token).UserData;
            //if (!string.IsNullOrEmpty(strTicket))
            //{
            //    return strTicket.Split('|');

            //}
            var strTicket = Common.DESEncryptEx.Decrypt(token);
            if (!string.IsNullOrEmpty(strTicket))
            {
                return strTicket.Split('|');
            }
            return null;
        }
    }
}