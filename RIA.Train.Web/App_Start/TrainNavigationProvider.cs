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
               L("T_Dep"),
               icon: "icon-grid"
               );

            t_Dep.AddItem(
        new MenuItemDefinition(
        T_DepAppPermissions.T_Dep,
        L("T_Dep"),
        "icon-star",
        url: "T_Dep"));

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
                        L("Users"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(t_Dep).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainConsts.LocalizationSourceName);
        }
    }
}
