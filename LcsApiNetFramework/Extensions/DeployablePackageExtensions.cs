using LcsApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApiNetFramework.Extensions
{
    internal static class DeployablePackageExtensions
    {
        public static Dictionary<string, object> ToEnvironmentActionParameters(this DeployablePackage deployablePackage)
        {
            return new Dictionary<string, object>()
            {
                { "package[PackageId]", deployablePackage.PackageId },
                { "package[Name]", deployablePackage.Name },
                { "package[Description]", deployablePackage.Description },
                { "package[PackageType]", deployablePackage.PackageType },
                { "package[ModifiedDate]", deployablePackage.ModifiedDate },
                { "package[ModifiedBy]", deployablePackage.ModifiedBy },
                { "package[Publisher]", deployablePackage.Publisher },
                { "package[Scope]", deployablePackage.Scope },
                { "package[LcsEnvironmentActionId]", deployablePackage.LcsEnvironmentActionId },
                { "package[LcsEnvironmentId]", deployablePackage.LcsEnvironmentId },
                { "package[FileAssetDisplayVersion]", deployablePackage.FileAssetDisplayVersion },
                { "package[PlatformVersion]", deployablePackage.PlatformVersion },
                { "package[AppVersion]", deployablePackage.AppVersion },
                { "package[EstimatedDuration]", deployablePackage.EstimatedDuration },
            };
        }
    }
}
