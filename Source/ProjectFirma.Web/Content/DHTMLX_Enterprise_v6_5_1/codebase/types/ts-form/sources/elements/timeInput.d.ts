import { Timepicker } from "../../../ts-timepicker";
import { Label } from "./helper/label";
import { IEventSystem } from "../../../ts-common/events";
import { ITimeInput, IBaseTimepickerEventHandlersMap, BaseItemEvent } from "../types";
export declare class TimeInput extends Label {
    config: ITimeInput;
    timepicker: Timepicker;
    events: IEventSystem<BaseItemEvent, IBaseTimepickerEventHandlersMap>;
    private _popup;
    constructor(container: any, config: ITimeInput);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    setValue(value: string | Date): void;
    getValue(): string;
    clear(): void;
    getWidget(): Timepicker;
    setConfig(config: ITimeInput): void;
    protected _initView(config: ITimeInput): void;
    protected _getHandlers(): {
        onfocus: () => void;
        onkeyup: (e: KeyboardEvent) => void;
    };
    protected _inputValidate(value: string): string;
    protected _draw(): any;
}
