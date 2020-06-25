export declare function toNode(node: string | HTMLElement): HTMLElement;
declare type eventPrepare = (ev: Event) => any;
interface IHandlerHash {
    [name: string]: (...args: any[]) => boolean | void;
}
export declare function eventHandler(prepare: eventPrepare, hash: IHandlerHash): (ev: Event) => boolean | void;
export declare function locateNode(target: Event | Element, attr?: string, dir?: string): Element;
export declare function locate(target: Event | Element, attr?: string): string;
export declare function locateNodeByClassName(target: Event | Element, className?: string): Element;
export declare function getBox(elem: any): {
    top: any;
    left: any;
    right: number;
    bottom: number;
    width: number;
    height: number;
};
export declare function getScrollbarWidth(): number;
export interface IFitTarget {
    top: number;
    left: number;
    width: number;
    height: number;
}
export interface IFitPosition {
    left: number;
    right: number;
    top: number;
    bottom: number;
}
export interface IFitPositionConfig {
    mode?: Position;
    auto?: boolean;
    centering?: boolean;
    width: number;
    height: number;
}
export declare type IAlign = "left" | "center" | "right";
export declare function isIE(): boolean;
export declare function getRealPosition(node: HTMLElement): IFitPosition;
export declare enum Position {
    left = "left",
    right = "right",
    bottom = "bottom",
    top = "top"
}
export declare function calculatePosition(pos: IFitPosition, config: IFitPositionConfig): {
    left: string;
    top: string;
    minWidth: string;
    position: string;
};
export declare function fitPosition(node: HTMLElement, config: IFitPositionConfig): {
    left: string;
    top: string;
    minWidth: string;
    position: string;
};
export declare function getStrSize(str: string, textStyle?: any): {
    width: number;
    height: number;
};
export declare function getPageCss(): string;
export {};
