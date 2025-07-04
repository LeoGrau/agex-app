import { httpCommon } from "./server/api";

class DocumentService {
  private readonly path = "documents"
  getDocumentsPerPage(pageIndex: number, pageSize: number, searchTerm: string) {
    return httpCommon.get(`${this.path}/page?page_index=${pageIndex}&page_size=${pageSize}&search_term=${searchTerm}`)
  }
  getDocument(documentId: string) {
    return httpCommon.get(`${this.path}/${documentId}`)
  }
}

export default new DocumentService();