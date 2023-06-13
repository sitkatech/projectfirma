import { Input } from "./input";
import { ITextAreaConfig, ITextArea, ITextareaProps } from "../types";
export declare class Textarea extends Input implements ITextArea {
    config: ITextAreaConfig & {
        type: any;
    };
    protected _propsItem: string[];
    protected _props: string[];
    setValue(value: string): void;
    getValue(): string;
    focus(): void;
    setProperties(propertyConfig: ITextareaProps): void;
    getProperties(): ITextareaProps;
    protected _initView(config: ITextAreaConfig): void;
    protected _draw(): any;
}
