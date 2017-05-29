  
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T21:58:02. All Rights Reserved.
//<生成时间>2017-05-25T21:58:02</生成时间>
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using RIA.Train.Authorization;

namespace RIA.Train.Core.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="T_ClassAppPermissions"/> for all permission names.
    /// </summary>
    public class T_ClassAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了T_Class 的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));



           

            var t_Class = entityNameModel.CreateChildPermission(T_ClassAppPermissions.T_Class , L("T_Class"));
            t_Class.CreateChildPermission(T_ClassAppPermissions.T_Class_CreateT_Class, L("CreateT_Class"));
            t_Class.CreateChildPermission(T_ClassAppPermissions.T_Class_EditT_Class, L("EditT_Class"));           
            t_Class.CreateChildPermission(T_ClassAppPermissions. T_Class_DeleteT_Class, L("DeleteT_Class"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainConsts.LocalizationSourceName);
        }
    }




}