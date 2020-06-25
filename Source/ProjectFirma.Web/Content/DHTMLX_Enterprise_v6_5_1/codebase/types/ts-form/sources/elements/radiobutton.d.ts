import { IEventSystem } from "../../../ts-common/events";
import { View } from "../../../ts-common/view";
import { Popup } from "../../../ts-popup";
import { IRadioButton } from "../types";
export declare enum RadioButtonEvents {
    change = "change"
}
export declare class RadioButton extends View {
    config: IRadioButton;
    events: IEventSystem<RadioButtonEvents>;
    protected _handlers: any;
    protected _helper: Popup;
    constructor(container: HTMLElement | string, config?: {});
    clearValidate(): void;
    clear(): void;
    getValue(): string | void;
    setValue(checked: boolean): void;
    destructor(): void;
    private _draw;
}
