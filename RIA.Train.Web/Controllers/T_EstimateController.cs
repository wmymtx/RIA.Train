using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using RIA.Train.Application;
using RIA.Train.Application.Dtos;
using RIA.Train.Core.Authorization;
using RIA.Train.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RIA.Train.Web.Controllers
{
    public class T_EstimateController : TrainControllerBase
    {
        // GET: T_Estimate
        private readonly IT_EstimateAppService _t_EstimateAppService;

        public T_EstimateController(IT_EstimateAppService t_EstimateAppService)
        {
            _t_EstimateAppService = t_EstimateAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_EstimateInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(T_EstimateAppPermissions.T_Estimate_CreateT_Estimate, T_EstimateAppPermissions.T_Estimate_EditT_Estimate)]
        public async Task<PartialViewResult> CreateOrEditT_EstimateModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_EstimateAppService.GetT_EstimateForEditAsync(input);

            var viewModel = new CreateOrEditT_EstimateModalViewModel(output);


            return PartialView("_CreateOrEditT_EstimateModal", viewModel);
        }
    }
}