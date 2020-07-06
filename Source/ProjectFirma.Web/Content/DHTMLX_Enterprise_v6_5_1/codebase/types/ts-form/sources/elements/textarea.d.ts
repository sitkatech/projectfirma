import { Input } from "./input";
import { ITextArea } from "../types";
export declare class Textarea extends Input {
    config: ITextArea & {
        type: any;
    };
    protected _draw(): any;
}
