using RIA.Train.Application;
using RIA.Train.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RIA.Train.Web.Controllers
{
    public class WeChatBindUserController : TrainControllerBase
    {
        // GET: WeChatBindUser
        readonly IT_UserAppService t_userAppService;
        readonly IT_StaffAppService staffAppService;
        public WeChatBindUserController(IT_UserAppService iT_UserAppService, IT_StaffAppService iStaffAppService)
        {
            t_userAppService = iT_UserAppService;
            staffAppService = iStaffAppService;
        }

        public ActionResult Index(string retUrl)
        {
            ViewBag.OpenId = "";
            ViewBag.retUrl = retUrl;
            return View();
        }


        public ActionResult ModifyPwd(string retUrl)
        {
            ViewBag.retUrl = retUrl;
            return View();
        }

        public JsonResult PwdModify(T_UserModifyDto inputDto)
        {
            if (inputDto.NewPassword != inputDto.ReNewPassword)
            {
                return Json(new { Msg = "两次密码不一致!", Code = 400 });
            }

            if (t_userAppService.ModifyPwd(inputDto))
            {
                return Json(new { Msg = "修改失败!", Code = 400 });
            }
            return Json(new { Msg = "修改成功!", Code = 200 });
        }
        public JsonResult Register(Application.Dtos.T_Staff_LoginDto input)
        {
            Models.JsonResultStatus jsonStatus = new Models.JsonResultStatus();
            jsonStatus.Code = 200;
            if (input.LoginNo <= 0)
            {
                jsonStatus.Code = 400;
                jsonStatus.Msg = "未获取到工资号";
            }
            else
            {
                //await t_userAppService.BindWeChat(input);
                var entity = staffAppService.ValidateUser(input.LoginNo, input.Password);
                if (entity != null)
                {
                    string encrtpt = Common.DESEncryptEx.Encrypt(string.Format("{0}|{1}|{2}", entity.Id, entity.LoginNo, entity.StaffName));
                    HttpCookie cookie = new HttpCookie(
                   Common.AbpWebConst.AuthSaveKey,
                   encrtpt);
                    Response.Cookies.Add(cookie);
                    jsonStatus.Msg = "登陆成功";
                    jsonStatus.RedirectUrl = "";
                }
                else
                {
                    jsonStatus.Code = 400;
                    jsonStatus.Msg = "登陆失败";
                }


            }
            return Json(jsonStatus);
        }
    }
}