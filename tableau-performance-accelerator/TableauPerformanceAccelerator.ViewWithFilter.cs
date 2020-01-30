using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    public partial class TableauPerformanceAccelerator
    {
        public enum ViewRequestMode
        {
            RestApi,
            HttpGet,
            ClientXml
        }

        class ViewWithFilter
        {
            public QueryViewsForSiteResponseViewsView View { get; set; }
            public string Filter { get; set; }
            public ViewRequestMode RequestMode { get; set; }

            public ViewWithFilter(QueryViewsForSiteResponseViewsView View, string Filter, ViewRequestMode RequestMode = ViewRequestMode.RestApi)
            {
                this.View = View;
                this.Filter = Filter;
                this.RequestMode = RequestMode;
            }

        }
    }


}
