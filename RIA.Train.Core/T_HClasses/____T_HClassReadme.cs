
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:38:52. All Rights Reserved.
//<生成时间>2017-05-25T22:38:52</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_HClass=new MenuItemDefinition(
                T_HClassAppPermissions.T_HClass,
                L("T_HClass"),
				url:"Mpa/T_HClassManage",
				icon:"icon-grid",
				 requiredPermissionName: T_HClassAppPermissions.T_HClass
				);

*/
				//有下级菜单
            /*

			   var t_HClass=new MenuItemDefinition(
                T_HClassAppPermissions.T_HClass,
                L("T_HClass"),			
				icon:"icon-grid"				
				);

				t_HClass.AddItem(
			new MenuItemDefinition(
			T_HClassAppPermissions.T_HClass,
			L("T_HClass"),
			"icon-star",
			url:"Mpa/T_HClassManage",
			requiredPermissionName: T_HClassAppPermissions.T_HClass));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_HClassAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 培训班人员信息表管理 -->
	    <text name="T_HClass" value="培训班人员信息表" />
	    <text name="T_HClassHeaderInfo" value="培训班人员信息表管理列表" />
		    <text name="CreateT_HClass" value="新增培训班人员信息表" />
    <text name="EditT_HClass" value="编辑培训班人员信息表" />
    <text name="DeleteT_HClass" value="删除培训班人员信息表" />

	  
		

		    <text name="T_HClassDeleteWarningMessage" value="培训班人员信息表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="FK_ClassId" value="FK_ClassId" />
				 	<text name="T_Class" value="T_Class" />
				 	<text name="FK_UserId" value="FK_UserId" />
				 	<text name="UserName" value="用户名" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 培训班人员信息表english管理 -->
		    <text name="	T_HClassHeaderInfo" value="培训班人员信息表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="FK_ClassId" value="FK_ClassId" />
				 	<text name="T_Class" value="T_Class" />
				 	<text name="FK_UserId" value="FK_UserId" />
				 	<text name="UserName" value="用户名" />
				 
    <text name="T_HClass" value="ManagementT_HClass" />
    <text name="CreateT_HClass" value="CreateT_HClass" />
    <text name="EditT_HClass" value="EditT_HClass" />
    <text name="DeleteT_HClass" value="DeleteT_HClass" />
*/




}