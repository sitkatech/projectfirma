import { IEventSystem } from "../../ts-common/events";
import { TreeCollection, DataEvents, DragEvents, IDragConfig, IDataItem } from "../../ts-data";
import { IEditorConfig } from "./Editor";
export declare type Id = string;
export interface ITreeState {
    [id: string]: {
        selected: SelectStatus;
        open: boolean;
    };
}
export interface ITreeItem extends IDataItem {
    parent: string;
    opened?: boolean;
    $mark?: SelectStatus;
    checkbox?: boolean;
    $autoload?: boolean;
    $selected?: boolean;
    $editor?: boolean;
}
export interface ITreeCustomIcon {
    file?: string;
    folder?: string;
    openFolder?: string;
}
export declare enum SelectStatus {
    unselected = 0,
    selected = 1,
    indeterminate = 2
}
export declare enum ItemIcon {
    file = "file",
    folder = "folder",
    openFolder = "openFolder"
}
export interface ITreeConfig extends IDragConfig {
    data?: TreeCollection<any> | any[];
    css?: string;
    keyNavigation?: boolean;
    autoload?: string;
    checkbox?: boolean;
    isFolder?: (obj: any) => boolean;
    icon?: ITreeCustomIcon;
    editable?: boolean;
    editing?: boolean;
}
export interface ITree {
    data: TreeCollection;
    events: IEventSystem<DataEvents | DragEvents | TreeEvents>;
    paint(): void;
    destructor(): void;
    editItem(id: Id, config: IEditorConfig): void;
    getState(): ITreeState;
    setState(state: ITreeState): void;
    focusItem(id: string): void;
    toggle(id: Id): void;
    getChecked(): Id[];
    checkItem(id: Id): void;
    collapse(id: Id): void;
    collapseAll(): void;
    expand(id: Id): void;
    expandAll(): void;
    uncheckItem(id: Id): void;
    close(id: Id): void;
    closeAll(): void;
    open(id: Id): void;
    openAll(): void;
    unCheckItem(id: Id): void;
}
export declare enum TreeEvents {
    itemClick = "itemclick",
    itemDblClick = "itemdblclick",
    itemRightClick = "itemrightclick",
    beforeCollapse = "beforeCollapse",
    afterCollapse = "afterCollapse",
    beforeExpand = "beforeExpand",
    afterExpand = "afterExpand",
    itemContextMenu = "itemcontextmenu"
}
export interface ITreeEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [TreeEvents.itemClick]: (id: string, e: Event) => any;
    [TreeEvents.itemRightClick]: (id: string, e: Event) => any;
    [TreeEvents.itemDblClick]: (id: string, e: Event) => any;
    [TreeEvents.beforeCollapse]: (id: string) => boolean;
    [TreeEvents.afterCollapse]: (id: string) => any;
    [TreeEvents.beforeExpand]: (id: string) => boolean;
    [TreeEvents.afterExpand]: (id: string) => any;
    [TreeEvents.itemContextMenu]: (id: string, e: Event) => any;
}
