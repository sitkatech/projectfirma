import { INavbarConfig, ISpacer, ISeparator, IMenuItem, NavigationBarEvents, DataEvents } from "../../ts-navbar";
import { ICustomHTMLButton, IText, INavItem } from "../../ts-toolbar";
import { IEventSystem } from "../../ts-common/events";
import { ITreeCollection } from "../../ts-data";
export interface ISidebarConfig extends INavbarConfig {
    width?: number | string;
    minWidth?: number | string;
    collapsed?: boolean;
}
export declare enum SidebarEvents {
    beforeCollapse = "beforeCollapse",
    afterCollapse = "afterCollapse",
    beforeExpand = "beforeExpand",
    afterExpand = "afterExpand",
    toggle = "toggle"
}
export interface ISidebarEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [SidebarEvents.beforeCollapse]: () => boolean;
    [SidebarEvents.afterCollapse]: () => any;
    [SidebarEvents.beforeExpand]: () => boolean;
    [SidebarEvents.afterExpand]: () => any;
    [SidebarEvents.toggle]: () => any;
}
export declare type ISidebarElement = ICustomHTMLButton | ISeparator | ISpacer | IText | INavItem | IMenuItem;
export interface ISidebar {
    config: ISidebarConfig;
    events: IEventSystem<NavigationBarEvents | DataEvents | (SidebarEvents & ISidebarEventHandlersMap)>;
    data: ITreeCollection<ISidebarElement>;
    paint(): void;
    destructor(): void;
    isDisabled(id: string): boolean;
    toggle(): void;
    isCollapsed(): boolean;
    expand(): void;
    collapse(): void;
    select(id: string, unselect: boolean): void;
    unselect(id?: string): void;
    isSelected(id: string): boolean;
    getSelected(): string[];
}
