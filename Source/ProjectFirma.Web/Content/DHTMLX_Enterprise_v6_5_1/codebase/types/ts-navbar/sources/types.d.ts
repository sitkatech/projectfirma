import { IDataItem, TreeCollection } from "../../ts-data";
export { DataEvents } from "../../ts-data";
export declare enum ItemType {
    button = "button",
    imageButton = "imageButton",
    selectButton = "selectButton",
    customHTMLButton = "customButton",
    input = "input",
    separator = "separator",
    title = "title",
    spacer = "spacer",
    menuItem = "menuItem",
    block = "block",
    navItem = "navItem",
    customHTML = "customHTML"
}
export interface IItem extends IDataItem {
    type?: ItemType;
    parent?: string;
    css?: string | string[];
    hidden?: boolean;
    disabled?: boolean;
}
export declare type IMenuElement = IMenuItem | ISeparator | ISpacer;
export interface IMenuItem extends IItem, IHtmlExtendable {
    type?: ItemType.menuItem;
    $openIcon?: string;
    icon?: string;
    items?: IMenuElement[];
    value?: string;
    hotkey?: string;
    count?: number | string;
    countColor?: "danger" | "secondary" | "primary" | "success";
}
export interface IHtmlExtendable {
    html?: string;
}
export interface IState {
    [key: string]: string;
}
export interface IPopup {
    data: any[];
    mode: "bottom" | "other";
    position: any;
    width: number;
    height: number;
}
export interface ISpacer extends IItem {
    type: ItemType.spacer;
}
export interface ISeparator extends IItem {
    type: ItemType.separator;
}
export declare enum NavigationBarEvents {
    inputCreated = "inputCreated",
    click = "click",
    openMenu = "openmenu",
    beforeHide = "beforeHide",
    afterHide = "afterHide",
    inputFocus = "inputfocus",
    inputBlur = "inputblur"
}
export declare enum NavigationType {
    pointer = "pointer",
    click = "click"
}
export interface IGroups {
    [key: string]: {
        active?: string;
        elements: string[];
    };
}
export interface INavbarEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [NavigationBarEvents.inputCreated]: (id: string, input: HTMLInputElement) => any;
    [NavigationBarEvents.openMenu]: (id: string) => any;
    [NavigationBarEvents.click]: (id: string, e: Event) => any;
    [NavigationBarEvents.beforeHide]: (id: string, e: Event) => void | boolean;
    [NavigationBarEvents.afterHide]: (e: Event) => any;
    [NavigationBarEvents.inputBlur]: (id: string) => any;
    [NavigationBarEvents.inputFocus]: (id: string) => any;
}
export interface INavbarConfig {
    navigationType?: NavigationType;
    css?: string;
    menuCss?: string;
    data?: any[] | TreeCollection<any>;
}
