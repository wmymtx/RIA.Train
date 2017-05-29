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
    public class T_ContentController : TrainControllerBase
    {
        // GET: T_Content
        private readonly IT_ContentAppService _t_ContentAppService;

        public T_ContentController(IT_ContentAppService t_ContentAppService)
        {
            _t_ContentAppService = t_ContentAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_ContentInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(T_ContentAppPermissions.T_Content_CreateT_Content, T_ContentAppPermissions.T_Content_EditT_Content)]
        public async Task<PartialViewResult> CreateOrEditT_ContentModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_ContentAppService.GetT_ContentForEditAsync(input);

            var viewModel = new CreateOrEditT_ContentModalViewModel(output);


            return PartialView("_CreateOrEditT_ContentModal", viewModel);
        }

    }
}