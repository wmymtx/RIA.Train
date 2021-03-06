﻿using Abp.Application.Services.Dto;
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
    public class T_StaffController : TrainControllerBase
    {
        // GET: T_Staff
        private readonly IT_StaffAppService _t_StaffAppService;

        public T_StaffController(IT_StaffAppService t_StaffAppService)
        {
            _t_StaffAppService = t_StaffAppService;

        }

        public ActionResult Index()
        {
            var model = new GetT_StaffInput { FilterText = Request.QueryString["filterText"] };
            return View(model);




        }



        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [AbpMvcAuthorize(T_StaffAppPermissions.T_Staff_CreateT_Staff, T_StaffAppPermissions.T_Staff_EditT_Staff)]
        public async Task<PartialViewResult> CreateOrEditT_StaffModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            //var output = await _t_StaffAppService.GetT_StaffForEditAsync(input);

            GetT_StaffForEditOutput output = null;

            if (input.Id > 100000)
            {
                output = new GetT_StaffForEditOutput();
                var parentId = int.Parse(input.Id.ToString().Substring(6));
                output.T_Staff = new T_StaffEditDto();
                output.T_Staff.FK_Staff_GroupId = parentId;

            }
            else
            {
                output = await _t_StaffAppService.GetT_StaffForEditAsync(input);
            }

            var viewModel = new CreateOrEditT_StaffModalViewModel(output);


            return PartialView("_CreateOrEditT_StaffModal", viewModel);
        }


        public  PartialViewResult SelectStaffModal(int? id)
        {
            var input = new NullableIdDto<int> { Id = id };

            //var output = await _t_StaffAppService.GetT_StaffForEditAsync(input);
            SelectStaffModel viewModel = new SelectStaffModel() { Id = int.Parse(input.Id.ToString()) };


            //var viewModel = new CreateOrEditT_StaffModalViewModel(output);


            return PartialView("SelectStaffModal", viewModel);
        }

    }
}