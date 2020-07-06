import { Combobox } from "../../../ts-combobox";
import { IEventSystem } from "../../../ts-common/events";
import { Label } from "./helper/label";
import { ICombo, BaseItemEvent, IBaseComboEventHandlersMap } from "../types";
export declare class Combo extends Label {
    config: ICombo;
    combobox: Combobox;
    events: IEventSystem<BaseItemEvent, IBaseComboEventHandlersMap>;
    private _changeClear;
    constructor(container: any, config: ICombo);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    clear(): void;
    getValue(): string | string[];
    setValue(value: string | string[]): void;
    validate(): boolean;
    clearValidate(): void;
    getWidget(): Combobox;
    setConfig(config: ICombo): void;
    protected _initView(config: ICombo): void;
    protected _validationStatus(): void;
    protected _getRootView(): any;
    protected _draw(): any;
}
