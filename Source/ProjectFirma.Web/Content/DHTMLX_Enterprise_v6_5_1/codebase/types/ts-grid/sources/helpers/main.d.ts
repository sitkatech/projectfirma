import { ICellCss, ICol, IGridConfig, IRow } from "../types";
export declare function rgbToHex(color: string): string;
export declare function transpose(arr: any[][], transform?: any): any[][];
export declare function getStyleByClass(cssClass: string, container: HTMLElement, targetClass: string, def?: ICellCss): ICellCss;
export declare function removeHTMLTags(str: string): string;
export declare function isCssSupport(property: string, value: string): boolean;
export declare function isRowEmpty(row: IRow): boolean;
export declare function isSortable(config: IGridConfig, col: ICol): boolean;
export declare function isAutoWidth(config: IGridConfig, col?: ICol): boolean;
