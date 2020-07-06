import { DataCollection } from "../../ts-data";
export declare type ILabelPosition = "right" | "left" | "top" | "bottom";
export interface IComboboxConfig {
    data?: DataCollection<any> | any[];
    readonly?: boolean;
    disabled?: boolean;
    template?: (item: any) => string;
    filter?: (item: any, input: string) => boolean;
    multiselection?: boolean;
    label?: string;
    labelPosition?: ILabelPosition;
    labelWidth?: string | number;
    placeholder?: string;
    selectAllButton?: boolean;
    itemsCount?: boolean | ((count: number) => string);
    itemHeight?: number | string;
    virtual?: boolean;
    listHeight?: number | string;
    required?: boolean;
    helpMessage?: string;
    hiddenLabel?: boolean;
    css?: string;
    cellHeight?: number;
    help?: string;
    showItemsCount?: boolean | ((count: number) => string);
    labelInline?: boolean;
}
export interface IComboFilterConfig {
    data?: DataCollection<any> | any[];
    readonly?: boolean;
    template?: (item: any) => string;
    filter?: (item: any, input: string) => boolean;
    placeholder?: string;
    virtual?: boolean;
}
export declare enum ComboboxEvents {
    change = "change",
    open = "open",
    input = "input",
    beforeClose = "beforeClose",
    afterClose = "afterClose",
    close = "close"
}
export interface IComboboxEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [ComboboxEvents.change]: (ids: string | string[]) => any;
    [ComboboxEvents.open]: () => any;
    [ComboboxEvents.input]: (value: any) => any;
    [ComboboxEvents.beforeClose]: () => boolean;
    [ComboboxEvents.afterClose]: () => any;
    [ComboboxEvents.close]: () => any;
}
export interface ICombobox {
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    destructor(): void;
    paint(): void;
    clear(): void;
    focus(): void;
    getValue(asArray?: boolean): string[] | string;
    setValue(ids: string[] | string): void;
    setState(state: State): void;
}
export declare enum ComboState {
    default = 0,
    error = 1,
    success = 2
}
export declare type State = "success" | "error" | "default";
