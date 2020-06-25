import { Navbar } from "../../ts-navbar";
import { IMenuElement } from "./types";
declare type Mode = "bottom" | "right";
export declare class ContextMenu extends Navbar<IMenuElement> {
    protected _isContextMenu: boolean;
    private _mode;
    showAt(elem: HTMLElement | MouseEvent | string, showAt?: Mode): void;
    protected _getFactory(): any;
    protected _close(e: MouseEvent): void;
    protected _getMode(_item: any, _root: any, active: boolean): Mode;
    private _changeActivePosition;
}
export {};
