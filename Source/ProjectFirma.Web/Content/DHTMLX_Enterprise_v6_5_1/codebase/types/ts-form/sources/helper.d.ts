import { Validation, ValidationFn } from "./types";
export declare function getFormItemCss(item: any, validate?: boolean): any;
export declare function getValidationMessage(item: any): any;
export declare function validateTemplate(template: Validation, str: any): boolean;
export declare function isBlock(config: any): any;
export declare function validateInput(value: string, validation: Validation | ValidationFn): boolean;
export declare function isTimeFormat(value: string, timeFormat?: number): boolean;
