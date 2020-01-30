using System.Collections.Generic;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    /// <summary>
    /// A Filter collection represents an assembly of different filter combinations. In order to thoroughly
    ///  cache a view, we should run every FilterSet in this collection against that view so that we have
    ///  effectively "micro-cubed" the view.
    /// </summary>
    public class FilterCollection
    {
        public IList<FilterSet> FilterSets;

        public FilterCollection()
        {
            FilterSets = new List<FilterSet>();
        }
    }

}
