import { ItemType, IItem, ISpacer, ISeparator, IState, NavigationBarEvents, IMenuItem, IHtmlExtendable } from "../../ts-navbar";
import { TreeCollection, DataEvents } from "../../ts-data";
import { IEventSystem } from "../../ts-common/events";
import { IMenuElement } from "../../ts-menu";
export interface IToolbar {
    data: TreeCollection<IToolbarElement>;
    events: IEventSystem<DataEvents | NavigationBarEvents>;
    getState(): IState;
    setState(state: IState): void;
    hide(id: string | string[]): void;
    show(id: string | string[]): void;
    disable(id: string | string[]): void;
    enable(id: string | string[]): void;
    isDisabled(id: string): boolean;
    paint(): void;
    destructor(): void;
}
export interface IButton extends IItem, IHtmlExtendable {
    type: ItemType.button;
    css?: string;
    hotkey?: string;
    tooltip?: string;
    count?: number;
    countColor?: "danger" | "secondary" | "primary" | "success";
    items?: IMenuElement[];
    group?: string;
    twoState?: boolean;
    active?: boolean;
    multiClick?: boolean;
    icon?: string;
    view?: "flat" | "link";
    size?: "small" | "medium";
    color?: "danger" | "secondary" | "primary" | "success";
    full?: boolean;
    circle?: boolean;
    loading?: boolean;
    value?: string;
}
export interface IText extends IItem, IHtmlExtendable {
    type: ItemType.title;
    value?: string;
    tooltip?: string;
}
export interface IInput extends IItem {
    type: ItemType.input;
    icon?: string;
    placeholder?: string;
    width?: string;
    label?: string;
    value?: string;
}
export interface IImageButton extends IItem {
    type: ItemType.imageButton;
    src: string;
    twoState?: boolean;
    active?: boolean;
}
export interface ISelectButton extends IItem {
    type: ItemType.selectButton;
    $openIcon?: string;
    icon?: string;
    items?: IMenuElement[];
}
export interface ICustomHTMLButton extends IItem {
    type: ItemType.customHTMLButton;
    twoState?: boolean;
    active?: boolean;
    value?: string;
    count?: number;
}
export interface INavItem extends IItem {
    type: ItemType.navItem;
    value?: string;
    icon?: string;
    count?: string | number;
    hotkey?: string;
    twoState?: boolean;
    group?: string;
    countColor?: "danger" | "secondary" | "primary" | "success";
}
export declare type IToolbarElement = IButton | IInput | IImageButton | ICustomHTMLButton | ISeparator | ISpacer | IText | ISelectButton | INavItem | IMenuItem;
export { ItemType, IItem, NavigationBarEvents, ISpacer, ISeparator };
