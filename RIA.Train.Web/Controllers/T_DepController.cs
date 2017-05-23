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
    public class T_DepController: TrainControllerBase
    {
        private readonly IT_DepAppService _t_DepAppService;

        public T_DepController(IT_DepAppService t_DepAppService)
        {
            _t_DepAppService = t_DepAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_DepInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(T_DepAppPermissions.T_Dep_CreateT_Dep, T_DepAppPermissions.T_Dep_EditT_Dep)]
        public async Task<PartialViewResult> CreateOrEditT_DepModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_DepAppService.GetT_DepForEditAsync(input);

            var viewModel = new CreateOrEditT_DepModalViewModel(output);


            return PartialView("_CreateOrEditT_DepModal", viewModel);
        }
    }
}