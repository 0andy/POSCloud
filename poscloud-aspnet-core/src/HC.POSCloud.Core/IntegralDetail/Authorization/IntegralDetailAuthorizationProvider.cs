

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using HC.POSCloud.Authorization;

namespace HC.POSCloud.IntegralDetails.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="IntegralDetailPermissions" /> for all permission names. IntegralDetail
    ///</summary>
    public class IntegralDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public IntegralDetailAuthorizationProvider()
		{

		}

        public IntegralDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public IntegralDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了IntegralDetail 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(IntegralDetailPermissions.Node , L("IntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.Query, L("QueryIntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.Create, L("CreateIntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.Edit, L("EditIntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.Delete, L("DeleteIntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.BatchDelete, L("BatchDeleteIntegralDetail"));
			entityPermission.CreateChildPermission(IntegralDetailPermissions.ExportExcel, L("ExportExcelIntegralDetail"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, POSCloudConsts.LocalizationSourceName);
		}
    }
}