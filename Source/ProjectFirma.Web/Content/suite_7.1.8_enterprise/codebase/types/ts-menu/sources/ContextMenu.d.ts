import { Navbar, IMenuElement, ContextMode, INavbar } from "../../ts-navbar";
export declare class ContextMenu extends Navbar<IMenuElement> implements INavbar {
    protected _isContextMenu: boolean;
    private _mode;
    showAt(elem: HTMLElement | MouseEvent | string, showAt?: ContextMode): void;
    protected _getFactory(): any;
    protected _close(e: MouseEvent): void;
    protected _getMode(_item: any, _root: any, active: boolean): ContextMode;
    private _changeActivePosition;
}
