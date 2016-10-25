using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class SearchResultsViewData : FirmaViewData
    {
        public readonly List<Models.Project> EntitySearchResults;
        public readonly string SearchCriteria;
        public Func<String, string> UrlGeneratingFunctor;

        public SearchResultsViewData(Person currentPerson, List<Models.Project> entitySearchResults, string searchCriteria) : base(currentPerson)
        {
            EntitySearchResults = entitySearchResults;
            SearchCriteria = searchCriteria;
            PageTitle = "Project Search";
        }
    }
}