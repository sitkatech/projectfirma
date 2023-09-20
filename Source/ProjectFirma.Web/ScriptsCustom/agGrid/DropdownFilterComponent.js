class DropdownFilterComponent {
    constructor() {
        DropdownFilterComponent.prototype.__init.call(this);
    }

    init(params) {
        this.filterText = null;
        this.params = params;
        this.dropdownValues = [];
        this.filterOptions = [];
        this.field = null;
        console.log(params);
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

            //console.log(rowNode);
            var columnValue = this.getNodeValue(rowNode);
            if (!this.dropdownValues.includes(columnValue)) {
                this.dropdownValues.push(columnValue);
            }
            
        });
        console.log(this.dropdownValues);
        this.gui = document.createElement('div');


        this.dropdownValues.forEach((element) => {
            this.gui.innerHTML += '<label><input type="checkbox" name="' + element + '" id="' + element + '" class="mr-2" />' + element + '</label><br/>';
        });



        this.onFilterChanged = () => {
            this.extractFilterText();
            this.params.filterChangedCallback();
        };

        //this.eFilterText = this.gui.querySelector('#filterDropdown');
        //this.eFilterText.addEventListener('input', this.onFilterChanged);
        //this.filterOptions
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
        this.eFilterText.value = value;
        this.onFilterChanged();
    }

    extractFilterText() {
        this.filterText = this.eFilterText.value;
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

        //const filterValue = this.filterText;

        //if (value == null) return false;
        //return Number(value) > Number(filterValue);
        const filterValue = this.filterText;
        var textToSearch = value.toString().replace(/<[^>]*>/g, "");
        var foundInText = (textToSearch.toLowerCase().indexOf(filterValue.toLowerCase()) != -1);
        return foundInText;
    }

    isFilterActive() {
        return (
            this.filterText !== null &&
            this.filterText !== undefined &&
            this.filterText !== ''
        );
    }

    getModel() {
        return this.isFilterActive() ? this.eFilterText.value : null;
    }

    setModel(model) {
        this.eFilterText.value = model;
        this.extractFilterText();
    }

    destroy() {
        this.eFilterText.removeEventListener('input', this.onFilterChanged);
    }
}



