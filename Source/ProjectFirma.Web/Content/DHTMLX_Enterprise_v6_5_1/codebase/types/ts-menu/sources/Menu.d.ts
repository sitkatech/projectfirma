import { Navbar } from "../../ts-navbar";
import { IMenuElement } from "./types";
export declare class Menu extends Navbar<IMenuElement> {
    constructor(element?: string | HTMLElement, config?: any);
    protected _getFactory(): any;
    private _draw;
}
