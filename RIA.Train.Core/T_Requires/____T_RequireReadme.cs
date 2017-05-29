
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:47:41. All Rights Reserved.
//<生成时间>2017-05-25T22:47:41</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Require=new MenuItemDefinition(
                T_RequireAppPermissions.T_Require,
                L("T_Require"),
				url:"Mpa/T_RequireManage",
				icon:"icon-grid",
				 requiredPermissionName: T_RequireAppPermissions.T_Require
				);

*/
				//有下级菜单
            /*

			   var t_Require=new MenuItemDefinition(
                T_RequireAppPermissions.T_Require,
                L("T_Require"),			
				icon:"icon-grid"				
				);

				t_Require.AddItem(
			new MenuItemDefinition(
			T_RequireAppPermissions.T_Require,
			L("T_Require"),
			"icon-star",
			url:"Mpa/T_RequireManage",
			requiredPermissionName: T_RequireAppPermissions.T_Require));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_RequireAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 培训需求提报管理 -->
	    <text name="T_Require" value="培训需求提报" />
	    <text name="T_RequireHeaderInfo" value="培训需求提报管理列表" />
		    <text name="CreateT_Require" value="新增培训需求提报" />
    <text name="EditT_Require" value="编辑培训需求提报" />
    <text name="DeleteT_Require" value="删除培训需求提报" />

	  
		

		    <text name="T_RequireDeleteWarningMessage" value="培训需求提报名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="Fk_Id" />
				 	<text name="Fk_UserId" value="参培人员" />
				 	<text name="T_User" value="T_User" />
				 	<text name="UserName" value="名字" />
				 	<text name="Content" value="提报内容" />
				 	<text name="SubmitTime" value="提报时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 培训需求提报english管理 -->
		    <text name="	T_RequireHeaderInfo" value="培训需求提报List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="Fk_Id" />
				 	<text name="Fk_UserId" value="参培人员" />
				 	<text name="T_User" value="T_User" />
				 	<text name="UserName" value="名字" />
				 	<text name="Content" value="提报内容" />
				 	<text name="SubmitTime" value="提报时间" />
				 
    <text name="T_Require" value="ManagementT_Require" />
    <text name="CreateT_Require" value="CreateT_Require" />
    <text name="EditT_Require" value="EditT_Require" />
    <text name="DeleteT_Require" value="DeleteT_Require" />
*/




}