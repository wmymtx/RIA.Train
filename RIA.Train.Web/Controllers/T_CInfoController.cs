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
    public class T_CInfoController : TrainControllerBase
    {
        // GET: T_CInfo
        private readonly IT_CInfoAppService _t_CInfoAppService;

        public T_CInfoController(IT_CInfoAppService t_CInfoAppService)
        {
            _t_CInfoAppService = t_CInfoAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_CInfoInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      //  [AbpMvcAuthorize(T_CInfoAppPermissions.T_CInfo_CreateT_CInfo, T_CInfoAppPermissions.T_CInfo_EditT_CInfo)]
        public async Task<PartialViewResult> CreateOrEditT_CInfoModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_CInfoAppService.GetT_CInfoForEditAsync(input);

            var viewModel = new CreateOrEditT_CInfoModalViewModel(output);


            return PartialView("_CreateOrEditT_CInfoModal", viewModel);
        }

    }
}