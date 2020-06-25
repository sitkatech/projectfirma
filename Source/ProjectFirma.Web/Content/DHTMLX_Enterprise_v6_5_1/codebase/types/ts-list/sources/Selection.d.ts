import { IEventSystem } from "../../ts-common/events";
import { SelectionEvents, ISelectionEventsHandlersMap } from "../../ts-common/types";
import { DataCollection, DataEvents, IDataEventsHandlersMap } from "../../ts-data";
import { ISelectionConfig, ISelection } from "./types";
export declare class Selection implements ISelection {
    config: ISelectionConfig;
    events: IEventSystem<SelectionEvents | DataEvents, ISelectionEventsHandlersMap & IDataEventsHandlersMap>;
    private _selected;
    private _data;
    private _lastSelectedIndex;
    private _lastShiftSelectedIndexes;
    constructor(config: ISelectionConfig, data: DataCollection);
    getId(): string | string[] | undefined;
    getItem(): any;
    contains(id?: string): boolean;
    remove(id?: string): boolean;
    add(id?: string, isCtrl?: boolean, isShift?: boolean): void;
    private _addMulti;
    private _addWithShift;
    private _addSingle;
    private _isSelected;
    private _selectItem;
    private _unselectItem;
}
export declare class SelectionStub implements ISelection {
    config: ISelectionConfig;
    events: IEventSystem<SelectionEvents | DataEvents, ISelectionEventsHandlersMap & IDataEventsHandlersMap>;
    getId(): any;
    getItem(): any;
    contains(id?: string): boolean;
    remove(id?: string): boolean;
    add(id?: string, isShift?: boolean, isCtrl?: boolean): void;
}
