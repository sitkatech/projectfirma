import { Tree } from "./Tree";
import { Id } from "./types";
export interface IKeyNavigation {
    add(id: Id, target: Tree): void;
}
declare class KeyNavigation implements IKeyNavigation {
    private _store;
    private _keyManager;
    private _activeTarget;
    private _listen;
    private _blocked;
    add(id: Id, target: Tree): void;
    block(val: boolean): void;
    private _initKeys;
    private _getFocused;
    private _addListeners;
    private _getClosestBot;
    private _getClosestTop;
}
export declare const keyNavigation: KeyNavigation;
export {};
