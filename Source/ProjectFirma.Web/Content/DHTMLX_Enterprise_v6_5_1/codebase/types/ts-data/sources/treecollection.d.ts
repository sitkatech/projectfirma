import { IEventSystem } from "../../ts-common/events";
import { DataCollection } from "./datacollection";
import { DataCallback, DataEvents, Id, IDataCollection, IDataItem, ITreeCollection, IFilterCallback, IFilterMode, ITreeFilterConfig, DataDriver, ISortMode } from "./types";
export declare class TreeCollection<T extends IDataItem = IDataItem> extends DataCollection<T> implements ITreeCollection<T> {
    protected _childs: {
        [id: string]: T[];
    };
    protected _root: Id;
    protected _filters: {
        [id: string]: {
            rule: IFilterMode | IFilterCallback;
            config: ITreeFilterConfig;
        };
    };
    private _initChilds;
    constructor(config?: any, events?: IEventSystem<DataEvents>);
    add(obj: IDataItem, index?: number, parent?: Id): Id;
    add(obj: IDataItem[], index?: number, parent?: Id): Id[];
    getRoot(): Id;
    getParent(id: Id, asObj?: boolean): Id;
    getItems(id: Id): T[];
    getLength(id?: Id): number;
    removeAll(id?: Id): void;
    getIndex(id: Id): number;
    sort(by?: ISortMode): void;
    filter(rule?: IFilterMode | IFilterCallback, config?: ITreeFilterConfig): void;
    restoreOrder(): void;
    copy(id: Id, index: number, target: IDataCollection | ITreeCollection, targetId: Id): Id;
    copy(id: Id[], index: number, target: IDataCollection | ITreeCollection, targetId: Id): Id[];
    move(id: Id, index: number, target: ITreeCollection | IDataCollection, targetId: Id): Id;
    move(id: Id[], index: number, target: ITreeCollection | IDataCollection, targetId: Id): Id[];
    forEach(cb: DataCallback<any>, parent?: Id, level?: number): void;
    eachChild(id: Id, cb: DataCallback<T>, direct?: boolean, checkItem?: (item: IDataItem) => boolean): void;
    getNearId(id: Id): Id;
    loadItems(id: Id, driver?: any): void;
    refreshItems(id: Id, driver?: any): void;
    eachParent(id: Id, cb: DataCallback<T>, self?: boolean): void;
    haveItems(id: Id): boolean;
    canCopy(id: Id, target: Id): boolean;
    serialize(driver?: DataDriver, checkItem?: (item: any) => any): any;
    getId(index: number, parent?: string): string;
    map(cb: DataCallback<T>, parent?: Id, direct?: boolean): any[];
    protected _add(obj: IDataItem, index?: number, parent?: Id, key?: number): Id;
    protected _copy(id: Id, index: number, target?: IDataCollection | ITreeCollection, targetId?: Id, key?: number): Id;
    protected _move(id: Id, index: number, target?: ITreeCollection | IDataCollection, targetId?: Id, key?: number): Id;
    protected _removeAll(id?: Id): void;
    protected _removeCore(id: any): void;
    protected _addToOrder(_order: any, obj: any, index: number): void;
    protected _parse_data(data: any, parent?: string): void;
    private _fastDeleteChilds;
    private _recursiveFilter;
    private _serialize;
}
