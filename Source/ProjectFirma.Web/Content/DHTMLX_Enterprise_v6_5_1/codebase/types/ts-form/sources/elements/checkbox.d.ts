import { IEventSystem } from "../../../ts-common/events";
import { View } from "../../../ts-common/view";
import { Popup } from "../../../ts-popup";
import { ICheckbox, BaseItemEvent, IBaseCheckboxEventHandlersMap } from "../types";
export declare class Checkbox extends View {
    config: ICheckbox;
    events: IEventSystem<BaseItemEvent, IBaseCheckboxEventHandlersMap>;
    protected _handlers: any;
    protected _helper: Popup;
    constructor(container: HTMLElement | string, config?: {});
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    clear(): void;
    clearValidate(): void;
    setValue(value: boolean): void;
    getValue(): boolean;
    setConfig(config: ICheckbox): void;
    validate(): boolean;
    protected _initView(config: ICheckbox): void;
    private _draw;
}
