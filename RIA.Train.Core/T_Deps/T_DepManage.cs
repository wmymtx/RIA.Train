// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T22:00:04. All Rights Reserved.
//<生成时间>2017-05-21T22:00:04</生成时间>
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using RIA.Train.Entities;
using System;

namespace RIA.Train.Core
{
    /// <summary>
    /// 部门表业务管理
    /// </summary>
    public class T_DepManage : IDomainService
    {
        private readonly IRepository<T_Dep,int> _t_DepRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public T_DepManage(IRepository<T_Dep,int> t_DepRepository  )
        {
            _t_DepRepository = t_DepRepository;
        }

		//TODO:编写领域业务代码


		/// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {


 

        }


		}

    
	
}
