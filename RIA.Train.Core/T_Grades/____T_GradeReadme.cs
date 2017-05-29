
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:35:57. All Rights Reserved.
//<生成时间>2017-05-25T22:35:57</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Grade=new MenuItemDefinition(
                T_GradeAppPermissions.T_Grade,
                L("T_Grade"),
				url:"Mpa/T_GradeManage",
				icon:"icon-grid",
				 requiredPermissionName: T_GradeAppPermissions.T_Grade
				);

*/
				//有下级菜单
            /*

			   var t_Grade=new MenuItemDefinition(
                T_GradeAppPermissions.T_Grade,
                L("T_Grade"),			
				icon:"icon-grid"				
				);

				t_Grade.AddItem(
			new MenuItemDefinition(
			T_GradeAppPermissions.T_Grade,
			L("T_Grade"),
			"icon-star",
			url:"Mpa/T_GradeManage",
			requiredPermissionName: T_GradeAppPermissions.T_Grade));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_GradeAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 考评等级管理 -->
	    <text name="T_Grade" value="考评等级" />
	    <text name="T_GradeHeaderInfo" value="考评等级管理列表" />
		    <text name="CreateT_Grade" value="新增考评等级" />
    <text name="EditT_Grade" value="编辑考评等级" />
    <text name="DeleteT_Grade" value="删除考评等级" />

	  
		

		    <text name="T_GradeDeleteWarningMessage" value="考评等级名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Grade" value="等级" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 考评等级english管理 -->
		    <text name="	T_GradeHeaderInfo" value="考评等级List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Grade" value="等级" />
				 
    <text name="T_Grade" value="ManagementT_Grade" />
    <text name="CreateT_Grade" value="CreateT_Grade" />
    <text name="EditT_Grade" value="EditT_Grade" />
    <text name="DeleteT_Grade" value="DeleteT_Grade" />
*/




}