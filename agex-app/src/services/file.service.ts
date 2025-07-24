import type { CreateFile } from "../types/files/create-file.interface";
import { httpCommon } from "./server/api";

class FileService {
  private readonly path = "files";

  getFileById(fileId: string) {
    return httpCommon.get(`${this.path}/${fileId}`);
  }

  getFilesPerPage(pageIndex: number, pageSize: number, searchTerm: string) {
    return httpCommon.get(
      `${this.path}/page?page_index=${pageIndex}&page_size=${pageSize}&search_term=${searchTerm}`
    );
  }
  getFilesByDocumentIdPerPage(
    pageIndex: number,
    pageSize: number,
    searchTerm: string,
    documentId: string
  ) {
    return httpCommon.get(
      `${this.path}/document/${documentId}/page?page_index=${pageIndex}&page_size=${pageSize}&search_term=${searchTerm}`
    );
  }

  createFile(file: CreateFile) {
    return httpCommon.post(`${this.path}`, file);
  }
  deleteFile(fileId: string) {
    return httpCommon.delete(`${this.path}/${fileId}`);
  }
}

export default new FileService();
