using Abp.Application.Services.Dto;
using RIA.Train.Application;
using RIA.Train.Application.Dtos;
using RIA.Train.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RIA.Train.Web.Controllers
{
    [Common.WeChatAuthorization]
    public class WeChatRequireController : Controller
    {
        readonly IT_ItemAppService i_itemAppService;
        readonly IT_RequireAppService requireAppService;
        readonly IT_CInfoAppService iCinfoAppService;

        public WeChatRequireController(IT_ItemAppService itemAppService, IT_RequireAppService iRequireAppService, IT_CInfoAppService _iCinfoAppService)
        {
            i_itemAppService = itemAppService;
            requireAppService = iRequireAppService;
            iCinfoAppService = _iCinfoAppService;
        }
        // GET: WeChatRequire
        public ActionResult Index()
        {

            //var entity = iCinfoAppService.IsJoinItem(id, Common.UserHelper.Instance.getUserId());
            //if (entity == null || string.IsNullOrEmpty(entity.UserName))
            //{
            //    return View("Error");
            //}
            //else
            {
                //var input = new NullableIdDto<int> { Id = id };
                var itemList = requireAppService.GetJoinItem(Common.UserHelper.Instance.getUserId());
                // var output = i_itemAppService.GetT_ItemById(id);
                ViewBag.itemList = itemList;
                //ViewBag.itemInfo = output;
                return View();
            }
        }

        public JsonResult GetDetail(int id)
        {
            var output = i_itemAppService.GetT_ItemById(id);
            List<T_KPoint> lstPoint = new List<T_KPoint>();
            for (int index = 0; index <= output.T_KPoints.Count - 1; index++)
            {
                lstPoint.Add(new T_KPoint() { TrainContent = output.T_KPoints[index].TrainContent });
            }
            //lstPoint = output.T_KPoints;
            return Json(lstPoint);
        }

        public ActionResult Error()
        {
            return View();
        }

        public async Task<JsonResult> CommitContent(CreateOrUpdateT_RequireInput input)
        {
            // input.T_RequireEditDto.Fk_Require_UserId = Common.UserHelper.Instance.getUserId();
            foreach (var item in input.T_RequireEditDto)
            {
                item.UserName = Common.UserHelper.Instance.getUserName();
                item.Fk_Require_UserId = Common.UserHelper.Instance.getUserId();
            }

            await requireAppService.CreateOrUpdateT_RequireAsync(input);
            return Json(new { Msg = "提交成功" });
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}