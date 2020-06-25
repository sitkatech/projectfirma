import { DataCollection, DataEvents, DragEvents, IDataEventsHandlersMap, IDragEventsHandlersMap, IDragConfig } from "../../ts-data";
import { IEventSystem } from "../../ts-common/events";
import { ISelection, MultiselectionMode } from "../../ts-list";
export interface IDataViewConfig extends IDragConfig {
    data?: DataCollection<any> | any[];
    itemsInRow?: number;
    height?: number | string;
    itemHeight?: number | string;
    gap?: number;
    template?: (item: any) => string;
    keyNavigation?: boolean | (() => boolean);
    css?: string;
    selection?: false;
    multiselection?: boolean | MultiselectionMode;
    editable?: boolean;
    editing?: boolean;
    multiselectionMode?: MultiselectionMode;
}
export interface IDataView<T = any> {
    config: IDataViewConfig;
    data: DataCollection<T>;
    events: IEventSystem<DataEvents | DragEvents | DataViewEvents, IDataEventsHandlersMap & IDragEventsHandlersMap & IDataViewEventHandlersMap>;
    selection: ISelection;
    paint(): void;
    destructor(): void;
    editItem(id: string): void;
    getFocusItem(): T;
    setFocus(id: string): void;
    getFocus(): string;
    getFocusIndex(): number;
    setFocusIndex(index: number): void;
    edit(id: string): void;
    disableSelection(): any;
    enableSelection(): any;
}
export declare enum DataViewEvents {
    click = "click",
    doubleClick = "doubleclick",
    focusChange = "focuschange",
    beforeEditStart = "beforeEditStart",
    afterEditStart = "afterEditStart",
    beforeEditEnd = "beforeEditEnd",
    afterEditEnd = "afterEditEnd",
    itemRightClick = "itemRightClick",
    itemMouseOver = "itemMouseOver",
    contextmenu = "contextmenu"
}
export interface IDataViewEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [DataViewEvents.click]: (id: string, e: Event) => any;
    [DataViewEvents.itemMouseOver]: (id: string, e: Event) => any;
    [DataViewEvents.doubleClick]: (id: string, e: Event) => any;
    [DataViewEvents.itemRightClick]: (id: string, e: MouseEvent) => any;
    [DataViewEvents.focusChange]: (focusIndex: number, id: string) => any;
    [DataViewEvents.beforeEditStart]: (id: string) => void | boolean;
    [DataViewEvents.afterEditStart]: (id: string) => void;
    [DataViewEvents.beforeEditEnd]: (value: any, id: string) => void | boolean;
    [DataViewEvents.afterEditEnd]: (value: any, id: string) => void;
    [DataViewEvents.contextmenu]: (id: string, e: MouseEvent) => any;
}
export interface IDataViewItem {
    [key: string]: any;
}
