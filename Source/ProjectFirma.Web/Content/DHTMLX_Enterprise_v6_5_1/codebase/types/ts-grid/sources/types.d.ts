import { IEventSystem } from "../../ts-common/events";
import { IDataCollection, IDragConfig, ICsvDriverConfig, IDataItem } from "../../ts-data";
import { IAlign } from "../../ts-common/html";
import { Exporter } from "./Exporter";
import { ICombobox, IComboFilterConfig } from "../../ts-combobox";
export interface IGridConfig extends IDragConfig {
    columns?: ICol[];
    spans?: ISpan[];
    data?: any[];
    headerRowHeight?: number;
    footerRowHeight?: number;
    rowHeight?: number;
    type?: "tree";
    width?: number;
    height?: number;
    sortable?: boolean;
    rowCss?: (row: IRow) => string;
    splitAt?: number;
    selection?: ISelectionType;
    multiselection?: boolean;
    dragItem?: IDragType;
    keyNavigation?: boolean;
    css?: string;
    editable?: boolean;
    autoEmptyRow?: boolean;
    resizable?: boolean;
    htmlEnable?: boolean;
    adjust?: IAdjustBy;
    autoWidth?: boolean;
    tooltip?: boolean;
    $headerLevel?: number;
    $footerLevel?: number;
    $totalWidth?: number;
    $totalHeight?: number;
    $positions?: IPositions;
    $colspans?: boolean;
    $footer?: boolean;
    $editable?: {
        row: any;
        col: any;
        editorType?: EditorType;
        editor?: IEditor;
    };
    $resizing?: string | number;
    groupTitleTemplate?: (groupName: string, groupItems: IDataItem[]) => string;
    editing?: boolean;
    headerSort?: boolean;
    columnsAutoWidth?: boolean;
    fitToContainer?: boolean;
}
export interface IScrollState {
    left: number;
    top: number;
}
export interface IRendererConfig extends IGridConfig {
    scroll?: IScrollState;
    datacollection: any;
    currentColumns?: ICol[];
    firstColId?: string | number;
    headerHeight?: number;
    footerHeight?: number;
    events?: IEventSystem<GridEvents, IEventHandlersMap>;
    fixedColumnsWidth?: number;
    selection: any;
    sortBy?: string | number;
    sortDir?: string;
    filterLocation?: string;
    htmlEnable?: boolean;
    content?: IContentList;
}
export interface IGrid {
    data: IDataCollection;
    export: Exporter;
    config: IGridConfig;
    events: IEventSystem<GridEvents, IEventHandlersMap>;
    selection: ISelection;
    content: IContentList;
    paint(): void;
    destructor(): void;
    setColumns(col: ICol[]): void;
    addRowCss(id: any, css: string): void;
    removeRowCss(id: any, css: string): void;
    addCellCss(row: string, col: string, css: string): void;
    removeCellCss(row: string, col: string, css: string): void;
    getRootView(): any;
    showColumn(colId: string | number): void;
    hideColumn(colId: string | number): void;
    isColumnHidden(colId: string | number): boolean;
    scroll(x?: number, y?: number): void;
    scrollTo(row: string, col: string): void;
    getScrollState(): ICoords;
    adjustColumnWidth(id: string | number, adjust?: IAdjustBy): void;
    getCellRect(row: string | number, col: string | number): ICellRect;
    getColumn(colId: string): ICol;
    addSpan(spanObj: ISpan): void;
    getSpan(row: string | number, col: string | number): ISpan;
    removeSpan(row: string | number, col: string | number): void;
    editCell(rowId: string | number, colId: string | number, editorType?: EditorType): void;
    editEnd(withoutSave?: boolean): void;
    getSortingState(): any;
    edit(rowId: string | number, colId: string | number, editorType?: EditorType): void;
}
export declare enum EditorType {
    input = "input",
    select = "select",
    datepicker = "datePicker",
    checkbox = "checkbox",
    combobox = "combobox"
}
export interface ISelection {
    setCell(row?: any, col?: any, ctrlUp?: boolean, shiftUp?: boolean): void;
    getCell(): ICell;
    getCells(): ICell[];
    toHTML(): any | any[];
}
export interface ICellRect extends ICoords, ISizes {
}
declare type colType = "string" | "number" | "boolean" | "date" | any;
export interface ICol {
    id: string | number;
    width?: number;
    header?: IHeader[];
    footer?: IFooter[];
    minWidth?: number;
    maxWidth?: number;
    mark?: IMark | MarkFunction;
    type?: colType;
    editorType?: EditorType;
    editable?: boolean;
    resizable?: boolean;
    sortable?: boolean;
    options?: any[];
    draggable?: boolean;
    dateFormat?: string;
    htmlEnable?: boolean;
    template?: (cellValue: any, row: IRow, col: ICol) => string;
    hidden?: boolean;
    adjust?: IAdjustBy;
    autoWidth?: boolean;
    align?: IAlign;
    tooltip?: boolean;
    $cellCss?: {
        [key: string]: string;
    };
    $uniqueData?: any[];
    editing?: boolean;
    headerSort?: boolean;
    columnsAutoWidth?: boolean;
    fitToContainer?: boolean;
}
export declare type fixedRowContent = "inputFilter" | "selectFilter" | "comboFilter";
export declare type footerMethods = "avg" | "sum" | "max" | "min";
export interface IHeader {
    text?: string;
    colspan?: number;
    rowspan?: number;
    css?: any;
    content?: fixedRowContent | footerMethods;
    filterConfig?: IComboFilterConfig;
    align?: IAlign;
}
export interface IFooter {
    text?: string | number;
    colspan?: number;
    css?: any;
    content?: fixedRowContent | footerMethods;
}
export interface ISpan {
    row: string | number;
    column: string | number;
    rowspan?: number;
    colspan?: number;
    text?: string | number;
    css?: string;
    tooltip?: boolean;
}
declare type MarkFunction = (cell: any, columnCells: any[], row: IRow, column: ICol) => string;
export interface IMark {
    min?: string;
    max?: string;
}
export interface IPositions {
    xStart: number;
    xEnd: number;
    yStart: number;
    yEnd: number;
}
export interface ICellCss {
    color: string;
    background: string;
    fontSize: number;
}
export interface IExportData {
    columns: Array<{
        width: number;
    }>;
    header: string[][];
    data: any[];
    styles: {
        cells: any[];
        css: {
            [key: string]: ICellCss;
        };
    };
}
export declare enum GridEvents {
    scroll = "scroll",
    sort = "sort",
    expand = "expand",
    filterChange = "filterChange",
    beforeResizeStart = "beforeResizeStart",
    resize = "resize",
    afterResizeEnd = "afterResizeEnd",
    cellClick = "cellClick",
    cellRightClick = "cellRightClick",
    cellMouseOver = "cellMouseOver",
    cellMouseDown = "cellMouseDown",
    cellDblClick = "cellDblClick",
    headerCellClick = "headerCellClick",
    footerCellClick = "footerCellClick",
    headerCellMouseOver = "headerCellMouseOver",
    footerCellMouseOver = "footerCellMouseOver",
    headerCellMouseDown = "headerCellMouseDown",
    footerCellMouseDown = "footerCellMouseDown",
    headerCellDblClick = "headerCellDblClick",
    footerCellDblClick = "footerCellDblClick",
    headerCellRightClick = "headerCellRightClick",
    footerCellRightClick = "footerCellRightClick",
    beforeEditStart = "beforeEditStart",
    afterEditStart = "afterEditStart",
    beforeEditEnd = "beforeEditEnd",
    afterEditEnd = "afterEditEnd",
    beforeKeyDown = "beforeKeyDown",
    afterKeyDown = "afterKeyDown",
    headerInput = "headerInput"
}
export interface IEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [GridEvents.scroll]: (scrollState: ICoords) => void;
    [GridEvents.sort]: (id: string) => void;
    [GridEvents.expand]: (id: string) => void;
    [GridEvents.filterChange]: (value: string, colId: string, filterId: fixedRowContent) => void;
    [GridEvents.beforeResizeStart]: (col: ICol, e: MouseEvent) => boolean | void;
    [GridEvents.resize]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.afterResizeEnd]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.cellClick]: (row: IRow, col: ICol, e: MouseEvent) => void;
    [GridEvents.cellRightClick]: (row: IRow, col: ICol, e: MouseEvent) => void;
    [GridEvents.cellMouseOver]: (row: IRow, col: ICol, e: MouseEvent) => void;
    [GridEvents.cellMouseDown]: (row: IRow, col: ICol, e: MouseEvent) => void;
    [GridEvents.cellDblClick]: (row: IRow, col: ICol, e: MouseEvent) => void;
    [GridEvents.headerCellClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.footerCellClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.headerCellMouseOver]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.footerCellMouseOver]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.headerCellMouseDown]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.footerCellMouseDown]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.headerCellDblClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.footerCellDblClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.headerCellRightClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.footerCellRightClick]: (col: ICol, e: MouseEvent) => void;
    [GridEvents.beforeEditStart]: (row: IRow, col: ICol, editorType: EditorType) => boolean;
    [GridEvents.afterEditStart]: (row: IRow, col: ICol, editorType: EditorType) => void;
    [GridEvents.beforeEditEnd]: (value: any, row: IRow, col: ICol) => boolean;
    [GridEvents.afterEditEnd]: (value: any, row: IRow, col: ICol) => void;
    [GridEvents.beforeKeyDown]: (e: KeyboardEvent) => boolean;
    [GridEvents.afterKeyDown]: (e: KeyboardEvent) => void;
    [GridEvents.headerInput]: (value: string, colId: string, filterId: fixedRowContent) => void;
}
export interface ICellContent {
    toHtml: (column: ICol, config: IRendererConfig) => any;
    match?: (obj: any, value: any) => boolean;
    destroy?: () => void;
    calculate?: (col: any[], roots: any[]) => string | number;
    validate?: (colId: string, data: any[]) => any[];
    value?: any;
    combo?: {
        [key: string]: ICombobox;
    };
}
export interface IContentList {
    [key: string]: ICellContent;
}
export interface ILayoutState {
    wrapper: ISizes;
    shifts: ICoords;
    sticky: boolean;
    gridBodyHeight: number;
}
export interface IFixedRowsConfig extends ILayoutState {
    name: "header" | "footer";
    position: "top" | "bottom";
}
export interface IXlsxExportConfig {
    url?: string;
    name?: string;
}
export interface ICsvExportConfig extends ICsvDriverConfig {
    name?: string;
    asFile?: boolean;
    flat?: boolean;
    rowDelimiter?: string;
    columnDelimiter?: string;
}
export declare type Dirs = "asc" | "desc";
export interface ICoords {
    x: number;
    y: number;
}
export interface ISizes {
    width: number;
    height: number;
}
export interface ICell {
    row: IRow;
    column: ICol;
}
export interface IRow {
    id?: string | number;
    [key: string]: any;
}
export interface IEditor {
    toHTML(): any;
    endEdit(withoutSave?: boolean): void;
}
export declare type ISelectionType = "cell" | "row" | "complex";
export declare type IDirection = "horizontal" | "vertical";
export declare type IDragType = "row" | "column" | "complex";
export declare type IAdjustBy = "data" | "header" | "footer" | boolean;
export {};
