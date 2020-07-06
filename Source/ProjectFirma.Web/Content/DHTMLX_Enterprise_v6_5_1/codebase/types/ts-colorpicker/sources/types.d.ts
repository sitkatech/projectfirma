import { IEventSystem } from "../../ts-common/events";
export interface IColorpicker {
    events: IEventSystem<ColorpickerEvents>;
    paint(): void;
    destructor(): void;
    clear(): void;
    setCustomColors(customColors: string[]): void;
    setValue(value: string): void;
    setCurrentMode(view: ViewsMode): void;
    setFocus(value: string): void;
    getCustomColors(): string[];
    getValue(): string;
    getCurrentMode(): ViewsMode;
    getView(): ViewsMode;
    setView(view: ViewsMode): void;
    focusValue(value: string): void;
}
export interface IColorpickerConfig {
    css?: string;
    grayShades?: boolean;
    customColors?: string[];
    palette?: string[][];
    width?: string;
    mode?: ViewsMode;
    pickerOnly?: boolean;
    paletteOnly?: boolean;
}
export declare enum ColorpickerEvents {
    change = "change",
    apply = "apply",
    cancelClick = "cancelClick",
    modeChange = "modeChange",
    selectClick = "selectClick",
    colorChange = "colorChange",
    viewChange = "viewChange"
}
export interface IEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [ColorpickerEvents.change]: (color: string) => void;
    [ColorpickerEvents.selectClick]: () => void;
    [ColorpickerEvents.cancelClick]: () => void;
    [ColorpickerEvents.modeChange]: (view: ViewsMode) => void;
    [ColorpickerEvents.colorChange]: (color: string) => void;
    [ColorpickerEvents.viewChange]: (view: ViewsMode) => void;
}
export interface IHSV {
    h: number;
    s: number;
    v: number;
}
export interface IPickerState {
    hsv: IHSV;
    customHex: string;
    background?: string;
    rangeLeft?: number;
}
export declare enum ViewsMode {
    palette = "palette",
    picker = "picker"
}
