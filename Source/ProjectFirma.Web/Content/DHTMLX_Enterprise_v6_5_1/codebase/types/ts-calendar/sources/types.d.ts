export interface ICalendarConfig {
    value?: Date | Date[] | string | string[];
    date?: Date | string;
    css?: string;
    mark?: (a: Date) => string;
    disabledDates?: (a: Date) => boolean;
    weekStart?: "monday" | "sunday";
    weekNumbers?: boolean;
    mode?: ViewMode;
    timePicker?: boolean;
    dateFormat?: string;
    timeFormat?: 24 | 12;
    thisMonthOnly?: boolean;
    width?: string;
    range?: boolean;
    $rangeMark?: (a: Date) => string;
    block?: (a: Date) => boolean;
    view?: ViewMode;
}
export interface ICalendar {
    paint(): void;
    destructor(): void;
    clear(): void;
    showDate(date?: Date, mode?: ViewMode): void;
    setValue(value: Date | Date[] | string | string[]): boolean;
    getValue(asDatObj?: boolean): Date | Date[] | string | string[];
    getCurrentMode(): ViewMode;
    link(calendar: ICalendar): void;
}
export declare enum ViewMode {
    calendar = "calendar",
    years = "year",
    months = "month",
    timepicker = "timepicker"
}
export interface ICalendarDay {
    css: string;
    date: Date;
    day: number;
}
export interface ICalendarWeek {
    weekNumber: number;
    days: ICalendarDay[];
    disabledWeekNumber?: boolean;
}
export declare enum CalendarEvents {
    change = "change",
    beforeChange = "beforechange",
    modeChange = "modeChange",
    monthSelected = "monthSelected",
    yearSelected = "yearSelected",
    cancelClick = "cancelClick",
    dateMouseOver = "dateMouseOver",
    dateHover = "dateHover"
}
export interface ICalendarHandlersMap {
    [key: string]: (...args: any[]) => any;
    [CalendarEvents.change]: (date: Date, oldDate: Date, byClick: boolean) => any;
    [CalendarEvents.beforeChange]: (date: Date, oldDate: Date, byClick: boolean) => boolean | void;
    [CalendarEvents.dateMouseOver]: (date: Date, e: MouseEvent) => any;
    [CalendarEvents.modeChange]: (mode: string) => any;
    [CalendarEvents.monthSelected]: (month: number) => any;
    [CalendarEvents.yearSelected]: (year: number) => any;
    [CalendarEvents.cancelClick]: () => any;
    [CalendarEvents.dateHover]: (date: Date, e: MouseEvent) => any;
}
