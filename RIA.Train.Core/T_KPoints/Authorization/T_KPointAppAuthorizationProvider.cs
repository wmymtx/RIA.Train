﻿  
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:44:50. All Rights Reserved.
//<生成时间>2017-05-25T22:44:50</生成时间>
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using RIA.Train.Authorization;

namespace RIA.Train.Core.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="T_KPointAppPermissions"/> for all permission names.
    /// </summary>
    public class T_KPointAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了T_KPoint 的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));



           

            var t_KPoint = entityNameModel.CreateChildPermission(T_KPointAppPermissions.T_KPoint , L("T_KPoint"));
            t_KPoint.CreateChildPermission(T_KPointAppPermissions.T_KPoint_CreateT_KPoint, L("CreateT_KPoint"));
            t_KPoint.CreateChildPermission(T_KPointAppPermissions.T_KPoint_EditT_KPoint, L("EditT_KPoint"));           
            t_KPoint.CreateChildPermission(T_KPointAppPermissions. T_KPoint_DeleteT_KPoint, L("DeleteT_KPoint"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainConsts.LocalizationSourceName);
        }
    }




}