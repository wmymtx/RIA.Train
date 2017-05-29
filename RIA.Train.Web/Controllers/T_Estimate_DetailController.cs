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
    public class T_Estimate_DetailController : TrainControllerBase
    {
        // GET: T_Estimate_Detail
        private readonly IT_Estimate_DetailAppService _t_Estimate_DetailAppService;

        public T_Estimate_DetailController(IT_Estimate_DetailAppService t_Estimate_DetailAppService)
        {
            _t_Estimate_DetailAppService = t_Estimate_DetailAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_Estimate_DetailInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail_CreateT_Estimate_Detail, T_Estimate_DetailAppPermissions.T_Estimate_Detail_EditT_Estimate_Detail)]
        public async Task<PartialViewResult> CreateOrEditT_Estimate_DetailModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_Estimate_DetailAppService.GetT_Estimate_DetailForEditAsync(input);

            var viewModel = new CreateOrEditT_Estimate_DetailModalViewModel(output);


            return PartialView("_CreateOrEditT_Estimate_DetailModal", viewModel);
        }
    }
}