import { IViewFn, IViewConstructor } from "../../ts-layout";
import { IView } from "../../ts-common/view";
export interface IWindowConfig {
    css?: string;
    title?: string;
    html?: string;
    minWidth?: number;
    minHeight?: number;
    left?: number;
    top?: number;
    width?: number;
    height?: number;
    footer?: boolean;
    header?: boolean;
    viewportOverflow?: boolean;
    resizable?: boolean;
    movable?: boolean;
    modal?: boolean;
    closable?: boolean;
    node?: any;
}
export interface IPosition {
    left: number;
    top: number;
}
export interface ISize {
    width: number;
    height: number;
}
export interface IWindow {
    setSize(width: number, height: number): void;
    getSize(): ISize;
    setPosition(left: number, top: number): void;
    getPosition(): IPosition;
    getWidget(): any;
    getContainer(): HTMLElement;
    show(left: number, top: number): void;
    hide(): void;
    isVisible(): boolean;
    attach(name: string | IViewFn | IView | IViewConstructor, config?: any): void;
    attachHTML(html: string): void;
    destructor(): void;
    paint(): void;
    setFullScreen(): void;
    fullScreen(): void;
}
export interface IResizeConfig {
    left?: boolean;
    right?: boolean;
    top?: boolean;
    bottom?: boolean;
}
export declare enum WindowEvents {
    resize = "resize",
    headerDoubleClick = "headerdoubleclick",
    move = "move",
    afterShow = "aftershow",
    afterHide = "afterhide",
    beforeShow = "beforeshow",
    beforeHide = "beforehide"
}
