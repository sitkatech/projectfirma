import { GridEvents, IAdjustBy, IEventHandlersMap, ProGrid } from "../../ts-grid";
import { IEventSystem } from "../../ts-common/events";
import { DataEvents, DragEvents, IDataEventsHandlersMap, IDragEventsHandlersMap, IDataItem } from "../../ts-data";
import { TreeGridCollection } from "./TreeGridCollection";
import { ITreeEventHandlersMap, ITreeGrid, ITreeGridConfig, TreeGridEvents } from "./types";
export declare class TreeGrid extends ProGrid implements ITreeGrid {
    data: TreeGridCollection;
    events: IEventSystem<DataEvents | GridEvents | DragEvents | TreeGridEvents, IEventHandlersMap & IDataEventsHandlersMap & IDragEventsHandlersMap & ITreeEventHandlersMap>;
    private _pregroupData;
    constructor(container: HTMLElement, config: ITreeGridConfig);
    scrollTo(row: string, col: string): void;
    expand(id: string): void;
    collapse(id: string): void;
    expandAll(): void;
    collapseAll(): void;
    adjustColumnWidth(id: string | number, adjust?: IAdjustBy): void;
    groupBy(property: string | ((item: IDataItem) => string)): void;
    ungroup(): void;
    protected _createCollection(prep: (data: any[]) => any[]): void;
    protected _checkColumns(): void;
    protected _getRowIndex(rowId: any): number;
    protected _parseColumns(): void;
    protected _setEventHandlers(): void;
    private _groupBy;
}
