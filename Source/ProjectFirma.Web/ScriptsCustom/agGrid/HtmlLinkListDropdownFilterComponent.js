class HtmlLinkListDropdownFilterComponent {
    constructor() {
        HtmlLinkListDropdownFilterComponent.prototype.__init.call(this);
    }

    init(params) {
        //this.filterText = null;
        this.params = params;
        this.dropdownValues = [];
        this.selectedValues = [];
        this.dropdowns = [];
        this.field = null;
        //console.log(params);
        if (params.colDef) {
            this.field = params.colDef.field;
            this.columnContainsMultipleValues = params.colDef.columnContainsMultipleValues;
        }

        this.setupGui();

    }

    // not called by AG Grid, just for us to help setup
    setupGui() {
        //debugger;
        this.params.api.forEachNode((rowNode, i) => {

            var columnValue = this.getNodeValue(rowNode);
            if(!columnValue) {
                return;
            }
            var jsonObj = JSON.parse(columnValue);
            for (var i = 0; i < jsonObj.links.length; i++) {
                var item = jsonObj.links[i];
                if (!this.dropdownValues.includes(item.displayText)) {
                    this.dropdownValues.push(item.displayText);
                }
            }

        });
        //console.log("dropdown fields for:" + this.params.colDef.field);
        //console.log(this.dropdownValues);
        this.gui = document.createElement('div');
        this.gui.classList.add("filter-options");


        var buttonsWrapper = document.createElement('div');
        buttonsWrapper.classList.add("bs-actionsbox");

        var selectDeselectButtons = document.createElement('div');
        selectDeselectButtons.classList.add("btn-group");
        selectDeselectButtons.classList.add("btn-group-sm");
        selectDeselectButtons.classList.add("btn-block");
        selectDeselectButtons.innerHTML = '<button id="SelectAll" type="button" class="actions-btn bs-select-all btn btn-default">Select All</button><button id="DeselectAll" type="button" class="actions-btn bs-deselect-all btn btn-default">Deselect All</button>'

        buttonsWrapper.appendChild(selectDeselectButtons);
        this.gui.appendChild(buttonsWrapper);

        this.dropdownValues.sort().forEach((element) => {
            if (!element) {
                this.gui.innerHTML +=
                    `<label class="filter-option" style="font-weight: normal; font-style: italic"><input type="checkbox" name="${element}" class="grid-filter-checkbox" />(Blank)</label> `;
            } else {
                this.gui.innerHTML += `<label class="filter-option"><input type="checkbox" name="${element}" class="grid-filter-checkbox" />${element}</label> `;
            }
            //this.gui.innerHTML += '<label><input type="checkbox" name="' + element + '" id="' + element + '" class="mr-2" />' + element + '</label><br/>';
        });



        this.onFilterChanged = () => {
            this.extractFilterValues();
            this.params.filterChangedCallback();
        };

        this.dropdowns = this.gui.querySelectorAll('.grid-filter-checkbox');
        this.dropdowns.forEach(checkbox => checkbox.addEventListener('change', this.onFilterChanged));

        this.onSelectAllClicked = () => {
            this.dropdowns.forEach(dropdown => {
                dropdown.checked = true;
            });
            this.onFilterChanged();
        }
        this.onDeselectAllClicked = () => {
            this.dropdowns.forEach(dropdown => {
                dropdown.checked = false;
            });
            this.onFilterChanged();
        }

        this.selectAllButton = this.gui.querySelector('#SelectAll');
        this.selectAllButton.addEventListener('click', this.onSelectAllClicked);
        this.deselectAllButton = this.gui.querySelector('#DeselectAll');
        this.deselectAllButton.addEventListener('click', this.onDeselectAllClicked);

        //this.eFilterText = this.gui.querySelector('#filterDropdown');
        //this.eFilterText.addEventListener('input', this.onFilterChanged);
        //  this.filterOptions
    }

    getNodeValue(rowNode) {
        if (this.params.colDef.valueGetter) {
            return this.params.colDef.valueGetter(rowNode);
        }

        return this.getPropertyValue(rowNode.data, this.field, '');
    }

    getPropertyValue(object, path, defaultValue) {
        return path
            .split('.')
            .reduce((o, p) => o ? o[p] : defaultValue, object);
    }

    __init() {
        //this.isNumeric = (n) => !isNaN(parseFloat(n)) && isFinite(parseFloat(n));
    }

    myMethodForTakingValueFromFloatingFilter(value) {
        this.selectedValues = value;
        this.onFilterChanged();
    }

    extractFilterValues() {
        const dropdownArray = Array.from(this.dropdowns) ;
        const checkedDropdowns = dropdownArray.filter(x => x.checked);
        this.selectedValues = checkedDropdowns.map(x => x.name);
    }

    getGui() {
        return this.gui;
    }

    doesFilterPass(params) {
        if (!this.isFilterActive()) {
            return false;
        }

        const {
            api,
            colDef,
            column,
            columnApi,
            context,
            valueGetter,
        } = this.params;
        const { node } = params;

        const value = valueGetter({
            api,
            colDef,
            column,
            columnApi,
            context,
            data: node.data,
            getValue: (field) => node.data[field],
            node,
        });

        if (!value) {
            return false;
        }

        var jsonObj = JSON.parse(value.toString());

        for (var i = 0; i < jsonObj.links.length; i++) {
            var item = jsonObj.links[i];
            if (item.displayText && this.selectedValues.includes(item.displayText)) {
                return true;
            }
        }

        return false;
    }

    isFilterActive() {
        return (
            this.selectedValues !== null &&
            this.selectedValues !== undefined &&
            this.selectedValues.length > 0
        );
    }

    getModel() {
        return this.isFilterActive() ? this.selectedValues : null;
    }

    setModel(model) {
        if (model == null) {
            this.dropdowns.forEach(dropdown => {
                dropdown.checked = false;
            });
        } else {

            this.selectedValues = model;
            this.dropdowns.forEach(dropdown => {
                dropdown.checked = this.selectedValues.includes(dropdown.name);
            });
        }
        
        this.selectedValues = model;
        this.extractFilterValues();
    }

    destroy() {
        this.dropdowns.removeEventListener('change', this.onFilterChanged);
        this.selectAllButton.removeEventListener('click', this.onSelectAllClicked);
        this.deselectAllButton.removeEventListener('click', this.onDeselectAllClicked);
    }

    // If floating filters are turned on for the grid, but you have no floating filter
    // configured for this column, then the grid will check for this method. If this
    // method exists, then the grid will provide a read-only floating filter for you
    // and display the results of this method. For example, if your filter is a simple
    // filter with one string input value, you could just return the simple string
    // value here.
    getModelAsString(model) {
        return this.selectedValues.join(", ");
    }   
}



