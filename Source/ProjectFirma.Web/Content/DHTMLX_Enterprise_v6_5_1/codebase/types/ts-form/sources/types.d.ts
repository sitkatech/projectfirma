import { IComboboxConfig } from "../../ts-combobox";
import { ICalendarConfig } from "../../ts-calendar";
import { ISliderConfig } from "../../ts-slider";
import { FileStatus, IParams } from "../../ts-vault";
import { ITimepickerConfig } from "../../ts-timepicker";
import { IColorpickerConfig } from "../../ts-colorpicker";
import { IEventSystem } from "../../ts-common/events";
import { Layout } from "../../ts-layout";
import { IAnyObj } from "../../ts-common/types";
export interface IForm {
    config: IFormConfig;
    events: IEventSystem<FormEvents, IFormEventHandlersMap>;
    layout: Layout;
    paint(): void;
    destructor(): void;
    disable(): void;
    enable(): void;
    isDisabled(id?: string): boolean;
    show(): void;
    hide(): void;
    isVisible(id?: string): boolean;
    validate(): boolean;
    send(url: string, method?: string, asFormData?: boolean): Promise<any> | void;
    clear(method?: ClearMethod): void;
    setValue(obj: FormData | IAnyObj): void;
    getValue(asFormData?: boolean): FormData | IAnyObj;
    getItem(id: string): any;
    forEach(callback: FormDataCallback): void;
}
export interface IBlockConfig {
    rows?: IBlock & any;
    cols?: IBlock & any;
    width?: string;
    height?: string;
    padding?: string;
    align?: "start" | "center" | "end" | "between" | "around" | "evenly";
    css?: string;
    title?: string;
    gravity?: boolean;
}
export interface IFormConfig extends IBlockConfig {
    disabled?: boolean;
    hidden?: boolean;
    group?: FormItemType;
    groupName?: string;
    cellCss?: string;
}
export declare enum FormEvents {
    change = "change",
    buttonClick = "buttonclick",
    validationFail = "validationfail",
    beforeSend = "beforesend",
    afterSend = "aftersend",
    beforeShow = "beforeShow",
    afterShow = "afterShow",
    beforeHide = "beforeHide",
    afterHide = "afterHide"
}
export interface IFormEventHandlersMap {
    [key: string]: (...args: any[]) => any;
    [FormEvents.change]: (name: string, value: any) => any;
    [FormEvents.buttonClick]: (id: string, e: MouseEvent) => any;
    [FormEvents.validationFail]: (id: string, component: any) => any;
    [FormEvents.beforeSend]: () => boolean;
    [FormEvents.afterSend]: () => void;
    [FormEvents.beforeHide]: (id: string) => boolean;
    [FormEvents.afterHide]: (id: string) => void;
    [FormEvents.beforeShow]: (id: string) => boolean;
    [FormEvents.afterShow]: (id: string) => void;
}
export interface IBaseItem {
    config: IItem;
    events: IEventSystem<IBaseHandlersMap>;
    show(): void;
    hide(init?: boolean): void;
    isVisible(): boolean;
    disable(): void;
    enable(): void;
    isDisabled(): boolean;
    validate(): boolean;
    clearValidate(): void;
    setValue(value: any): void;
    getValue(): any;
    clear(): void;
    getWidget(): any;
}
export declare enum FormItemType {
    input = "input",
    button = "button",
    combo = "combo",
    slider = "slider",
    radioButton = "radioButton",
    radioGroup = "radioGroup",
    checkbox = "checkbox",
    select = "select",
    simpleVault = "simpleVault",
    textarea = "textarea",
    timepicker = "timepicker",
    datepicker = "datepicker",
    colorpicker = "colorpicker",
    text = "text"
}
export interface IItem {
    type?: FormItemType;
    name?: string;
    id?: string;
    width?: string;
    height?: string;
    css?: string;
    disabled?: boolean;
    required?: boolean;
    label?: string;
    labelWidth?: string | number;
    labelPosition?: ILabelPosition;
    hiddenLabel?: boolean;
    helpMessage?: string;
    preMessage?: string;
    successMessage?: string;
    errorMessage?: string;
    gravity?: boolean;
    hidden?: boolean;
    $validationStatus?: ValidationStatus;
    help?: string;
    cellCss?: string;
    labelInline?: boolean;
}
export interface IRadioGroup {
    type?: FormItemType.radioGroup;
    name?: string;
    id?: string;
    options: IRadioGroupOption;
    value?: string;
    width?: string;
    height?: string;
    css?: string;
    disabled?: boolean;
    hidden?: boolean;
    required?: boolean;
    gravity?: boolean;
    preMessage?: string;
    successMessage?: string;
    errorMessage?: string;
    $validationStatus?: ValidationStatus;
    cellCss?: string;
}
export interface IRadioGroupOption {
    rows?: IRadioButton[];
    cols?: IRadioButton[];
    width?: string;
    height?: string;
    padding?: string;
    css?: string;
    align?: "start" | "center" | "end" | "between" | "around" | "evenly";
    gravity?: boolean;
    cellCss?: string;
}
export interface IRadioButton extends IItem {
    type?: FormItemType.radioButton;
    checked?: boolean;
    value?: string;
}
export interface IInput extends IItem {
    type?: FormItemType.input;
    inputType?: string;
    value?: string;
    validation?: Validation | ValidationFn;
    icon?: string;
    placeholder?: string;
    autocomplete?: boolean;
    readOnly?: boolean;
    maxlength?: string;
}
export interface IText extends IItem {
    type?: FormItemType.text;
    value?: string;
}
export interface IButton extends IItem {
    type?: FormItemType.button;
    submit?: boolean;
    url?: string;
    value?: string;
    icon?: string;
    view?: "flat" | "link";
    size?: "small" | "medium";
    color?: "danger" | "secondary" | "primary" | "success";
    full?: boolean;
    circle?: boolean;
    loading?: boolean;
}
export interface ICombo extends IItem, IComboboxConfig {
    type?: FormItemType.combo;
    value?: string | string[];
    data?: any[];
    validation?: ValidationFn;
}
export interface ISlider extends IItem, ISliderConfig {
    type?: FormItemType.slider;
}
export interface ICheckbox extends IItem {
    type?: FormItemType.checkbox;
    checked?: boolean;
    value?: string;
}
export interface ITimeInput extends IItem, ITimepickerConfig {
    type?: FormItemType.timepicker;
    value?: string;
    validation?: ValidationFn;
    icon?: string;
    placeholder?: string;
    editable?: boolean;
    editing?: boolean;
}
export declare type IDatepickerValueFormat = "string" | "Date";
export interface IDatepickerInput extends IItem, ICalendarConfig {
    type?: FormItemType.datepicker;
    value?: string;
    validation?: ValidationFn;
    icon?: string;
    placeholder?: string;
    editable?: boolean;
    valueFormat?: IDatepickerValueFormat;
    editing?: boolean;
}
export interface IColorpickerInput extends IItem, IColorpickerConfig {
    type?: FormItemType.colorpicker;
    value?: string;
    validation?: ValidationFn;
    icon?: string;
    placeholder?: string;
    editable?: boolean;
    editing?: boolean;
}
export interface IOption {
    value: string;
    content?: string;
    disabled?: boolean;
    selected?: boolean;
}
export interface ISelect extends IItem {
    validation?: ValidationFn;
    type?: FormItemType.select;
    options: IOption[];
    value?: string;
    icon?: string;
}
export interface ISimpleValue {
    id: string;
    file?: File;
    status?: FileStatus;
    progress?: number;
    link?: string;
    request?: XMLHttpRequest;
    path?: string;
    name?: string;
    size?: number;
}
export interface ISimpleVault extends IItem {
    type?: FormItemType.simpleVault;
    target?: string;
    singleRequest?: boolean;
    fieldName?: string;
    value?: ISimpleValue[];
    params?: IParams;
    $vaultHeight?: number | string;
}
export interface ITextArea extends IItem {
    type?: FormItemType.textarea;
    value?: string;
    validation?: Validation | ValidationFn;
    resizable?: boolean;
    placeholder?: string;
    readOnly?: boolean;
}
export declare type ILabelPosition = "right" | "left" | "top" | "bottom";
export interface ILabel {
    helpMessage?: string;
    id?: string;
    labelPosition?: ILabelPosition;
    label?: string;
    labelWidth?: string | number;
    help?: string;
    labelInline?: boolean;
}
export declare type IItemConfig = IInput | IButton | ICombo | ISlider | ICheckbox | IRadioButton | IDatepickerInput | ISelect | ISimpleVault | ITextArea | ITimeInput | IText | IColorpickerInput | IRadioGroup;
export declare type IBlock = IBlockConfig & IItemConfig[];
export declare enum BaseItemEvent {
    change = "change",
    configUpdate = "configUpdate",
    changeOptions = "changeOptions",
    show = "show",
    hide = "hide"
}
export interface IBaseHandlersMap {
    [key: string]: (...args: any[]) => any;
}
export interface IBaseButtonHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseCheckboxEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: boolean) => void;
    [BaseItemEvent.configUpdate]: (config: ICheckbox) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseColorpickerEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: IColorpickerInput) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseComboEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string | string[]) => void;
    [BaseItemEvent.configUpdate]: (config: ICombo) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseDatepickerEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: IDatepickerInput) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseRadioGroupEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: () => void;
    [BaseItemEvent.configUpdate]: (config: IRadioGroup) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseSelectEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: ISelect) => void;
    [BaseItemEvent.changeOptions]: (id: string, options: IOption[]) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseSliderEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string | number | number[]) => void;
    [BaseItemEvent.configUpdate]: (config: ISlider) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseTimepickerEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: ITimeInput) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseSimpleVaultEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: ITimeInput) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export interface IBaseInputEventHandlersMap extends IBaseHandlersMap {
    [BaseItemEvent.change]: (arg: string) => void;
    [BaseItemEvent.configUpdate]: (config: IInput | ITextArea | IText) => void;
    [BaseItemEvent.hide]: (id: string, init?: boolean) => void;
    [BaseItemEvent.show]: (id: string) => void;
}
export declare type FormDataCallback = (item: IFormConfig, index: number, array: any) => any;
export declare type ValidationFn = (input: string) => boolean;
export declare enum ClearMethod {
    value = "value",
    validation = "validation"
}
export declare enum Validation {
    empty = "",
    validEmail = "email",
    validInteger = "integer",
    validNumeric = "numeric",
    validAplhaNumeric = "alphanumeric",
    validIPv4 = "IPv4"
}
export declare enum ValidationStatus {
    pre = 0,
    error = 1,
    success = 2
}
