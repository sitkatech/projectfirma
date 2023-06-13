import { DataEvents, DragEvents, IDataEventsHandlersMap, IDragEventsHandlersMap, IDataItem } from "../../ts-data";
import { GridEvents, IAdjustBy, IEventHandlersMap, IGrid, IGridConfig } from "../../ts-grid";
import { IEventSystem } from "../../ts-common/events";
import { Id } from "../../ts-common/types";
export interface ITreeGridConfig extends IGridConfig {
    rootParent?: Id;
}
export interface ITreeGrid extends IGrid {
    events: IEventSystem<DataEvents | GridEvents | DragEvents | TreeGridEvents, IEventHandlersMap & IDataEventsHandlersMap & IDragEventsHandlersMap & ITreeEventHandlersMap>;
    scrollTo(row: string, col: string): void;
    expand(id: Id): void;
    collapse(id: Id): void;
    expandAll(): void;
    collapseAll(): void;
    adjustColumnWidth(id: Id, adjust?: IAdjustBy): void;
    groupBy(property: string | ((item: IDataItem) => string)): void;
    ungroup(): void;
}
export declare enum TreeGridEvents {
    beforeCollapse = "beforeCollapse",
    afterCollapse = "afterCollapse",
    beforeExpand = "beforeExpand",
    afterExpand = "afterExpand"
}
export interface ITreeEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [TreeGridEvents.beforeCollapse]: (id: Id) => boolean | void;
    [TreeGridEvents.afterCollapse]: (id: Id) => any;
    [TreeGridEvents.beforeExpand]: (id: Id) => boolean | void;
    [TreeGridEvents.afterExpand]: (id: Id) => any;
}
