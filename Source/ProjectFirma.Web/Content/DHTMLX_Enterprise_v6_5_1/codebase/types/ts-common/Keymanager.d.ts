interface IKeyManager {
    addHotKey(key: string, handler: any, scope?: any): void;
    removeHotKey(key?: string, scope?: any): void;
    exist(key: string): boolean;
}
declare class KeyManager implements IKeyManager {
    private _keysStorage;
    constructor();
    addHotKey(key: string, handler: any, scope?: any): void;
    removeHotKey(key?: string, scope?: any): void;
    exist(key: string): boolean;
}
export declare const keyManager: KeyManager;
export declare function addHotkeys(handlers: any, beforeCall?: () => boolean): () => void;
export {};
