import { DataEvents, DragEvents, IDataEventsHandlersMap, IDragEventsHandlersMap, IDataItem } from "../../ts-data";
import { GridEvents, IAdjustBy, IEventHandlersMap, IGrid } from "../../ts-grid";
import { IEventSystem } from "../../ts-common/events";
export { IGridConfig as ITreeGridConfig } from "../../ts-grid";
export interface ITreeGrid extends IGrid {
    events: IEventSystem<DataEvents | GridEvents | DragEvents | TreeGridEvents, IEventHandlersMap & IDataEventsHandlersMap & IDragEventsHandlersMap & ITreeEventHandlersMap>;
    scrollTo(row: string, col: string): void;
    expand(id: string): void;
    collapse(id: string): void;
    expandAll(): void;
    collapseAll(): void;
    adjustColumnWidth(id: string | number, adjust?: IAdjustBy): void;
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
    [TreeGridEvents.beforeCollapse]: (id: string) => boolean;
    [TreeGridEvents.afterCollapse]: (id: string) => any;
    [TreeGridEvents.beforeExpand]: (id: string) => boolean;
    [TreeGridEvents.afterExpand]: (id: string) => any;
}
