import { IViewLike, View } from "../../ts-common/view";
import { ICell, ICellConfig, ILayout, LayoutEvents, ILayoutEventHandlersMap } from "./types";
import { IEventSystem } from "../../ts-common/events";
export declare class Cell extends View implements ICell {
    id: string;
    config: ICellConfig;
    events: IEventSystem<LayoutEvents, ILayoutEventHandlersMap>;
    protected _handlers: {
        [key: string]: (...args: any) => any;
    };
    protected _disabled: string[];
    private _parent;
    private _ui;
    private _resizerHandlers;
    constructor(parent: string | HTMLElement | ILayout, config: ICellConfig);
    paint(): void;
    isVisible(): boolean;
    hide(): void;
    show(): void;
    expand(): void;
    collapse(): void;
    toggle(): void;
    getParent(): ILayout;
    destructor(): void;
    getWidget(): IViewLike;
    getCellView(): any;
    attach(name: any, config?: any): IViewLike;
    attachHTML(html: string): void;
    toVDOM(nodes?: any[]): any;
    protected _getCss(_content?: boolean): string;
    protected _initHandlers(): void;
    private _getCollapseIcon;
    private _isLastCell;
    private _getNextCell;
    private _getResizerView;
    private _isXDirection;
    private _calculateStyle;
}
