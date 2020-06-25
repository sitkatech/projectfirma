import { Layout } from "../../../ts-layout";
import { IEventSystem } from "../../../ts-common/events";
import { View } from "../../../ts-common/view";
import { IRadioGroup, IBaseRadioGroupEventHandlersMap, BaseItemEvent } from "../types";
export declare class RadioGroup extends View {
    config: IRadioGroup;
    layout: Layout;
    events: IEventSystem<BaseItemEvent, IBaseRadioGroupEventHandlersMap>;
    private _buttons;
    constructor(container: any, config: IRadioGroup);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    clear(): void;
    getValue(): string;
    setValue(value: string): void;
    setConfig(config: IRadioGroup): void;
    protected _initView(config: IRadioGroup): void;
    private _draw;
}
