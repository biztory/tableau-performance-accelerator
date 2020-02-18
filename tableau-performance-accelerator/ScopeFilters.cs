using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model;
using Microsoft.Extensions.Logging;
//using MMMTools.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    public partial class TableauPerformanceAccelerator
    {
        bool ProjectFilterBasedOnConfiguration(QueryViewsForSiteResponseViewsView arg, Models.FilterAndCubeConfiguration filterAndCubeConfiguration)
        {
            // If no filters are provided, include all views
            if (filterAndCubeConfiguration == null)
                return true;

            logger.LogDebug($"ProjectFilterBasedOnConfiguration: Project: {arg.Project.Name} ({arg.Project.Id})");

            // If the view name is not excluded, and if it matches the regex scope OR the explicit include list, then include it
            if (filterAndCubeConfiguration.Scope.Projects.ScopeMatch(arg.Project.Name))
            {
                return true;
            }
            else
            {
                logger.LogDebug($"View {arg.Name} excluded by project filter. Regex.IsMatch: {(Regex.IsMatch(arg.Project.Name, filterAndCubeConfiguration.Scope.Projects.Regex ?? "")).ToString()}; Projects.Include: {filterAndCubeConfiguration.Scope.Projects.Include.Contains(arg.Project.Name).ToString()}; Projects.Exclude: {filterAndCubeConfiguration.Scope.Projects.Exclude.Contains(arg.Project.Name).ToString()}");
                return false;
            }
        }

        bool WorkbookFilterBasedOnConfiguration(QueryViewsForSiteResponseViewsView arg, Models.FilterAndCubeConfiguration filterAndCubeConfiguration)
        {
            // If no filters are provided, include all views
            if (filterAndCubeConfiguration == null)
                return true;

            logger.LogDebug($"WorkbookFilterBasedOnConfiguration: Workbook: {arg.Workbook.Name} ({arg.Workbook.Id})");

            // If the view name is not excluded, and if it matches the regex scope OR the explicit include list, then include it
            if (filterAndCubeConfiguration.Scope.Workbooks.ScopeMatch(arg.Workbook.Name))
            {
                return true;
            }
            else
            {
                logger.LogDebug($"View {arg.Name} excluded by workbook filter. Regex.IsMatch: {(Regex.IsMatch(arg.Workbook.Name, filterAndCubeConfiguration.Scope.Workbooks.Regex ?? "")).ToString()}; Workbooks.Include: {filterAndCubeConfiguration.Scope.Workbooks.Include.Contains(arg.Workbook.Name).ToString()}; Workbooks.Exclude: {filterAndCubeConfiguration.Scope.Workbooks.Exclude.Contains(arg.Workbook.Name).ToString()}");
                return false;
            }
        }

        bool ViewFilterBasedOnConfiguration(QueryViewsForSiteResponseViewsView arg, Models.FilterAndCubeConfiguration filterAndCubeConfiguration)
        {
            // If no filters are provided, include all views
            if (filterAndCubeConfiguration == null)
                return true;

            logger.LogDebug($"ViewFilterBasedOnConfiguration: View: {arg.Name} ({arg.Id})");
            // If the view name is not excluded, and if it matches the regex scope OR the explicit include list, then include it
            if (filterAndCubeConfiguration.Scope.Views.ScopeMatch(arg.Name))
            {
                return true;
            }
            else
            {
                logger.LogDebug($"View {arg.Name} excluded. Regex.IsMatch: {(Regex.IsMatch(arg.Name, filterAndCubeConfiguration.Scope.Views.Regex ?? "")).ToString()}; Views.Include: {filterAndCubeConfiguration.Scope.Views.Include.Contains(arg.Name).ToString()}; Views.Exclude: {filterAndCubeConfiguration.Scope.Views.Exclude.Contains(arg.Name).ToString()}");
                return false;
            }
        }

        bool UserFilterBasedOnConfiguration(GetUsersOnSiteResponseUsersUser arg, Models.FilterAndCubeConfiguration filterAndCubeConfiguration)
        {
            if (arg.SiteRole == "Unlicensed") return false;

            // Guest users can not be impersonated via the REST API - BET-10
            if (arg.Name.ToLowerInvariant() == "guest") return false;

            // If no filters are provided, include all users
            if (filterAndCubeConfiguration == null)
            {
                return true;
            }

            if (filterAndCubeConfiguration.Scope.Users.ScopeMatch(arg.Name))
            {
                return true;
            }
            else
            {
                logger.LogDebug($"User {arg.Name} excluded. Regex.IsMatch: {(Regex.IsMatch(arg.Name, filterAndCubeConfiguration.Scope.Users.Regex ?? "")).ToString()}; Users.Include: {filterAndCubeConfiguration.Scope.Users.Include.Contains(arg.Name).ToString()}; Users.Exclude: {filterAndCubeConfiguration.Scope.Users.Exclude.Contains(arg.Name).ToString()}");
                return false;
            }
        }
    }
}
