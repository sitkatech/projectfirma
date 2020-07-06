import { ICol, IGridConfig, IRendererConfig } from "./../types";
export declare function normalizeColumns(columns: ICol[]): void;
export declare function countColumns(config: IGridConfig, columns: ICol[]): number;
export declare function calculatePositions(width: number, height: number, scroll: any, conf: IRendererConfig): {
    xStart: number;
    xEnd: number;
    yStart: number;
    yEnd: number;
};
export declare function getUnique(arr: any[], name: string): any[];
