
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-23T22:10:14. All Rights Reserved.
//<生成时间>2017-05-23T22:10:14</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Group=new MenuItemDefinition(
                T_GroupAppPermissions.T_Group,
                L("T_Group"),
				url:"Mpa/T_GroupManage",
				icon:"icon-grid",
				 requiredPermissionName: T_GroupAppPermissions.T_Group
				);

*/
				//有下级菜单
            /*

			   var t_Group=new MenuItemDefinition(
                T_GroupAppPermissions.T_Group,
                L("T_Group"),			
				icon:"icon-grid"				
				);

				t_Group.AddItem(
			new MenuItemDefinition(
			T_GroupAppPermissions.T_Group,
			L("T_Group"),
			"icon-star",
			url:"Mpa/T_GroupManage",
			requiredPermissionName: T_GroupAppPermissions.T_Group));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_GroupAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 班组表管理 -->
	    <text name="T_Group" value="班组表" />
	    <text name="T_GroupHeaderInfo" value="班组表管理列表" />
		    <text name="CreateT_Group" value="新增班组表" />
    <text name="EditT_Group" value="编辑班组表" />
    <text name="DeleteT_Group" value="删除班组表" />

	  
		

		    <text name="T_GroupDeleteWarningMessage" value="班组表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_DepId" value="FK_DepId" />
				 	<text name="T_Dep" value="T_Dep" />
				 	<text name="GroupName" value="班组" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 班组表english管理 -->
		    <text name="	T_GroupHeaderInfo" value="班组表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_DepId" value="FK_DepId" />
				 	<text name="T_Dep" value="T_Dep" />
				 	<text name="GroupName" value="班组" />
				 
    <text name="T_Group" value="ManagementT_Group" />
    <text name="CreateT_Group" value="CreateT_Group" />
    <text name="EditT_Group" value="EditT_Group" />
    <text name="DeleteT_Group" value="DeleteT_Group" />
*/




}