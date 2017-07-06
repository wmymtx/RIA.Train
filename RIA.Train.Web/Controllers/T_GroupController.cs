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
    public class T_GroupController : TrainControllerBase
    {

        private readonly IT_GroupAppService _t_GroupAppService;

        public T_GroupController(IT_GroupAppService t_GroupAppService)
        {
            _t_GroupAppService = t_GroupAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_GroupInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [AbpMvcAuthorize(T_GroupAppPermissions.T_Group_CreateT_Group, T_GroupAppPermissions.T_Group_EditT_Group)]
        public async Task<PartialViewResult> CreateOrEditT_GroupModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            GetT_GroupForEditOutput output = null;

            if (input.Id > 100000)
            {
                output = new GetT_GroupForEditOutput();
                var parentId = int.Parse(input.Id.ToString().Substring(6));
                output.T_Group = new T_GroupEditDto();
                output.T_Group.ParentId = parentId;

            }
            else
            {
                output = await _t_GroupAppService.GetT_GroupForEditAsync(input);
            }

            var viewModel = new CreateOrEditT_GroupModalViewModel(output);


            return PartialView("_CreateOrEditT_GroupModal", viewModel);
        }


    }
}