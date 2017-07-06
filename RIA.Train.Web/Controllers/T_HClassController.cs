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
    public class T_HClassController : TrainControllerBase
    {
        // GET: T_HClass
        private readonly IT_HClassAppService _t_HClassAppService;

        public T_HClassController(IT_HClassAppService t_HClassAppService)
        {
            _t_HClassAppService = t_HClassAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_HClassInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      //  [AbpMvcAuthorize(T_HClassAppPermissions.T_HClass_CreateT_HClass, T_HClassAppPermissions.T_HClass_EditT_HClass)]
        public async Task<PartialViewResult> CreateOrEditT_HClassModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_HClassAppService.GetT_HClassForEditAsync(input);

            var viewModel = new CreateOrEditT_HClassModalViewModel(output);


            return PartialView("_CreateOrEditT_HClassModal", viewModel);
        }
    }
}