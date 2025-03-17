/**
 * Represents the model for retrieving a list with pagination and sorting options.
 */
export class GetListModel {

    PageNo: number = 1;
    Record: number = 10;
    SortBy: string = '';
    SortType: string = '';
}
