
class HtmlFloatingFilterComponent {
    // Generic param should be HtmlFilterComponent but type needs to be passed through IFloatingFilterComp first
    init(params) {
        this.eGui = document.createElement('div');
        this.eGui.innerHTML = '<input type="text" class="ag-input-field-input ag-text-field-input" tabindex="0" />';
        this.currentValue = null;
        this.eFilterInput = this.eGui.querySelector('input');

        const onInputBoxChanged = () => {
            if (this.eFilterInput.value === '') {
                // Remove the filter
                params.parentFilterInstance((instance) => {
                    instance.myMethodForTakingValueFromFloatingFilter(null);
                });
                return;
            }

            this.currentValue = this.eFilterInput.value;
            params.parentFilterInstance((instance) => {
                instance.myMethodForTakingValueFromFloatingFilter(this.currentValue);
            });
        };

        this.eFilterInput.addEventListener('input', onInputBoxChanged);
    }

    onParentModelChanged(parentModel) {
        // When the filter is empty we will receive a null message here
        if (parentModel == null) {
            this.eFilterInput.value = '';
            this.currentValue = null;
        } else {
            this.eFilterInput.value = parentModel;
            this.currentValue = parentModel;
        }
    }

    getGui() {
        return this.eGui;
    }
}