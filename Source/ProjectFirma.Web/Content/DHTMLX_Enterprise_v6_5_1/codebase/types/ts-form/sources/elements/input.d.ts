import { Label } from "./helper/label";
import { IEventSystem } from "../../../ts-common/events";
import { IInput, IBaseInputEventHandlersMap, BaseItemEvent } from "../types";
export declare class Input extends Label {
    config: IInput;
    events: IEventSystem<BaseItemEvent, IBaseInputEventHandlersMap>;
    private _debounceTimer;
    constructor(container: HTMLElement | string, config?: {});
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    clear(): void;
    setValue(value: string): void;
    getValue(): string;
    setConfig(config: IInput): void;
    protected _initView(config: IInput): void;
    protected _init(): void;
    protected _getHandlers(): {
        oninput: (e: Event) => void;
        onblur: () => void;
    };
    protected _draw(): any;
    private _validate;
}
