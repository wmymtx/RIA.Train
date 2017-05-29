
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:57:03. All Rights Reserved.
//<生成时间>2017-05-25T22:57:03</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Estimate=new MenuItemDefinition(
                T_EstimateAppPermissions.T_Estimate,
                L("T_Estimate"),
				url:"Mpa/T_EstimateManage",
				icon:"icon-grid",
				 requiredPermissionName: T_EstimateAppPermissions.T_Estimate
				);

*/
				//有下级菜单
            /*

			   var t_Estimate=new MenuItemDefinition(
                T_EstimateAppPermissions.T_Estimate,
                L("T_Estimate"),			
				icon:"icon-grid"				
				);

				t_Estimate.AddItem(
			new MenuItemDefinition(
			T_EstimateAppPermissions.T_Estimate,
			L("T_Estimate"),
			"icon-star",
			url:"Mpa/T_EstimateManage",
			requiredPermissionName: T_EstimateAppPermissions.T_Estimate));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_EstimateAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 老师评价结果表管理 -->
	    <text name="T_Estimate" value="老师评价结果表" />
	    <text name="T_EstimateHeaderInfo" value="老师评价结果表管理列表" />
		    <text name="CreateT_Estimate" value="新增老师评价结果表" />
    <text name="EditT_Estimate" value="编辑老师评价结果表" />
    <text name="DeleteT_Estimate" value="删除老师评价结果表" />

	  
		

		    <text name="T_EstimateDeleteWarningMessage" value="老师评价结果表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_ClassId" value="FK_ClassId" />
				 	<text name="T_Class" value="T_Class" />
				 	<text name="FK_ContentId" value="FK_ContentId" />
				 	<text name="T_Content" value="T_Content" />
				 	<text name="FK_GradeId" value="FK_GradeId" />
				 	<text name="T_Grade" value="T_Grade" />
				 	<text name="ContentCount" value="评价累积次数" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 老师评价结果表english管理 -->
		    <text name="	T_EstimateHeaderInfo" value="老师评价结果表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_ClassId" value="FK_ClassId" />
				 	<text name="T_Class" value="T_Class" />
				 	<text name="FK_ContentId" value="FK_ContentId" />
				 	<text name="T_Content" value="T_Content" />
				 	<text name="FK_GradeId" value="FK_GradeId" />
				 	<text name="T_Grade" value="T_Grade" />
				 	<text name="ContentCount" value="评价累积次数" />
				 
    <text name="T_Estimate" value="ManagementT_Estimate" />
    <text name="CreateT_Estimate" value="CreateT_Estimate" />
    <text name="EditT_Estimate" value="EditT_Estimate" />
    <text name="DeleteT_Estimate" value="DeleteT_Estimate" />
*/




}