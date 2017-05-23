
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T21:42:09. All Rights Reserved.
//<生成时间>2017-05-21T21:42:09</生成时间>
namespace RIA.Train.Core.T_ItemCore
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Item=new MenuItemDefinition(
                T_ItemAppPermissions.T_Item,
                L("T_Item"),
				url:"Mpa/T_ItemManage",
				icon:"icon-grid",
				 requiredPermissionName: T_ItemAppPermissions.T_Item
				);

*/
				//有下级菜单
            /*

			   var t_Item=new MenuItemDefinition(
                T_ItemAppPermissions.T_Item,
                L("T_Item"),			
				icon:"icon-grid"				
				);

				t_Item.AddItem(
			new MenuItemDefinition(
			T_ItemAppPermissions.T_Item,
			L("T_Item"),
			"icon-star",
			url:"Mpa/T_ItemManage",
			requiredPermissionName: T_ItemAppPermissions.T_Item));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_ItemAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 培训项目设置管理 -->
	    <text name="T_Item" value="培训项目设置" />
	    <text name="T_ItemHeaderInfo" value="培训项目设置管理列表" />
		    <text name="CreateT_Item" value="新增培训项目设置" />
    <text name="EditT_Item" value="编辑培训项目设置" />
    <text name="DeleteT_Item" value="删除培训项目设置" />

	  
		

		    <text name="T_ItemDeleteWarningMessage" value="培训项目设置名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="ProjectName" value="项目名称" />
				 	<text name="CreateTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 培训项目设置english管理 -->
		    <text name="	T_ItemHeaderInfo" value="培训项目设置List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="ProjectName" value="项目名称" />
				 	<text name="CreateTime" value="创建时间" />
				 
    <text name="T_Item" value="ManagementT_Item" />
    <text name="CreateT_Item" value="CreateT_Item" />
    <text name="EditT_Item" value="EditT_Item" />
    <text name="DeleteT_Item" value="DeleteT_Item" />
*/




}