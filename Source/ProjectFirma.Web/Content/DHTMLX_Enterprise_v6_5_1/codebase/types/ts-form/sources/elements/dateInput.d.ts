import { Calendar } from "../../../ts-calendar";
import { IEventSystem } from "../../../ts-common/events";
import { Label } from "./helper/label";
import { IDatepickerInput, IBaseDatepickerEventHandlersMap, BaseItemEvent } from "../types";
export declare class DateInput extends Label {
    config: IDatepickerInput;
    calendar: Calendar;
    events: IEventSystem<BaseItemEvent, IBaseDatepickerEventHandlersMap>;
    private _popup;
    constructor(container: any, config: IDatepickerInput);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    setValue(value: string | Date): void;
    getValue<T extends boolean = false>(asDateObject?: T): string;
    clear(): void;
    getWidget(): Calendar;
    setConfig(config: IDatepickerInput): void;
    protected _initView(config: IDatepickerInput): void;
    protected _getHandlers(): {
        onfocus: () => void;
        onchange: (e: Event) => void;
        onkeyup: (e: KeyboardEvent) => void;
    };
    protected _inputValidate(value: string): string;
    protected _draw(): any;
}
