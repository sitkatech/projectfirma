import { IState, Navbar } from "../../ts-navbar";
import { IToolbarElement, IToolbar } from "./types";
export declare class Toolbar extends Navbar<IToolbarElement> implements IToolbar {
    constructor(element?: string | HTMLElement, config?: any);
    getState(): IState;
    setState(state: IState): void;
    protected _customHandlers(): {
        input: (e: Event) => void;
        tooltip: (e: MouseEvent) => void;
    };
    protected _getFactory(): any;
    protected _draw(): any;
    protected _getMode(item: any, root: any): "right" | "bottom";
    protected _close(e: MouseEvent): void;
    protected _setRoot(id: string): void;
}
