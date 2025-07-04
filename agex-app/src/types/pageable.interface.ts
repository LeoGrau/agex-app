export interface Pageable<T> {
  totalCount: number,
  itemCount: number,
  pageSize: number,
  pageIndex: number,
  items: T[]
}

