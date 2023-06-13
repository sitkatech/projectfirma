interface IScrollViewConfig {
    speed: number;
}
export declare class ScrollView {
    config: IScrollViewConfig;
    private _getRootView;
    private _scrollTop;
    private _runnerTop;
    private _runnerHeight;
    private _visibleArea;
    private _scrollWidth;
    private _wheelName;
    private _handlers;
    constructor(getRootView: any, config?: {});
    render(element: any): any;
    private _update;
    private _getRefs;
}
export {};
