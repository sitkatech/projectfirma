import { IDataItem, DataCollection, DataEvents, DragEvents, IDataEventsHandlersMap, IDragEventsHandlersMap, IDragConfig } from "../../ts-data";
import { IEventSystem } from "../../ts-common/events";
import { SelectionEvents, ISelectionEventsHandlersMap } from "../../ts-common/types";
export declare type MultiselectionMode = "click" | "ctrlClick";
export interface IListConfig extends IDragConfig {
    template?: (obj: IDataItem) => string;
    data?: DataCollection<any> | any[];
    virtual?: boolean;
    itemHeight?: number | string;
    css?: string;
    height?: number | string;
    selection?: ISelectionConfig | false;
    multiselection?: boolean | MultiselectionMode;
    keyNavigation?: boolean | (() => boolean);
    editable?: boolean;
    editing?: boolean;
    multiselectionMode?: MultiselectionMode;
}
export declare enum ListEvents {
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
export interface IListEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [ListEvents.click]: (id: string, e: Event) => any;
    [ListEvents.itemMouseOver]: (id: string, e: Event) => any;
    [ListEvents.doubleClick]: (id: string, e: Event) => any;
    [ListEvents.itemRightClick]: (id: string, e: MouseEvent) => any;
    [ListEvents.focusChange]: (focusIndex: number, id: string) => any;
    [ListEvents.beforeEditStart]: (id: string) => void | boolean;
    [ListEvents.afterEditStart]: (id: string) => void;
    [ListEvents.beforeEditEnd]: (value: any, id: string) => void | boolean;
    [ListEvents.afterEditEnd]: (value: any, id: string) => void;
    [ListEvents.contextmenu]: (id: string, e: MouseEvent) => any;
}
export interface ISelectionConfig {
    multiselection?: boolean | MultiselectionMode;
    multiselectionMode?: MultiselectionMode;
}
export interface IList<T = any> {
    config: IListConfig;
    data: DataCollection<T>;
    events: IEventSystem<DataEvents | ListEvents | DragEvents, IListEventHandlersMap & IDataEventsHandlersMap & IDragEventsHandlersMap>;
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
}
export interface ISelection<T = any> {
    config: ISelectionConfig;
    events: IEventSystem<SelectionEvents | DataEvents, ISelectionEventsHandlersMap & IDataEventsHandlersMap>;
    getId(): string | string[] | undefined;
    getItem(): T;
    contains(id?: string): boolean;
    remove(id?: string): boolean;
    add(id?: string, isShift?: boolean, isCtrl?: boolean): void;
}
export interface IListItem {
    [key: string]: any;
}
