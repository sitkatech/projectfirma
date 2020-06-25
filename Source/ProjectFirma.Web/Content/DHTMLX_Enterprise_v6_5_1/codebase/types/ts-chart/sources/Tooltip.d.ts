import { View } from "../../ts-common/view";
export declare class Tooltip extends View {
    private _lastPointRef;
    private _chart;
    private _state;
    constructor(container: any, config: any);
    destructor(): void;
    private _hide;
    private _enableActivePoint;
    private _disableLastActivePoint;
    private _draw;
}
