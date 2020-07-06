import { IEventSystem } from "../../ts-common/events";
import { DataCollection, DataEvents } from "../../ts-data";
import { IFitPosition } from "../../ts-common/html";
export interface IChart {
    events: IEventSystem<DataEvents | ChartEvents>;
    data: DataCollection;
    eachSeries(handler: (seria: ISeria) => any): any[];
    setConfig(config: IChartConfig): void;
    paint(): void;
    getSeries(id: string): ISeria;
}
export interface IChartConfig {
    type?: ChartType;
    css?: string;
    barWidth?: number;
    scales?: IScalesConfig;
    legend?: ILegendConfig;
    series?: SeriaConfig[];
    maxPoints?: number;
    data?: DataCollection<any> | any[];
}
export declare enum ChartType {
    bar = "bar",
    line = "line",
    spline = "spline",
    scatter = "scatter",
    area = "area",
    donut = "donut",
    pie = "pie",
    pie3D = "pie3D",
    radar = "radar",
    xBar = "xbar",
    splineArea = "splineArea"
}
export declare enum ChartEvents {
    toggleSeries = "toggleSeries",
    chartMouseMove = "chartMouseMove",
    chartMouseLeave = "chartMouseLeave",
    resize = "resize",
    serieClick = "serieClick"
}
export interface IChartSeries {
    [id: string]: ISeria;
}
export interface ISeria extends ILikeSeria {
    id: string;
    config: ISeriaConfig;
    toggle(id?: string): void;
    addScale(type: ScaleType, scale: IScale): void;
    getPoints(): PointData[];
    getTooltipText(id: string): string;
    getTooltipType(id: string, x?: number, y?: number): TooltipType;
    getClosest(x: number, y: number): [number, number, number, string];
}
export interface ISeriaConfig {
    id?: string;
    type?: ChartType;
    active?: boolean;
    pointColor?: string;
    dashed?: boolean;
    scales?: ScaleType[];
    strokeWidth?: number;
    value?: string;
    name?: string;
    valueY?: string;
    pointType?: PointType;
    barWidth?: number;
    css?: string;
    fill?: string;
    color?: string;
    alpha?: number;
    showText?: boolean;
    showTextRotate?: number | string;
    showTextTemplate?: (points: any) => string;
    tooltip?: boolean;
    tooltipTemplate?: (points: any[]) => string;
    gradient?: Gradient;
    baseLine?: number;
    tooltipType?: TooltipType;
    stacked?: boolean;
}
export declare type SeriaConfig = ISeriaConfig | INoScaleConfig;
export interface IScale extends IComposable {
    locator?: Locator;
    add(chart: ILikeSeria): void;
    point(item: object | number): number;
    getSize(): number;
    addPadding(): void;
}
export interface IScaleConfig extends IAxisCreatorConfig {
    type?: ScaleType;
    title?: string;
    text?: SmartLocator;
    textTemplate?: <T>(value: T) => string;
    size?: number;
    scalePadding?: number;
    scaleRotate?: number;
    textPadding?: number;
    hidden?: boolean;
    grid?: boolean;
    dashed?: boolean;
    targetLine?: number | string;
    targetValue?: number;
    showText?: boolean;
    locator?: SmartLocator;
}
export declare enum ScaleType {
    left = "left",
    right = "right",
    top = "top",
    bottom = "bottom",
    radial = "radial"
}
export interface IScales {
    left?: IScale | ITextScale;
    right?: IScale | ITextScale;
    top?: IScale | ITextScale;
    bottom?: IScale | ITextScale;
    radial?: IScale;
}
export interface IScalesConfig {
    left?: IScaleConfig;
    right?: IScaleConfig;
    top?: IScaleConfig;
    bottom?: IScaleConfig;
    radial?: IRadialScaleConfig;
}
export interface ILegendConfig {
    values?: {
        id?: SmartLocator;
        text: SmartLocator;
        color: SmartLocator;
        alpha?: SmartLocator;
    };
    size?: number;
    form?: Shape;
    itemPadding?: number;
    halign?: HorizontalPosition;
    valign?: VerticalPosition;
    series?: string[];
    margin?: number;
    $seriesInfo?: ISeria[];
}
export interface ILegendDrawData {
    id: string;
    alpha: number;
    text: string;
    fill: string;
    active?: boolean;
    color?: string;
}
export interface IComposable {
    paint(width: number, height: number, prev?: PointData[]): object;
    paintformAndMarkers?(width: number, height: number, prev?: PointData[]): [object, object];
    dataReady?(prev?: PointData[]): PointData[];
    scaleReady?(sizes: IFitPosition): void;
    destructor?(): void;
}
export interface IComposeLayer {
    add(obj: any): void;
    clear(): void;
    getSizes(): IFitPosition;
    toVDOM(width: number, height: number): void;
}
export interface IRadarConfig extends ISeriaConfig {
    radius?: number;
    paddings?: number;
    scales: ScaleType[];
}
export interface IRadialScaleConfig extends IScaleConfig {
    value?: string;
    zebra?: boolean;
    showAxis?: boolean;
}
export interface IRadarScaleDrawData {
    scales: string[];
    axis: number[];
    realAxis: number[];
    zebra: boolean;
}
export interface IAxisCreatorConfig {
    max?: number;
    min?: number;
    log?: boolean;
    padding?: number;
    maxTicks?: number;
}
export interface IAxisScale {
    min: number;
    max: number;
    steps: number[];
}
export interface IAxisCreator {
    config: IAxisCreatorConfig;
    getScale(): IAxisScale;
}
export interface IAxisLike<T> {
    steps: T[];
    max: number;
    min?: number;
}
export interface INoScaleConfig extends ISeriaConfig {
    text?: SmartLocator;
    value?: string;
    useLines?: boolean;
    subType?: NoScaleSubType;
    stroke?: string;
    monochrome?: string;
    paddings?: number;
}
export declare enum PointType {
    circle = "circle",
    rect = "rect",
    triangle = "triangle",
    rhombus = "rhombus",
    simpleRect = "simpleRect",
    simpleCircle = "simpleCircle",
    empty = "empty"
}
export declare type Gradient = (color: string) => any;
export declare enum TooltipType {
    simple = "simple",
    right = "right",
    left = "left",
    top = "top",
    bot = "bot"
}
export declare type SvgElement = any;
export declare enum Shape {
    rect = "rect",
    circle = "circle"
}
export declare enum HorizontalPosition {
    left = "left",
    center = "center",
    right = "right"
}
export declare enum VerticalPosition {
    top = "top",
    middle = "middle",
    bottom = "bottom"
}
export interface ILikeSeria extends IComposable {
    getPoints(): PointData[];
    seriesShift?(size?: number): number;
}
export interface ITextScale extends IScale {
    addPadding(): void;
}
export declare type Locator = (item: any) => any;
export declare type DrawPoint = (x: number, y: number, ref?: string) => any;
export declare enum NoScaleSubType {
    basic = "basic",
    percentOnly = "percentOnly",
    valueOnly = "valueOnly"
}
export declare type SmartLocator = Locator | string;
export interface IStacker extends IComposable, ILikeSeria {
    add(seria: ISeria): void;
}
export declare type PointData = [number, number, string, number, number];
export interface IGridRenderConfig {
    targetLine?: number;
    dashed: boolean;
    grid: boolean;
    targetValue?: number;
    hidden?: boolean;
}
