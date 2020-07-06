using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.PartnerFinder
{
    public class ProjectOrganizationMatchmaker
    {
        public double Score(Project project, Organization organization)
        {
            // To start off with, we assume that every Project matches every Organization perfectly.
            // This will change.
            double scoreToReturn = 1.0;

            // We want to be very sure score values fall between 0.0 and 1.0 inclusive.
            Check.Ensure(scoreToReturn >= 0.0 && scoreToReturn <= 1.0, $"Got Score of {scoreToReturn}. Expected Score between 0.0 and 1.0.");

            return scoreToReturn;
        }
    }
}