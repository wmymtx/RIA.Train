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
    public class T_ItemController : TrainControllerBase
    {
        // GET: T_Item
        private readonly IT_ItemAppService _t_ItemAppService;

        public T_ItemController(IT_ItemAppService t_ItemAppService)
        {
            _t_ItemAppService = t_ItemAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_ItemInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [AbpMvcAuthorize(T_ItemAppPermissions.T_Item_CreateT_Item, T_ItemAppPermissions.T_Item_EditT_Item)]
        public async Task<PartialViewResult> CreateOrEditT_ItemModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            var output = await _t_ItemAppService.GetT_ItemForEditAsync(input);

            var viewModel = new CreateOrEditT_ItemModalViewModel(output);


            return PartialView("_CreateOrEditT_ItemModal", viewModel);
        }

        public  PartialViewResult ShowT_ItemModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            SelectStaffModel viewModel = new SelectStaffModel() { Id = int.Parse(input.Id.ToString()) };

            //var viewModel = new CreateOrEditT_ItemModalViewModel(output);


            return PartialView("ShowT_ItemModal", viewModel);
        }
    }
}