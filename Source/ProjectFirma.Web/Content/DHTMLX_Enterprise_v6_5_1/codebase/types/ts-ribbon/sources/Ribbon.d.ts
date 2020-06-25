import { IRibbonElement } from "./types";
import { Navbar, IState } from "../../ts-navbar";
export declare class Ribbon extends Navbar<IRibbonElement> {
    private _listeners;
    constructor(element?: string | HTMLElement, config?: any);
    getState(): IState;
    setState(state: IState): void;
    protected _getFactory(): any;
    protected _getMode(item: any, root: any): "right" | "bottom";
    protected _close(e: MouseEvent): void;
    protected _draw(): any;
    protected _setRoot(id: string): void;
    private _drawBlock;
}
