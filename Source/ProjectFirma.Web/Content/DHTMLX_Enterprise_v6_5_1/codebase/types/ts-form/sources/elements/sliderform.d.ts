import { Slider } from "../../../ts-slider";
import { IEventSystem } from "../../../ts-common/events";
import { Label } from "./helper/label";
import { ISlider, BaseItemEvent, IBaseSliderEventHandlersMap } from "../types";
export declare class SliderForm extends Label {
    config: ISlider;
    slider: Slider;
    events: IEventSystem<BaseItemEvent, IBaseSliderEventHandlersMap>;
    constructor(container: any, config: ISlider);
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    clear(): void;
    getValue(): number[];
    setValue(value: string | number | number[]): void;
    validate(): boolean;
    getWidget(): Slider;
    setConfig(config: ISlider): void;
    protected _initView(config: ISlider): void;
    protected _getRootView(): any;
    protected _drawSlider(): any;
}
