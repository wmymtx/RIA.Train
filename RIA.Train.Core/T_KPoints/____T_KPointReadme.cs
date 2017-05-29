
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:44:49. All Rights Reserved.
//<生成时间>2017-05-25T22:44:49</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_KPoint=new MenuItemDefinition(
                T_KPointAppPermissions.T_KPoint,
                L("T_KPoint"),
				url:"Mpa/T_KPointManage",
				icon:"icon-grid",
				 requiredPermissionName: T_KPointAppPermissions.T_KPoint
				);

*/
				//有下级菜单
            /*

			   var t_KPoint=new MenuItemDefinition(
                T_KPointAppPermissions.T_KPoint,
                L("T_KPoint"),			
				icon:"icon-grid"				
				);

				t_KPoint.AddItem(
			new MenuItemDefinition(
			T_KPointAppPermissions.T_KPoint,
			L("T_KPoint"),
			"icon-star",
			url:"Mpa/T_KPointManage",
			requiredPermissionName: T_KPointAppPermissions.T_KPoint));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_KPointAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 培训重点管理 -->
	    <text name="T_KPoint" value="培训重点" />
	    <text name="T_KPointHeaderInfo" value="培训重点管理列表" />
		    <text name="CreateT_KPoint" value="新增培训重点" />
    <text name="EditT_KPoint" value="编辑培训重点" />
    <text name="DeleteT_KPoint" value="删除培训重点" />

	  
		

		    <text name="T_KPointDeleteWarningMessage" value="培训重点名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="Fk_Id" />
				 	<text name="T_Item" value="T_Item" />
				 	<text name="TrainContent" value="培训重点" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 培训重点english管理 -->
		    <text name="	T_KPointHeaderInfo" value="培训重点List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="Fk_Id" />
				 	<text name="T_Item" value="T_Item" />
				 	<text name="TrainContent" value="培训重点" />
				 
    <text name="T_KPoint" value="ManagementT_KPoint" />
    <text name="CreateT_KPoint" value="CreateT_KPoint" />
    <text name="EditT_KPoint" value="EditT_KPoint" />
    <text name="DeleteT_KPoint" value="DeleteT_KPoint" />
*/




}