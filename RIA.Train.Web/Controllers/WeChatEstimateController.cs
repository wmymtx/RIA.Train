using Abp.Application.Services.Dto;
using RIA.Train.Application;
using RIA.Train.Application.Dtos;
using RIA.Train.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIA.Train.Web.Controllers
{
    [Common.WeChatAuthorization]
    public class WeChatEstimateController : Controller
    {
        readonly IT_ContentAppService t_contentAppServie;
        readonly IT_GradeAppService t_gradeAppService;
        readonly IT_ClassAppService t_classAppService;
        readonly IT_HClassAppService t_hClassAppService;
        readonly IT_Estimate_DetailAppService detailAppService;
        readonly IT_EstimateAppService estimateAppService;
        public WeChatEstimateController(IT_ContentAppService _t_contentAppServie, IT_GradeAppService _t_gradeAppService, IT_ClassAppService _t_classAppService,
            IT_Estimate_DetailAppService _detailAppService,
            IT_EstimateAppService _estimateAppService,
        IT_HClassAppService _t_hClassAppService)
        {
            detailAppService = _detailAppService;
            estimateAppService = _estimateAppService;
            t_contentAppServie = _t_contentAppServie;
            t_gradeAppService = _t_gradeAppService;
            t_classAppService = _t_classAppService;
            t_hClassAppService = _t_hClassAppService;
        }
        // GET: WeChatEstimate
        public ActionResult Index(EntityDto<int> input)
        {
            var entity = t_hClassAppService.IsJoinClass(input.Id, Common.UserHelper.Instance.getUserId());
            if (entity == null || string.IsNullOrEmpty(entity.UserName))
            {
                return View("Error");
            }
            else
            {
                ViewBag.Contents = t_contentAppServie.GetT_Contents();
                ViewBag.ClassInfo = t_classAppService.GetT_ClassById(input);
                ViewBag.Grades = t_gradeAppService.GetT_Grades();
                return View();
            }
        }

        public JsonResult CommitTrain(ListCommitTrain input)
        {
            var entity = estimateAppService.GetT_EstimateById(input.CommitTrain[0].FK_ClassId);
            if (entity != null && entity.Count >= 1)
            {
                int index = 0;
                foreach (var item in input.CommitTrain)
                {
                    var itemEntity = detailAppService.GetT_Estima_DetailteById(int.Parse(entity[index].Id.ToString()), Common.UserHelper.Instance.getUserId());
                    if (itemEntity != null)
                    {
                        return Json(new { Msg = "已评价过", Code = 400 });
                    }
                    else
                    {
                        var eItem = entity.FirstOrDefault(o => o.FK_ClassId == item.FK_ClassId && o.FK_ContentId == item.FK_ContentId && o.FK_GradeId == item.FK_GradeId);
                        if (eItem != null && eItem.ContentCount >= 1)
                        {

                            eItem.ContentCount = eItem.ContentCount + 1;
                            estimateAppService.UpdateEstimate(eItem);

                            T_Estimate_DetailEditDto des = new T_Estimate_DetailEditDto();
                            des.FK_EstimateId = int.Parse(eItem.Id.ToString());
                            des.FK_UserId = Common.UserHelper.Instance.getUserId();
                            des.CreateTime = DateTime.Now;

                            detailAppService.CreateEstimate_Detail(des);
                        }
                        else
                        {
                            T_EstimateEditDto es = new T_EstimateEditDto();
                            es.FK_ClassId = item.FK_ClassId;
                            es.FK_ContentId = item.FK_ContentId;
                            es.FK_GradeId = item.FK_GradeId;
                            es.ContentCount = 1;
                            var rst = estimateAppService.CreateEstimate(es);

                            T_Estimate_DetailEditDto des = new T_Estimate_DetailEditDto();
                            des.FK_EstimateId = int.Parse(rst.Id.ToString());
                            des.FK_UserId = Common.UserHelper.Instance.getUserId();
                            des.CreateTime = DateTime.Now;

                            detailAppService.CreateEstimate_Detail(des);
                        }
                    }
                }
                return Json(new { Msg = "评价成功", Code = 400 });
            }
            else
            {
                foreach (var item in input.CommitTrain)
                {
                    T_EstimateEditDto es = new T_EstimateEditDto();
                    es.FK_ClassId = item.FK_ClassId;
                    es.FK_ContentId = item.FK_ContentId;
                    es.FK_GradeId = item.FK_GradeId;
                    es.ContentCount = 1;
                    var rst = estimateAppService.CreateEstimate(es);

                    T_Estimate_DetailEditDto des = new T_Estimate_DetailEditDto();
                    des.FK_EstimateId = int.Parse(rst.Id.ToString());
                    des.FK_UserId = Common.UserHelper.Instance.getUserId();
                    des.CreateTime = DateTime.Now;

                    detailAppService.CreateEstimate_Detail(des);
                }
                return Json(new { Msg = "评价成功", Code = 400 });
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}