function filterYearOptions(min, max, yearSelect, tenantUsesFiscalYears) {
    var selectedYear = yearSelect.val();

    yearSelect.children('option:not(:first)').remove();

    for (var year = min; year <= max; year++) {
        var yearString = tenantUsesFiscalYears ? "FY" + year : year;
        yearSelect.append(new Option(yearString, year));
    }

    if (min <= selectedYear && selectedYear <= max) {
        yearSelect.val(selectedYear);
    }
}

// Setup automatic constraining of project year selection inputs to valid years only
function initializeYearConstraining(planningYearInputId,
    implementationYearId, implementationMinYear, implementationMaxYear, 
    completionYearId, completionMinYear, completionMaxYear, projectStageElementID, tenantUsesFiscalYears) {

    function constrainYearOptions() {
        var designStartSelect = jQuery("#" + planningYearInputId);
        var implementationStartSelect = jQuery("#" + implementationYearId);
        var completedSelect = jQuery("#" + completionYearId);

        var minImplementationYear = Math.max(implementationMinYear, designStartSelect.val());
        filterYearOptions(minImplementationYear, implementationMaxYear, implementationStartSelect, tenantUsesFiscalYears);

        var minCompletionYear = Math.max(completionMinYear, minImplementationYear, implementationStartSelect.val());
        filterYearOptions(minCompletionYear, completionMaxYear, completedSelect, tenantUsesFiscalYears);
    }

    constrainYearOptions();

    document.getElementById(planningYearInputId).addEventListener("change", constrainYearOptions);
    document.getElementById(implementationYearId).addEventListener("change", constrainYearOptions);
    document.getElementById(completionYearId).addEventListener("change", constrainYearOptions);

    if (projectStageElementID) {
        var projectStageSelect = jQuery("#" + projectStageElementID);
        var allRequiredIconsToBeChecked = jQuery('[data-show-when-project-stage-in]');
        projectStageSelect.on('change',
            function() {
                var projectStageIDSelected = $(this).val();
                allRequiredIconsToBeChecked.each(function (index) {
                    var stagesThatWouldEnableRequiredIcon = $(this).data('show-when-project-stage-in').split(",");
                    if (stagesThatWouldEnableRequiredIcon.includes(projectStageIDSelected.toString())) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });

            });
    }


}
