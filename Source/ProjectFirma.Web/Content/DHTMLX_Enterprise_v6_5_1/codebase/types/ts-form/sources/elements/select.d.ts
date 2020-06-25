import { Label } from "./helper/label";
import { IEventSystem } from "../../../ts-common/events";
import { ISelect, BaseItemEvent, IBaseSelectEventHandlersMap, IOption } from "../types";
export declare class Select extends Label {
    config: ISelect;
    events: IEventSystem<BaseItemEvent, IBaseSelectEventHandlersMap>;
    constructor(container: any, config: ISelect);
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
    setOptions(options: IOption[]): void;
    getOptions(): IOption[];
    setConfig(config: ISelect): void;
    protected _initView(config: ISelect): void;
    protected _getHandlers(): {
        onchange: (e: Event) => void;
    };
    protected _draw(): any;
}
