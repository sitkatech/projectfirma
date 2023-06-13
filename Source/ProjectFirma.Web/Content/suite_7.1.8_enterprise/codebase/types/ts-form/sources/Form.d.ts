import { IEventSystem } from "../../ts-common/events";
import { View } from "../../ts-common/view";
import { Layout } from "../../ts-layout";
import { IAnyObj } from "../../ts-common/types";
import { FormEvents, IFormEventHandlersMap, IForm, ClearMethod, IFormConfig, FormDataCallback, IFormProps } from "./types";
export declare class Form extends View implements IForm {
    config: IFormConfig;
    events: IEventSystem<FormEvents, IFormEventHandlersMap>;
    layout: Layout;
    private _attachments;
    private _state;
    private container;
    private _isValid;
    constructor(container: HTMLElement | string, config: IFormConfig);
    send(url: string, method?: string, asFormData?: boolean): Promise<any> | void;
    clear(method?: ClearMethod): void;
    setValue(obj: IAnyObj): void;
    getValue<T extends boolean = false>(asFormData?: boolean): T extends true ? FormData : IAnyObj;
    getItem(name: string): any;
    validate(silent?: boolean): boolean;
    setProperties(arg: string | {
        [name: string]: IFormProps;
    }, props?: IFormProps): void;
    getProperties(name?: string): {
        [name: string]: IFormProps;
    } | IFormProps;
    show(): void;
    hide(init?: boolean): void;
    setFocus(name: string): void;
    isVisible(name?: string): boolean;
    disable(): void;
    enable(): void;
    isDisabled(name?: string): boolean;
    forEach(callback: FormDataCallback): void;
    destructor(): void;
    getRootView(): any;
    private _addLayoutItem;
    private _changeProps;
    private _addLayoutItems;
    private _checkLayoutConfig;
    private _createLayoutConfig;
    private _initUI;
    private _clear;
    private _clearValidate;
    private _formContainerShow;
    private _formContainerHide;
    private _send;
}
