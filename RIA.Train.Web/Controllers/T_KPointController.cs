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
    public class T_KPointController : TrainControllerBase
    {
        // GET: T_KPoint
        private readonly IT_KPointAppService _t_KPointAppService;

        public T_KPointController(IT_KPointAppService t_KPointAppService)
        {
            _t_KPointAppService = t_KPointAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_KPointInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(T_KPointAppPermissions.T_KPoint_CreateT_KPoint, T_KPointAppPermissions.T_KPoint_EditT_KPoint)]
        public async Task<PartialViewResult> CreateOrEditT_KPointModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_KPointAppService.GetT_KPointForEditAsync(input);

            var viewModel = new CreateOrEditT_KPointModalViewModel(output);


            return PartialView("_CreateOrEditT_KPointModal", viewModel);
        }
    }
}