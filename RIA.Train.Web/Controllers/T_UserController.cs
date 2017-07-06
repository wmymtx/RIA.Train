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
    public class T_UserController : TrainControllerBase
    {
        // GET: T_User
        private readonly IT_UserAppService _t_UserAppService;

        public T_UserController(IT_UserAppService t_UserAppService)
        {
            _t_UserAppService = t_UserAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_UserInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      //  [AbpMvcAuthorize(T_UserAppPermissions.T_User_CreateT_User, T_UserAppPermissions.T_User_EditT_User)]
        public async Task<PartialViewResult> CreateOrEditT_UserModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_UserAppService.GetT_UserForEditAsync(input);

            var viewModel = new CreateOrEditT_UserModalViewModel(output);


            return PartialView("_CreateOrEditT_UserModal", viewModel);
        }
    }
}