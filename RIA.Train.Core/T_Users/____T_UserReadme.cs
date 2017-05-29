
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:53:30. All Rights Reserved.
//<生成时间>2017-05-25T22:53:30</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_User=new MenuItemDefinition(
                T_UserAppPermissions.T_User,
                L("T_User"),
				url:"Mpa/T_UserManage",
				icon:"icon-grid",
				 requiredPermissionName: T_UserAppPermissions.T_User
				);

*/
				//有下级菜单
            /*

			   var t_User=new MenuItemDefinition(
                T_UserAppPermissions.T_User,
                L("T_User"),			
				icon:"icon-grid"				
				);

				t_User.AddItem(
			new MenuItemDefinition(
			T_UserAppPermissions.T_User,
			L("T_User"),
			"icon-star",
			url:"Mpa/T_UserManage",
			requiredPermissionName: T_UserAppPermissions.T_User));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_UserAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 用户管理管理 -->
	    <text name="T_User" value="用户管理" />
	    <text name="T_UserHeaderInfo" value="用户管理管理列表" />
		    <text name="CreateT_User" value="新增用户管理" />
    <text name="EditT_User" value="编辑用户管理" />
    <text name="DeleteT_User" value="删除用户管理" />

	  
		

		    <text name="T_UserDeleteWarningMessage" value="用户管理名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_StaffId" value="FK_StaffId" />
				 	<text name="T_Staff" value="T_Staff" />
				 	<text name="LoginNo" value="登录账号" />
				 	<text name="PassWord" value="密码" />
				 	<text name="OpenId" value="微信OpenId" />
				 	<text name="CreteTime" value="CreteTime" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 用户管理english管理 -->
		    <text name="	T_UserHeaderInfo" value="用户管理List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_StaffId" value="FK_StaffId" />
				 	<text name="T_Staff" value="T_Staff" />
				 	<text name="LoginNo" value="登录账号" />
				 	<text name="PassWord" value="密码" />
				 	<text name="OpenId" value="微信OpenId" />
				 	<text name="CreteTime" value="CreteTime" />
				 
    <text name="T_User" value="ManagementT_User" />
    <text name="CreateT_User" value="CreateT_User" />
    <text name="EditT_User" value="EditT_User" />
    <text name="DeleteT_User" value="DeleteT_User" />
*/




}