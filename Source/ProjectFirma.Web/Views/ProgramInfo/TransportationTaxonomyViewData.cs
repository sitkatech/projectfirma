using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProgramInfo
{
    public class TransportationTaxonomyViewData : FirmaViewData
    {
        public readonly List<FancyTreeNode> TransportationStrategiesAsFancyTreeNodes;

        public TransportationTaxonomyViewData(Person currentPerson, Models.FirmaPage firmaPage,
            List<FancyTreeNode> transportationStrategiesAsFancyTreeNodes) : base(currentPerson, firmaPage)
        {
            TransportationStrategiesAsFancyTreeNodes = transportationStrategiesAsFancyTreeNodes;
            PageTitle = "Transportation Strategies and Objectives";
        }
    }
}