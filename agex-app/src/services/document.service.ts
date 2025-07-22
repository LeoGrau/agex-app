import type { CreateDocument } from "../types/documents/create-document.interface";
import type { UpdateDocument } from "../types/documents/update-document.interface";
import { httpCommon } from "./server/api";

class DocumentService {
  private readonly path = "documents";
  getDocumentsPerPage(pageIndex: number, pageSize: number, searchTerm: string) {
    return httpCommon.get(
      `${this.path}/page?page_index=${pageIndex}&page_size=${pageSize}&search_term=${searchTerm}`
    );
  }
  getDocument(documentId: string) {
    return httpCommon.get(`${this.path}/${documentId}`);
  }
  createDocument(document: CreateDocument) {
    return httpCommon.post(`${this.path}`, document);
  }
  updateDocument(documentId: string, document: UpdateDocument) {
    return httpCommon.put(`${this.path}/${documentId}`, document);
  }
}

export default new DocumentService();
