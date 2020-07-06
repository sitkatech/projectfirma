import { EventSystem } from "../../ts-common/events";
import { Layout, LayoutEvents, ILayoutEventHandlersMap } from "../../ts-layout";
import { ITabbarConfig, TabbarEvents, ITabbarEventHandlersMap, ITabbar } from "./types";
export declare class Tabbar extends Layout implements ITabbar {
    config: ITabbarConfig;
    events: EventSystem<TabbarEvents | LayoutEvents, ITabbarEventHandlersMap | ILayoutEventHandlersMap>;
    private _hotkeysDestructor;
    constructor(container: any, config: ITabbarConfig);
    toVDOM(): any;
    destructor(): void;
    getWidget(): any;
    setActive(id: string): void;
    getActive(): string;
    addTab(config: ITabbarConfig, index: number): void;
    removeTab(id: string): void;
    disableTab(id: string): boolean;
    enableTab(id: string): void;
    isDisabled(id?: string): boolean;
    removeCell(id: string): void;
    protected _initHandlers(): void;
    private _focusTab;
    private _getEnableTabs;
    private _getIndicatorPosition;
    private _drawTabs;
}
