using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    // TODO: Move this into the general Tableau Server unified models project
    /// <summary>
    /// The site roles that a user can have on a Tableau Server or Tableau Online site
    /// </summary>
    public enum TableauServerSiteRole
    {
        LegacyViewer,
        Interactor,
        Publisher,
        SiteAdministrator,
        ServerAdministator,
        Creator,
        Explorer,
        Viewer,
        ExplorerCanPublish
    }
}