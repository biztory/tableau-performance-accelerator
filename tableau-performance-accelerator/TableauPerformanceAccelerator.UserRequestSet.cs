using Biztory.EnterpriseToolkit.TableauServer.Models;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api;
using System.Collections.Generic;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    public partial class TableauPerformanceAccelerator
    {
        class UserRequestSet
        {
            private DefaultApi userApiInstance;
            private List<ViewWithFilter> viewWithFilters;
            private string tableauServerAuthToken;

            public DefaultApi UserApiInstance { get => userApiInstance; set => userApiInstance = value; }
            public List<ViewWithFilter> ViewWithFilters { get => viewWithFilters; set => viewWithFilters = value; }
            public TableauServerSiteUser SiteUser { get; set; }
            public string TableauServerAuthToken { get => tableauServerAuthToken; set => tableauServerAuthToken = value; }

            public UserRequestSet(DefaultApi Api, Models.TableauServerSiteUser SiteUser = null)
            {
                viewWithFilters = new List<ViewWithFilter>();
                userApiInstance = Api;
                this.SiteUser = SiteUser;
            }
        }
    }


}
