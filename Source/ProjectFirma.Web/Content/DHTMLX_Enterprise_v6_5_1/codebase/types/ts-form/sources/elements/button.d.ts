import { View } from "../../../ts-common/view";
import { IButton, IBaseButtonHandlersMap } from "../types";
import { IEventSystem } from "../../../ts-common/events";
export declare enum ButtonEvents {
    click = "click"
}
export declare class Button extends View {
    config: IButton;
    events: IEventSystem<ButtonEvents, IBaseButtonHandlersMap>;
    private _handlers;
    constructor(container: HTMLElement | string, config: any);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    setValue(value: string): void;
    protected _draw(): any;
}
