import { Grid } from "./Grid";
import { IGridConfig, IRow } from "./types";
import { IDataCollection, IDataItem } from "../../ts-data";
export declare class ProGrid extends Grid {
    constructor(container: HTMLElement | string, config?: IGridConfig);
    protected _setEventHandlers(): void;
    protected _prepareData(data: IDataItem[] | IDataCollection): IDataItem[] | IRow[];
    protected _prepareDataFromTo(data: IDataCollection, from: number, to: number): IDataItem[];
    private _lazyLoad;
    private _getColumnGhost;
    private _dragStartColumn;
}
