﻿using RIA.Train.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIA.Train.Web.Controllers
{
    public class WeChatLoginController : TrainControllerBase
    {
        private readonly string AppID = Common.AbpWebConst.AppID;
        private readonly string AppSecret = Common.AbpWebConst.AppSecret;  //29cad2671f79f1899517569acce74210
        private readonly string redirectUrl = Common.AbpWebConst.RedirectUrl;
        // GET: WeChatLogin


        readonly IT_UserAppService userAppService;

        public WeChatLoginController(IT_UserAppService iUserAppService)
        {
            userAppService = iUserAppService;
        }
        public ActionResult Index()
        {
            //string code = Request.QueryString["code"] ?? "";
            //string retUrl = Request.QueryString["retUrl"] ?? "";
            //string redirectToUrl = string.Format("{0}?retUrl={1}", redirectUrl, retUrl);
            //#region pc测试注释

            //////微信用户信息授权
            //string openurl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect", AppID, redirectToUrl);
            //if (string.IsNullOrWhiteSpace(code))
            //{
            //    Response.Redirect(openurl);
            //}
            //else
            //{
            //    Logger.Debug("url:" + retUrl);
            //    Dictionary<string, string> rst = new Dictionary<string, string>();
            //    try
            //    {
            //        rst = Senparc.Weixin.HttpUtility.Get.GetJson<Dictionary<string, string>>(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppID, AppSecret, code));
            //    }
            //    catch (Exception e)
            //    {

            //    }
            //    if (rst.Count >= 1)
            //    {

            //        string accessToken;
            //        if (!rst.TryGetValue("access_token", out accessToken))
            //        { }
            //        var opentid = rst["openid"];
            //        var url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
            //        var userInfo = Senparc.Weixin.HttpUtility.Get.GetJson<Models.WeiXinUserInfo>(url);
            //        if (userInfo != null)
            //        {
            //            ViewBag.OpenId = opentid;
            //            ViewBag.accessToken = accessToken;
            //            ViewBag.retUrl = retUrl;
            //            ViewBag.HeadImgUrl = userInfo.headimgurl;
            //            ViewBag.NickName = userInfo.nickname;

            //            Logger.Debug("OpenId:" + opentid);
            //            Logger.Debug("accessToken:" + accessToken);
            //            Logger.Debug("retUrl:" + retUrl);
            //            Logger.Debug("headimgurl:" + userInfo.headimgurl);
            //            Logger.Debug("nickname:" + userInfo.nickname);
            //        }

            //        #endregion
            //        #region pc测试使用

            //        //ViewBag.OpenId = "oCbECv1pwMNyAodYQtRJVvJf_Zsg";
            //        //ViewBag.accessToken = "_HuO-csbnk2084EDPvhr2h0x2mwhB-mxYKXjFYMSG0P2ErgtdPBMPx0wIoO8qB9BWuO6ZFkL8U0XyEDB2hyLzxcx5Fjmm4ftCCEtpuzy92M";
            //        //ViewBag.retUrl = "http://weixin.shoushouto.com/User/Index?type=1";
            //        //ViewBag.HeadImgUrl = "http://wx.qlogo.cn/mmopen/HtEJHGuES1WyonHaXDQRxe9iaKS8kIelY6WOOCibZOzrjInMOcZZP6kr5R5cH54NicJguZaqzz32Eic9Kyz8VpT0zA/0";
            //        //ViewBag.NickName = "aaa";
            //        #endregion

            //    }
            //}
            return View();
        }

        [HttpPost]
        public JsonResult LoginValidate(Models.WeiXinInfo userInfo)
        {
            var user = this.userAppService.GetT_UserByOpenIdAsync(userInfo.OpenId);
            Models.JsonResultStatus rstJson = new Models.JsonResultStatus();
            rstJson.Code = 200;
            // var user = this.weUserAppService.GetWeUser("oCbECv1pwMNyAodYQtRJVvJf_Zsg");
            if (user == null)
            {
                
                rstJson.Msg = "未绑定工资号,即将跳转到绑定页面";
                // string regUrl = string.Format("/RegisterWeChat/Index?openId={0}&HeadImgUrl={1}&NickName={2}&retUrl=", userInfo.OpenId, userInfo.HeadImgUrl, userInfo.NickName, userInfo.RetUrl);
                // rstJson.RedirectUrl = regUrl;
                rstJson.RedirectUrl = userInfo.RetUrl;
                return Json(rstJson);
            }
            else
            {
              

                string encrtpt = Common.DESEncryptEx.Encrypt(string.Format("{0}|{1}|{2}", user.Id,  userInfo.AccessToken, userInfo.OpenId));
                Logger.Debug("当前用户Cookie" + encrtpt);
                //        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                //1,
                //user.NickName,
                //DateTime.Now,
                //DateTime.Now.Add(FormsAuthentication.Timeout), true, string.Format("{0}|{1}|{2}|{3}|{4}", user.Id, user.PhoneNo, user.NickName, accessToken, opentid)

                //);

                //DateTime.Now.Add(FormsAuthentication.Timeout), true, string.Format("{0}|{1}|{2}|{3}|{4}", user.Id, user.PhoneNo, user.NickName, accessToken, openId)
                //HttpCookie cookie = new HttpCookie(
                //    Common.CommonConst.AuthSaveKey,
                //    FormsAuthentication.Encrypt(ticket));
                HttpCookie cookie = new HttpCookie(
                    Common.AbpWebConst.AuthSaveKey,
                    encrtpt);
                Response.Cookies.Add(cookie);
                rstJson.Msg = "用户验证成功，即将跳转";
                rstJson.RedirectUrl = userInfo.RetUrl;
                return Json(rstJson);

            }
        }
    }
}