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
    public class T_ClassController : TrainControllerBase
    {
        // GET: T_Class
        private readonly IT_ClassAppService _t_ClassAppService;

        public T_ClassController(IT_ClassAppService t_ClassAppService)
        {
            _t_ClassAppService = t_ClassAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_ClassInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[AbpMvcAuthorize(T_ClassAppPermissions.T_Class_CreateT_Class, T_ClassAppPermissions.T_Class_EditT_Class)]
        public async Task<PartialViewResult> CreateOrEditT_ClassModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };
            GetT_ClassForEditOutput output = null;

            if (input.Id > 100000)
            {
                output = new GetT_ClassForEditOutput();
                var parentId = int.Parse(input.Id.ToString().Substring(6));
                output.T_Class = new T_ClassEditDto();
                output.T_Class.Fk_Id = parentId;

            }
            else
            {

                output = await _t_ClassAppService.GetT_ClassForEditAsync(input);
            }
            var viewModel = new CreateOrEditT_ClassModalViewModel(output);


            return PartialView("_CreateOrEditT_ClassModal", viewModel);
        }

        public PartialViewResult SelectStaff_ClassModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            //var output = await _t_StaffAppService.GetT_StaffForEditAsync(input);
            SelectStaffModel viewModel = new SelectStaffModel() { Id = int.Parse(input.Id.ToString()) };


            //var viewModel = new CreateOrEditT_StaffModalViewModel(output);


            return PartialView("SelectStaff_ClassModal", viewModel);
        }

        public PartialViewResult ShowT_HClassModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            SelectStaffModel viewModel = new SelectStaffModel() { Id = int.Parse(input.Id.ToString()) };

           // var viewModel = new CreateOrEditT_ItemModalViewModel(output);


            return PartialView("ShowT_HClassModal", viewModel);
        }
    }
}