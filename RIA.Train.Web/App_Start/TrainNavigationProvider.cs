using Abp.Application.Navigation;
using Abp.Localization;
using RIA.Train.Authorization;
using RIA.Train.Core.Authorization;

namespace RIA.Train.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class TrainNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            var t_Dep = new MenuItemDefinition(
               T_DepAppPermissions.T_Dep,
               L("基本信息维护"),
               icon: "icon-grid",
               requiresAuthentication: true
               );

        //    t_Dep.AddItem(
        //new MenuItemDefinition(
        //T_DepAppPermissions.T_Dep,
        //L("T_Dep"),
        //"icon-star",
        //url: "T_Dep"));

            t_Dep.AddItem(
        new MenuItemDefinition(
        T_GroupAppPermissions.T_Group,
        L("T_Group"),
        "icon-star",
        url: "T_Group"
        ));
            t_Dep.AddItem(
            new MenuItemDefinition(
            T_ContentAppPermissions.T_Content,
            L("T_Content"),
            "icon-star",
            url: "T_Content"));

            t_Dep.AddItem(
        new MenuItemDefinition(
        T_GradeAppPermissions.T_Grade,
        L("T_Grade"),
        "icon-star",
        url: "T_Grade"));
            t_Dep.AddItem(
        new MenuItemDefinition(
        T_StaffAppPermissions.T_Staff,
        L("T_Staff"),
        "icon-star",
        url: "T_Staff"));
            //var t_User = new MenuItemDefinition(
            //  T_UserAppPermissions.T_User,
            //  L("T_User"),
            //  icon: "icon-grid"
            //  );

        //    t_Dep.AddItem(
        //new MenuItemDefinition(
        //T_UserAppPermissions.T_User,
        //L("T_User"),
        //"icon-star",
        //url: "T_User"));


            var t_Item = new MenuItemDefinition(
              T_ItemAppPermissions.T_Item,
              L("T_Item"),
              icon: "icon-grid",
              requiresAuthentication: true
              );

            t_Item.AddItem(
        new MenuItemDefinition(
        T_ItemAppPermissions.T_Item,
        L("T_Item"),
        "icon-star",
        url: "T_Item"));

       //     t_Item.AddItem(
       //new MenuItemDefinition(
       //T_KPointAppPermissions.T_KPoint,
       //L("T_KPoint"),
       //"icon-star",
       //url: "T_KPoint"));

       //     t_Item.AddItem(
       // new MenuItemDefinition(
       // T_CInfoAppPermissions.T_CInfo,
       // L("T_CInfo"),
       // "icon-star",
       // url: "T_CInfo"));
       //     t_Item.AddItem(
       //    new MenuItemDefinition(
       //    T_RequireAppPermissions.T_Require,
       //    L("T_Require"),
       //    "icon-star",
       //    url: "T_Require"));

            t_Item.AddItem(
        new MenuItemDefinition(
        T_ClassAppPermissions.T_Class,
        L("T_Class"),
        "icon-star",
        url: "T_Class"));

           
           
        //    t_Item.AddItem(
        //new MenuItemDefinition(
        //T_HClassAppPermissions.T_HClass,
        //L("T_HClass"),
        //"icon-star",
        //url: "T_HClass"));

            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("用户管理"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )).AddItem(t_Dep).AddItem(t_Item);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainConsts.LocalizationSourceName);
        }
    }
}
