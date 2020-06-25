import { Colorpicker } from "../../../ts-colorpicker";
import { IEventSystem } from "../../../ts-common/events";
import { Label } from "./helper/label";
import { IColorpickerInput, BaseItemEvent, IBaseColorpickerEventHandlersMap } from "../types";
export declare class ColorpickerInput extends Label {
    config: IColorpickerInput;
    colorpicker: Colorpicker;
    events: IEventSystem<BaseItemEvent, IBaseColorpickerEventHandlersMap>;
    private _popup;
    constructor(container: any, config: IColorpickerInput);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    setValue(value: string): void;
    getValue(): string;
    clear(): void;
    getWidget(): Colorpicker;
    setConfig(config: IColorpickerInput): void;
    protected _initView(config: IColorpickerInput): void;
    protected _getHandlers(): {
        onfocus: () => void;
        onchange: (e: Event) => void;
        onkeyup: (e: KeyboardEvent) => void;
    };
    protected _inputValidate(value: string): string;
    protected _draw(): any;
}
