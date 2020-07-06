export declare enum Direction {
    vertical = "vertical",
    horizontal = "horizontal"
}
export interface ISlider {
    config: ISliderConfig;
    paint(): void;
    destructor(): void;
    getValue(): number[];
    setValue(value: string | number | number[]): void;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
}
export declare enum SliderEvents {
    change = "change",
    mousedown = "mousedown",
    mouseup = "mouseup"
}
export declare type ILabelPosition = "right" | "left" | "top" | "bottom";
export interface ISliderConfig {
    min: number;
    max: number;
    step: number;
    mode?: Direction;
    range?: boolean;
    value?: number[] | number | string;
    inverse?: boolean;
    tooltip?: boolean;
    css?: string;
    tick?: number;
    tickTemplate?: (position: number) => string;
    majorTick?: number;
    label?: string;
    required?: boolean;
    helpMessage?: string;
    labelPosition?: ILabelPosition;
    labelWidth?: string | number;
    hiddenLabel?: boolean;
    help?: string;
    thumbLabel?: boolean;
    labelInline?: boolean;
}
