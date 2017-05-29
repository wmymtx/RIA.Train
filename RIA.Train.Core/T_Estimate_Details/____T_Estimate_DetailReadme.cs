
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:59:48. All Rights Reserved.
//<生成时间>2017-05-25T22:59:48</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Estimate_Detail=new MenuItemDefinition(
                T_Estimate_DetailAppPermissions.T_Estimate_Detail,
                L("T_Estimate_Detail"),
				url:"Mpa/T_Estimate_DetailManage",
				icon:"icon-grid",
				 requiredPermissionName: T_Estimate_DetailAppPermissions.T_Estimate_Detail
				);

*/
				//有下级菜单
            /*

			   var t_Estimate_Detail=new MenuItemDefinition(
                T_Estimate_DetailAppPermissions.T_Estimate_Detail,
                L("T_Estimate_Detail"),			
				icon:"icon-grid"				
				);

				t_Estimate_Detail.AddItem(
			new MenuItemDefinition(
			T_Estimate_DetailAppPermissions.T_Estimate_Detail,
			L("T_Estimate_Detail"),
			"icon-star",
			url:"Mpa/T_Estimate_DetailManage",
			requiredPermissionName: T_Estimate_DetailAppPermissions.T_Estimate_Detail));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_Estimate_DetailAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 评价明细管理 -->
	    <text name="T_Estimate_Detail" value="评价明细" />
	    <text name="T_Estimate_DetailHeaderInfo" value="评价明细管理列表" />
		    <text name="CreateT_Estimate_Detail" value="新增评价明细" />
    <text name="EditT_Estimate_Detail" value="编辑评价明细" />
    <text name="DeleteT_Estimate_Detail" value="删除评价明细" />

	  
		

		    <text name="T_Estimate_DetailDeleteWarningMessage" value="评价明细名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_EstimateId" value="FK_EstimateId" />
				 	<text name="T_Estimate" value="T_Estimate" />
				 	<text name="FK_UserId" value="FK_UserId" />
				 	<text name="T_User" value="T_User" />
				 	<text name="CreateTime" value="CreateTime" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 评价明细english管理 -->
		    <text name="	T_Estimate_DetailHeaderInfo" value="评价明细List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_EstimateId" value="FK_EstimateId" />
				 	<text name="T_Estimate" value="T_Estimate" />
				 	<text name="FK_UserId" value="FK_UserId" />
				 	<text name="T_User" value="T_User" />
				 	<text name="CreateTime" value="CreateTime" />
				 
    <text name="T_Estimate_Detail" value="ManagementT_Estimate_Detail" />
    <text name="CreateT_Estimate_Detail" value="CreateT_Estimate_Detail" />
    <text name="EditT_Estimate_Detail" value="EditT_Estimate_Detail" />
    <text name="DeleteT_Estimate_Detail" value="DeleteT_Estimate_Detail" />
*/




}