
// a GridTable simple object for JSON use
//
// usage:
// var x = new GridTable.GridTable("foo");
// x.addColumn("bar", "stuff", 65);
// console.log(JSON.stringify(x));
var GridTable = function () {
    function GridColumn(columnName, filterTextArray, width, order, isSorted, sortDirection, sortType) {
        this.ColumnName = columnName;
        this.FilterTextArray = filterTextArray;
        this.Width = width;
        this.ColumnOrder = order;
        this.IsSorted = isSorted;
        this.SortDirection = sortDirection;
        this.SortType = sortType;
    };

    function GridTable(gridName) {
        this.GridName = gridName;
        this.Columns = [];
    };

    GridTable.prototype.addColumn = function (columnName, filterTextArray, width, order, isSorted, sortDirection, sortType) {
        if (!columnName) {
            return;
        }
        var col = new GridColumn(columnName, filterTextArray, width, order, isSorted, sortDirection, sortType);
        this.Columns.push(col);
    };

    return {
        GridTable: GridTable
    }
}();