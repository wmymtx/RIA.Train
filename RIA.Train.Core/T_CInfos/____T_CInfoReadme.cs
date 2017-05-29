
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:28:18. All Rights Reserved.
//<生成时间>2017-05-25T22:28:18</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_CInfo=new MenuItemDefinition(
                T_CInfoAppPermissions.T_CInfo,
                L("T_CInfo"),
				url:"Mpa/T_CInfoManage",
				icon:"icon-grid",
				 requiredPermissionName: T_CInfoAppPermissions.T_CInfo
				);

*/
				//有下级菜单
            /*

			   var t_CInfo=new MenuItemDefinition(
                T_CInfoAppPermissions.T_CInfo,
                L("T_CInfo"),			
				icon:"icon-grid"				
				);

				t_CInfo.AddItem(
			new MenuItemDefinition(
			T_CInfoAppPermissions.T_CInfo,
			L("T_CInfo"),
			"icon-star",
			url:"Mpa/T_CInfoManage",
			requiredPermissionName: T_CInfoAppPermissions.T_CInfo));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_CInfoAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 培训信息配置表管理 -->
	    <text name="T_CInfo" value="培训信息配置表" />
	    <text name="T_CInfoHeaderInfo" value="培训信息配置表管理列表" />
		    <text name="CreateT_CInfo" value="新增培训信息配置表" />
    <text name="EditT_CInfo" value="编辑培训信息配置表" />
    <text name="DeleteT_CInfo" value="删除培训信息配置表" />

	  
		

		    <text name="T_CInfoDeleteWarningMessage" value="培训信息配置表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="培训项目外键" />
				 	<text name="T_Item" value="T_Item" />
				 	<text name="Fk_UserId" value="参培人员" />
				 	<text name="UserName" value="参培人员名字" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 培训信息配置表english管理 -->
		    <text name="	T_CInfoHeaderInfo" value="培训信息配置表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Fk_Id" value="培训项目外键" />
				 	<text name="T_Item" value="T_Item" />
				 	<text name="Fk_UserId" value="参培人员" />
				 	<text name="UserName" value="参培人员名字" />
				 
    <text name="T_CInfo" value="ManagementT_CInfo" />
    <text name="CreateT_CInfo" value="CreateT_CInfo" />
    <text name="EditT_CInfo" value="EditT_CInfo" />
    <text name="DeleteT_CInfo" value="DeleteT_CInfo" />
*/




}