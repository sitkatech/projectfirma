import { ItemType, IItem, ISeparator, ISpacer, IMenuItem, NavigationBarEvents } from "../../ts-navbar";
import { INavItem, IButton, IInput, ICustomHTMLButton, IText, ISelectButton } from "../../ts-toolbar";
export interface IBlock extends IItem {
    type: ItemType.block;
    title?: string;
    direction?: "row" | "col";
    css?: "string";
}
export interface IRibbonItem extends INavItem {
    size?: "small" | "medium" | "auto";
}
export interface IImageButton extends IItem {
    type: ItemType.imageButton;
    twoState?: boolean;
    group?: string;
    src?: string;
    hotkey?: string;
    size?: "small" | "medium" | "auto";
}
export declare type IRibbonElement = IButton | IInput | IImageButton | ICustomHTMLButton | ISeparator | ISpacer | IText | ISelectButton | IRibbonItem | IMenuItem | IBlock;
export { ItemType, IItem, NavigationBarEvents, ISpacer, ISeparator };
