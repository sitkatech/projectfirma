class HtmlFilterComponent {
    constructor() {
        HtmlFilterComponent.prototype.__init.call(this);
    }

    init(params) {
        this.filterText = null;
        this.params = params;
        this.setupGui();
    }

    // not called by AG Grid, just for us to help setup
    setupGui() {
        this.gui = document.createElement('div');
        this.gui.innerHTML = `
            <div style="padding: 4px">
                <div>
                    <input type="text" min="0" id="filterText" placeholder="Filter..." class="ag-input-field-input ag-text-field-input" aria-label="Filter Value"  />
                </div>
            </div>
        `;

        this.onFilterChanged = () => {
            this.extractFilterText();
            this.params.filterChangedCallback();
        };

        this.eFilterText = this.gui.querySelector('#filterText');
        this.eFilterText.addEventListener('input', this.onFilterChanged);
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



