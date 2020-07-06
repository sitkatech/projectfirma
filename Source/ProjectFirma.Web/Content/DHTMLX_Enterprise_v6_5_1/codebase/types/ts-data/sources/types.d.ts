import { IEventSystem } from "../../ts-common/events";
import { DataCollection } from "./datacollection";
import { TreeCollection } from "./treecollection";
import { anyFunction, IAnyObj } from "../../ts-common/types";
export declare type Id = string;
export interface IDataProxy {
    url: string;
    config: any;
    updateUrl: (url?: string, params?: any) => void;
    load: () => Promise<any[]>;
    save: (data: any, mode: string) => Promise<any>;
}
export interface ILazyDataProxy extends IDataProxy {
    config: ILazyConfig;
}
export interface ILazyConfig {
    from?: number;
    limit?: number;
    delay?: number;
    prepare?: number;
}
export interface ISortMode {
    by?: string;
    dir?: string;
    as?: (a: any) => any;
    rule?: (a: any, b: any) => number;
}
export declare type IFilterCallback = (obj: any) => boolean;
export interface IFilterMode {
    by?: string;
    match?: string | number | boolean;
    compare?: (value: any, match: any, obj: any) => boolean;
}
export interface IFilterConfig {
    add?: boolean;
    multiple?: boolean;
}
export interface ITreeFilterConfig extends IFilterConfig {
    type?: TreeFilterType;
    level?: number;
}
export interface IUpdateObject {
    [key: string]: any;
}
export interface IApproximate {
    value: any;
    maxNum: number;
}
export interface IDataConfig {
    prep?: anyFunction;
    init?: anyFunction;
    update?: anyFunction;
    approximate?: IApproximate;
    autoload?: boolean;
}
export interface IDataCollection<T extends IDataItem = IDataItem> {
    config: IDataConfig;
    events: IEventSystem<DataEvents>;
    dataProxy: IDataProxy;
    loadData: Promise<any>;
    saveData: Promise<any>;
    load(url: IDataProxy): Promise<any>;
    parse(data: T[]): any;
    add(obj: IDataItem, index?: number): Id;
    add(obj: IDataItem[], index?: number): Id[];
    add(obj: IDataItem | IDataItem[], index?: number): Id | Id[];
    remove(id: Id | Id[]): void;
    removeAll(): void;
    update(id: Id, obj: IUpdateObject, silent?: boolean): void;
    exists(id: Id): boolean;
    getInitialData(): T[];
    getItem(id: Id): T;
    getIndex(id: Id): number;
    getLength(): number;
    isDataLoaded(from?: number, to?: number): boolean;
    getId(index: number): Id;
    filter(rule?: IFilterMode | IFilterCallback, config?: IFilterConfig): void;
    find(rule: IFilterMode): T;
    reduce<A>(cb: ReduceCallBack<T, A>, acc: A): A;
    findAll(rule: IFilterMode): T[];
    map(cb: DataCallback<T>): T[];
    mapRange(from: number, to: number, cb: DataCallback<T>): any[];
    sort(by: ISortMode): void;
    serialize(driver?: DataDriver): T[];
    copy(id: Id | Id[], index: number, target?: IDataCollection | ITreeCollection, targetId?: Id): Id | Id[];
    move(id: Id | Id[], index: number, target?: DataCollection | TreeCollection, targetId?: Id): Id | Id[];
    changeId(id: Id, newId?: Id, silent?: boolean): void;
    forEach(cb: DataCallback<T>): void;
    save(url: IDataProxy): void;
    isSaved(): boolean;
}
export interface IDataChangeStack {
    order: IDataChange[];
}
export declare type Statuses = "add" | "update" | "remove";
export interface IDataChange {
    id: Id;
    status: Statuses;
    obj: any;
    saving: boolean;
    promise?: Promise<any>;
    pending?: boolean;
    error?: boolean;
}
export declare type RequestStatus = "saving" | "pending" | "error";
export interface IDir {
    [key: string]: any;
    asc: number;
    desc: number;
}
export interface IDataDriver {
    toJsonArray(data: any): any[];
    serialize(data: IAnyObj[]): any;
    getRows(data: string): any[];
    getFields(row: any): {
        [key: string]: any;
    };
}
export interface ICsvDriverConfig {
    skipHeader?: number;
    nameByHeader?: boolean;
    names?: string[];
    rowDelimiter?: string;
    columnDelimiter?: string;
}
export declare enum TreeFilterType {
    all = "all",
    level = "level",
    leafs = "leafs"
}
export declare type DataCallback<T> = (item: T, index?: number, array?: T[]) => any;
export declare type ReduceCallBack<T, A> = (acc: A, item: T, index?: number) => A;
export interface ITreeCollection<T extends IDataItem = IDataItem> extends IDataCollection<T> {
    add(obj: IDataItem, index?: number, parent?: Id): Id;
    add(obj: IDataItem[], index?: number, parent?: Id): Id[];
    add(obj: IDataItem | IDataItem[], index?: number, parent?: Id): Id | Id[];
    getRoot(): Id;
    getParent(id: Id): Id;
    removeAll(id?: Id): void;
    getLength(id?: Id): number;
    getIndex(id: Id): number;
    getItems(id: Id): T[];
    sort(conf?: any): void;
    map(cb: DataCallback<T>, parent?: Id, direct?: boolean): any;
    filter(rule?: IFilterMode | IFilterCallback, config?: ITreeFilterConfig): void;
    restoreOrder(): void;
    copy(id: Id, index: number, target: IDataCollection | ITreeCollection, targetId: Id): Id;
    copy(id: Id[], index: number, target: IDataCollection | ITreeCollection, targetId: Id): Id[];
    copy(id: Id | Id[], index: number, target: IDataCollection | ITreeCollection, targetId: Id): Id | Id[];
    move(id: Id, index: number, target: ITreeCollection | IDataCollection, targetId: Id): Id;
    move(id: Id[], index: number, target: ITreeCollection | IDataCollection, targetId: Id): Id[];
    move(id: Id | Id[], index: number, target: ITreeCollection | IDataCollection, targetId: Id): Id | Id[];
    eachChild(id: Id, cb: DataCallback<T>, direct?: boolean, checkItem?: (item: IDataItem) => boolean): void;
    eachParent(id: Id, cb: DataCallback<T>, self?: boolean): void;
    loadItems(id: Id, driver?: any): void;
    refreshItems(id: Id, driver?: any): void;
    haveItems(id: Id): boolean;
    canCopy(id: Id, target: Id): boolean;
    forEach(cb: DataCallback<T>, parent?: Id, level?: number): void;
}
export interface IDataItem {
    id?: string;
    [key: string]: any;
}
export declare enum DropPosition {
    top = "top",
    bot = "bot",
    in = "in"
}
export interface IObjWithData {
    data: TreeCollection | DataCollection;
    events: IEventSystem<DragEvents, IDragEventsHandlersMap>;
    config: IDragConfig;
    id?: string;
}
export interface ITransferData {
    initXOffset?: number;
    initYOffset?: number;
    x?: number;
    y?: number;
    ghost?: HTMLElement;
    targetId?: Id;
    id?: Id;
    dragConfig?: IDragConfig;
    target?: IObjWithData;
    dropPosition?: DropPosition;
    item?: HTMLElement;
}
export interface IDragConfig {
    dragCopy?: boolean;
    dropBehaviour?: DropBehaviour;
    dragMode?: DragMode;
}
export interface ICopyObject {
    id: string;
    target: IObjWithData;
}
export declare enum DataEvents {
    afterAdd = "afteradd",
    beforeAdd = "beforeadd",
    removeAll = "removeall",
    beforeRemove = "beforeremove",
    afterRemove = "afterremove",
    change = "change",
    load = "load",
    loadError = "loaderror",
    beforeLazyLoad = "beforelazyload",
    afterLazyLoad = "afterlazyload"
}
export declare enum DragEvents {
    beforeDrag = "beforedrag",
    beforeDrop = "beforeDrop",
    dragStart = "dragstart",
    dragEnd = "dragend",
    canDrop = "candrop",
    cancelDrop = "canceldrop",
    dropComplete = "dropcomplete",
    dragOut = "dragOut",
    dragIn = "dragIn",
    beforeColumnDrag = "beforeColumnDrag",
    beforeColumnDrop = "beforeColumnDrop"
}
export declare enum DragMode {
    target = "target",
    both = "both",
    source = "source"
}
export declare enum DropBehaviour {
    child = "child",
    sibling = "sibling",
    complex = "complex"
}
export interface IDataEventsHandlersMap {
    [key: string]: (...args: any[]) => any;
    [DataEvents.change]: (id?: string, status?: Statuses, obj?: any) => any;
    [DataEvents.afterAdd]: (obj: any) => void;
    [DataEvents.afterRemove]: (obj: any) => void;
    [DataEvents.beforeAdd]: (obj: any) => boolean | void;
    [DataEvents.beforeRemove]: (obj: any) => boolean | void;
    [DataEvents.load]: () => void;
    [DataEvents.removeAll]: () => void;
    [DataEvents.loadError]: (response: any) => boolean | void;
    [DataEvents.beforeLazyLoad]: () => boolean;
    [DataEvents.afterLazyLoad]: (from: number, count: number) => void;
}
export interface IDragEventsHandlersMap {
    [key: string]: (...args: any[]) => any;
    [DragEvents.beforeDrag]: (item: any, ghost: HTMLElement, id: string) => void | boolean;
    [DragEvents.beforeDrop]: (id: string, target: IObjWithData, sourceId: string) => any;
    [DragEvents.canDrop]: (id: string, dropPosition: DropPosition) => any;
    [DragEvents.cancelDrop]: (id: string, ids?: string[]) => any;
    [DragEvents.dragEnd]: (id: string, ids?: string[]) => any;
    [DragEvents.dragIn]: (id: string, dropPosition: DropPosition, target: IObjWithData) => void | boolean;
    [DragEvents.dragOut]: (id: string, target: IObjWithData) => any;
    [DragEvents.dragStart]: (id: string, ids?: string[]) => any;
    [DragEvents.dropComplete]: (id: string, position: DropPosition) => any;
}
export declare enum DataDriver {
    json = "json",
    csv = "csv",
    xml = "xml"
}
export declare type AjaxResponseType = "json" | "xml" | "text" | "raw";
export interface IAjaxHelperConfig {
    headers: {
        [key: string]: string;
    };
    responseType: AjaxResponseType;
}
export interface IAjaxHelper {
    get<T>(url: string, data?: {
        [key: string]: any;
    } | string, config?: Partial<IAjaxHelperConfig>): Promise<T>;
    post<T>(url: string, data?: {
        [key: string]: any;
    } | string, config?: Partial<IAjaxHelperConfig>): Promise<T>;
    put<T>(url: string, data?: {
        [key: string]: any;
    } | string, config?: Partial<IAjaxHelperConfig>): Promise<T>;
    delete<T>(url: string, data?: {
        [key: string]: any;
    } | string, config?: Partial<IAjaxHelperConfig>): Promise<T>;
}
