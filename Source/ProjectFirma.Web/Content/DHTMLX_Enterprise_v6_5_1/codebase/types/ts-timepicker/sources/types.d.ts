import { IEventSystem } from "../../ts-common/events";
import { Layout } from "../../ts-layout";
export interface ITimepickerConfig {
    css?: string;
    timeFormat?: 12 | 24;
    controls?: boolean;
    actions?: boolean;
}
export interface ITimepicker {
    config: ITimepickerConfig;
    events: IEventSystem<TimepickerEvents, ITimepickerHandlersMap>;
    layout: Layout;
    paint(): void;
    getValue(asOBject?: boolean): Record<string, any> | string;
    setValue(value: Date | number | string | any[]): void;
    clear(): void;
    destructor(): void;
}
export interface ITimeObject {
    hour: number;
    minute: number;
    AM?: boolean;
}
export declare enum TimepickerEvents {
    change = "change",
    apply = "apply",
    beforeClose = "beforeClose",
    afterClose = "afterClose",
    close = "close",
    save = "save"
}
export interface ITimepickerHandlersMap {
    [key: string]: (...args: any[]) => any;
    [TimepickerEvents.change]: (time?: Record<string, any> | string) => any;
    [TimepickerEvents.apply]: (time?: ITimeObject) => any;
    [TimepickerEvents.beforeClose]: () => boolean;
    [TimepickerEvents.afterClose]: () => any;
    [TimepickerEvents.close]: () => any;
    [TimepickerEvents.save]: (time?: ITimeObject) => any;
}
