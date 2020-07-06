import { Grid } from "./Grid";
import { IGridConfig } from "./types";
export declare class ProGrid extends Grid {
    constructor(container: HTMLElement | string, config?: IGridConfig);
    protected _setEventHandlers(): void;
    private _getColumnGhost;
}
