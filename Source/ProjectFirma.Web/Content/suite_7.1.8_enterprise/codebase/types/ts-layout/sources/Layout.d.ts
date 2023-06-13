import { Cell } from "./Cell";
import { ICell, ICellConfig, ILayout, ILayoutConfig, LayoutCallback } from "./types";
declare type Id = string;
export declare class Layout extends Cell implements ILayout {
    config: ILayoutConfig;
    protected _all: any;
    protected _cells: ICell[];
    private _xLayout;
    private _root;
    private _isViewLayout;
    constructor(parent: any, config: ILayoutConfig);
    destructor(): void;
    toVDOM(): any;
    removeCell(id: string): any;
    addCell(config: ICellConfig, index?: number): void;
    getId(index: number): string;
    getRefs(name: string): any;
    getCell(id: string): any;
    forEach(callback: LayoutCallback, parent?: Id, level?: number): void;
    /** @deprecated See a documentation: https://docs.dhtmlx.com/ */
    cell(id: string): any;
    protected _getCss(content?: boolean): string;
    private _parseConfig;
    private _createCell;
    private _haveCells;
    private _inheritTypes;
}
export {};
