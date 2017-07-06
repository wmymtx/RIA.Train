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
    public class T_RequireController : TrainControllerBase
    {
        // GET: T_Require
        private readonly IT_RequireAppService _t_RequireAppService;

        public T_RequireController(IT_RequireAppService t_RequireAppService)
        {
            _t_RequireAppService = t_RequireAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_RequireInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [AbpMvcAuthorize(T_RequireAppPermissions.T_Require_CreateT_Require, T_RequireAppPermissions.T_Require_EditT_Require)]
        public async Task<PartialViewResult> CreateOrEditT_RequireModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_RequireAppService.GetT_RequireForEditAsync(input);

            var viewModel = new CreateOrEditT_RequireModalViewModel(output);


            return PartialView("_CreateOrEditT_RequireModal", viewModel);
        }
    }
}