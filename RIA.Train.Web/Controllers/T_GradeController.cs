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
    [AbpMvcAuthorize]
    public class T_GradeController : TrainControllerBase
    {
        // GET: T_Grade
        private readonly IT_GradeAppService _t_GradeAppService;

        public T_GradeController(IT_GradeAppService t_GradeAppService)
        {
            _t_GradeAppService = t_GradeAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_GradeInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[AbpMvcAuthorize(T_GradeAppPermissions.T_Grade_CreateT_Grade, T_GradeAppPermissions.T_Grade_EditT_Grade)]
        public async Task<PartialViewResult> CreateOrEditT_GradeModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_GradeAppService.GetT_GradeForEditAsync(input);

            var viewModel = new CreateOrEditT_GradeModalViewModel(output);


            return PartialView("_CreateOrEditT_GradeModal", viewModel);
        }
    }
}