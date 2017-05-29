
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:50:35. All Rights Reserved.
//<生成时间>2017-05-25T22:50:35</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Staff=new MenuItemDefinition(
                T_StaffAppPermissions.T_Staff,
                L("T_Staff"),
				url:"Mpa/T_StaffManage",
				icon:"icon-grid",
				 requiredPermissionName: T_StaffAppPermissions.T_Staff
				);

*/
				//有下级菜单
            /*

			   var t_Staff=new MenuItemDefinition(
                T_StaffAppPermissions.T_Staff,
                L("T_Staff"),			
				icon:"icon-grid"				
				);

				t_Staff.AddItem(
			new MenuItemDefinition(
			T_StaffAppPermissions.T_Staff,
			L("T_Staff"),
			"icon-star",
			url:"Mpa/T_StaffManage",
			requiredPermissionName: T_StaffAppPermissions.T_Staff));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_StaffAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 人员信息表管理 -->
	    <text name="T_Staff" value="人员信息表" />
	    <text name="T_StaffHeaderInfo" value="人员信息表管理列表" />
		    <text name="CreateT_Staff" value="新增人员信息表" />
    <text name="EditT_Staff" value="编辑人员信息表" />
    <text name="DeleteT_Staff" value="删除人员信息表" />

	  
		

		    <text name="T_StaffDeleteWarningMessage" value="人员信息表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_GroupId" value="FK_GroupId" />
				 	<text name="T_Group" value="T_Group" />
				 	<text name="StaffName" value="人员名称" />
				 	<text name="CreteTime" value="CreteTime" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 人员信息表english管理 -->
		    <text name="	T_StaffHeaderInfo" value="人员信息表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_GroupId" value="FK_GroupId" />
				 	<text name="T_Group" value="T_Group" />
				 	<text name="StaffName" value="人员名称" />
				 	<text name="CreteTime" value="CreteTime" />
				 
    <text name="T_Staff" value="ManagementT_Staff" />
    <text name="CreateT_Staff" value="CreateT_Staff" />
    <text name="EditT_Staff" value="EditT_Staff" />
    <text name="DeleteT_Staff" value="DeleteT_Staff" />
*/




}