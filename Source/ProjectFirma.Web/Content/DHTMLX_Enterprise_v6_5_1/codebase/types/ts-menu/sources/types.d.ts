import { IItem, ISeparator, ISpacer, ItemType, IMenuItem, IHtmlExtendable, NavigationBarEvents } from "../../ts-navbar";
export interface INavItem extends IItem, IHtmlExtendable {
    type: ItemType.navItem;
    $openIcon?: string;
    icon?: string;
    items?: IMenuElement[];
    value?: string;
    hotkey?: string;
    active?: boolean;
    count?: number | string;
    countColor?: "danger" | "secondary" | "primary" | "success";
}
export declare type IMenuElement = ISpacer | ISeparator | INavItem | IMenuItem;
export { ItemType, IItem, NavigationBarEvents, ISpacer, ISeparator };
