import { DataCollection } from "../datacollection";
import { IDataDriver, IDataProxy } from "../types";
export declare class Loader {
    private _parent;
    private _saving;
    private _changes;
    constructor(parent: DataCollection, changes: any);
    load(url: IDataProxy, driver?: IDataDriver): Promise<any>;
    parse(data: any | any[], driver?: any): any;
    save(url: IDataProxy): void;
    private _setPromise;
    private _addToChain;
    private _findPrevState;
    private _removeFromOrder;
}
