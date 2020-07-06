import { ICell, IGrid, ISelection, IRow, ICol, ISelectionType } from "./types";
export declare class Selection implements ISelection {
    protected _grid: IGrid;
    protected _selectedCell: ICell;
    protected _oldSelectedCell: ICell;
    protected _selectedCells: ICell[];
    protected _type: ISelectionType;
    protected _multiselection: boolean;
    constructor(grid: IGrid);
    setCell(row?: any, col?: any, ctrlUp?: boolean, shiftUp?: boolean): void;
    getCell(): ICell;
    getCells(): ICell[];
    toHTML(): any;
    protected _init(): void;
    protected _toHTML(row: IRow, column: ICol, last?: boolean): any;
    protected _isUnselected(): boolean;
    protected _findIndex(cell?: ICell): number;
}
