export class Pagination {

    currentPage: number;
    pageSize: number;
    totalItems: number;
    totalPages: number;
    filtro: string;
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
