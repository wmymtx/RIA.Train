
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:16:07. All Rights Reserved.
//<生成时间>2017-05-25T22:16:07</生成时间>
namespace RIA.Train.Core
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var t_Content=new MenuItemDefinition(
                T_ContentAppPermissions.T_Content,
                L("T_Content"),
				url:"Mpa/T_ContentManage",
				icon:"icon-grid",
				 requiredPermissionName: T_ContentAppPermissions.T_Content
				);

*/
				//有下级菜单
            /*

			   var t_Content=new MenuItemDefinition(
                T_ContentAppPermissions.T_Content,
                L("T_Content"),			
				icon:"icon-grid"				
				);

				t_Content.AddItem(
			new MenuItemDefinition(
			T_ContentAppPermissions.T_Content,
			L("T_Content"),
			"icon-star",
			url:"Mpa/T_ContentManage",
			requiredPermissionName: T_ContentAppPermissions.T_Content));
	

			
			*/

	
			
	
	
	
	//配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到TrainApplicationModule
 //   Configuration.Authorization.Providers.Add<T_ContentAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Trainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 考评内容（档次）管理 -->
	    <text name="T_Content" value="考评内容（档次）" />
	    <text name="T_ContentHeaderInfo" value="考评内容（档次）管理列表" />
		    <text name="CreateT_Content" value="新增考评内容（档次）" />
    <text name="EditT_Content" value="编辑考评内容（档次）" />
    <text name="DeleteT_Content" value="删除考评内容（档次）" />

	  
		

		    <text name="T_ContentDeleteWarningMessage" value="考评内容（档次）名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Content" value="考评内容" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Train.xml
/*
    <!-- 考评内容（档次）english管理 -->
		    <text name="	T_ContentHeaderInfo" value="考评内容（档次）List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Content" value="考评内容" />
				 
    <text name="T_Content" value="ManagementT_Content" />
    <text name="CreateT_Content" value="CreateT_Content" />
    <text name="EditT_Content" value="EditT_Content" />
    <text name="DeleteT_Content" value="DeleteT_Content" />
*/




}