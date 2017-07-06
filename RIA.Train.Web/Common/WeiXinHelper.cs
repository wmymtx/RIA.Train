using RIA.Train.Web.Models;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Common
{
    public class WeiXinHelper
    {
        public static void SendMsgToWeUser(string access_token, string openId, string orderId, OrderTemplateData templateData)
        {
            var linkUrl = string.Format("http://weixin.shoushouto.com/Order/Detail?orderId={0}", orderId);
            SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, AbpWebConst.TemplateId, linkUrl, templateData);
        }

        public static void SendTemplateToWeUser(string access_token, string openId, string orderId, OrderTemplateData templateData)
        {
            var linkUrl = string.Format("http://weixin.shoushouto.com/Order/Detail?orderId={0}", orderId);
            SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, "cogrr5tjx2GK_FGqFj1ty5A0Q1I80iIjyTOpkQlU-Qk", linkUrl, templateData);
        }

        public static void SendSimpleMsg(string access_token, string openId, string msg)
        {
            Senparc.Weixin.MP.AdvancedAPIs.CustomApi.SendText(access_token, openId, msg);
        }
    }
}