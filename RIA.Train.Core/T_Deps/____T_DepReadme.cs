

namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Dep=new MenuItemDefinition(
                T_DepAppPermissions.T_Dep,
                L("T_Dep"),
				url:"Mpa/T_DepManage",
				icon:"icon-grid",
				 requiredPermissionName: T_DepAppPermissions.T_Dep
				);

*/
				//有下级菜单
            /*

			   var t_Dep=new MenuItemDefinition(
                T_DepAppPermissions.T_Dep,
                L("T_Dep"),			
				icon:"icon-grid"				
				);

				t_Dep.AddItem(
			new MenuItemDefinition(
			T_DepAppPermissions.T_Dep,
			L("T_Dep"),
			"icon-star",
			url:"Mpa/T_DepManage",
			requiredPermissionName: T_DepAppPermissions.T_Dep));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_DepAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 部门表管理 -->
	    <text name="T_Dep" value="部门表" />
	    <text name="T_DepHeaderInfo" value="部门表管理列表" />
		    <text name="CreateT_Dep" value="新增部门表" />
    <text name="EditT_Dep" value="编辑部门表" />
    <text name="DeleteT_Dep" value="删除部门表" />

	  
		

		    <text name="T_DepDeleteWarningMessage" value="部门表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="DepName" value="部门" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 部门表english管理 -->
		    <text name="	T_DepHeaderInfo" value="部门表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="DepName" value="部门" />
				 
    <text name="T_Dep" value="ManagementT_Dep" />
    <text name="CreateT_Dep" value="CreateT_Dep" />
    <text name="EditT_Dep" value="EditT_Dep" />
    <text name="DeleteT_Dep" value="DeleteT_Dep" />
*/




}