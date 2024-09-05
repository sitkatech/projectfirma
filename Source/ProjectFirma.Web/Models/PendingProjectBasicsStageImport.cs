/*-----------------------------------------------------------------------
<copyright file="PendingProjectBasicsStageImport.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class PendingProjectBasicsStageImport
    {
        
        public readonly string ProjectName;
        public readonly string Description;
        public readonly string TaxonomyLeaf;
        public readonly string ProjectStage;
        public readonly string PlanningDesignStartYear;
        public readonly string ImplementationStartYear;
        public readonly string CompletionYear;
        public readonly string Latitude;
        public readonly string Longitude;
        public readonly string SimpleLocationNotes;
        public readonly string LeadImplementer;
        public readonly string PrimaryContact;
        public Dictionary<string, string> ColumnErrors;

        public PendingProjectBasicsStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;

            ColumnErrors = new Dictionary<string, string>();

            // Column A - Project Name
            try
            {
                ProjectName = string.IsNullOrWhiteSpace(dr["A"].ToString()) ? null : dr["A"].ToString();
            }
            catch
            {
                var error = $"Problem parsing Project Name - Cell A{rowIndex + 1} - Cell Value \"{dr["A"]}\"";
                ColumnErrors.Add("Project Name", error);
            }


            // Column B - Description
            try
            {
                Description = string.IsNullOrWhiteSpace(dr["B"].ToString()) ? null : dr["B"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Description - Cell B{rowIndex + 1} - Cell Value \"{dr["B"]}\"";
                ColumnErrors.Add("Description", error);
            }

            // Column C - Taxonomy Leaf
            try
            {
                TaxonomyLeaf = string.IsNullOrWhiteSpace(dr["C"].ToString()) ? null : dr["C"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Taxonomy Leaf - Cell C{rowIndex + 1} - Cell Value \"{dr["C"]}\"";
                ColumnErrors.Add("Taxonomy Leaf", error);
            }

            // Column D - Project Stage
            try
            {
                ProjectStage = string.IsNullOrWhiteSpace(dr["D"].ToString()) ? null : dr["D"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Project Stage - Cell D{rowIndex + 1} - Cell Value \"{dr["D"]}\"";
                ColumnErrors.Add("Project Stage", error);
            }

            // Column E - Planning/Design Start Year
            try
            {
                PlanningDesignStartYear = string.IsNullOrWhiteSpace(dr["E"].ToString()) ? null : dr["E"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Planning/Design Start Year - Cell E{rowIndex + 1} - Cell Value \"{dr["E"]}\"";
                ColumnErrors.Add("Planning/Design Start Year", error);
            }

            // Column F - Implementation Start Year
            try
            {
                ImplementationStartYear = string.IsNullOrWhiteSpace(dr["F"].ToString()) ? null : dr["F"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Implementation Start Year - Cell F{rowIndex + 1} - Cell Value \"{dr["F"]}\"";
                ColumnErrors.Add("Implementation Start Year", error);
            }

            // Column G - Completion Year
            try
            {
                CompletionYear = string.IsNullOrWhiteSpace(dr["G"].ToString()) ? null : dr["G"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Completion Year - Cell G{rowIndex + 1} - Cell Value \"{dr["G"]}\"";
                ColumnErrors.Add("Completion Year", error);
            }

            // Column H - Latitude
            try
            {
                Latitude = string.IsNullOrWhiteSpace(dr["H"].ToString()) ? null : dr["H"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Latitude - Cell H{rowIndex + 1} - Cell Value \"{dr["H"]}\"";
                ColumnErrors.Add("Latitude", error);
            }

            // Column I - Longitude
            try
            {
                Longitude = string.IsNullOrWhiteSpace(dr["I"].ToString()) ? null : dr["I"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Longitude - Cell I{rowIndex + 1} - Cell Value \"{dr["I"]}\"";
                ColumnErrors.Add("Longitude", error);
            }

            // Column J - Simple Location Notes
            try
            {
                SimpleLocationNotes = string.IsNullOrWhiteSpace(dr["J"].ToString()) ? null : dr["J"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Simple Location Notes - Cell J{rowIndex + 1} - Cell Value \"{dr["J"]}\"";
                ColumnErrors.Add("Simple Location Notes", error);
            }

            // Column J - Lead Implementer
            try
            {
                LeadImplementer = string.IsNullOrWhiteSpace(dr["K"].ToString()) ? null : dr["K"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Lead Implementer - Cell K{rowIndex + 1} - Cell Value \"{dr["K"]}\"";
                ColumnErrors.Add("Lead Implementer", error);
            }

            // Column J - Project Primary Contact
            try
            {
                PrimaryContact = string.IsNullOrWhiteSpace(dr["L"].ToString()) ? null : dr["L"].ToString();
            }

            catch
            {
                var error = $"Problem parsing Project Primary Contact - Cell L{rowIndex + 1} - Cell Value \"{dr["L"]}\"";
                ColumnErrors.Add("Project Primary Contact", error);
            }
        }



        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr, Dictionary<string, string> basicColumnNames)
        {
            var columnsToCheck = basicColumnNames.Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => string.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }
    }
}
