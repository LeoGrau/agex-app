import type { File } from "./file";

export class Document {
  id: number;
  name: string;
  description: string;
  files: File[]

  constructor(id: number, name: string, description: string, files: File[]) {
    this.id = id;
    this.name = name;
    this.description = description
    this.files = files
  }
}
