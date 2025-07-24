import type { File } from "./file";

export class Document {
  id: string;
  name: string;
  description: string;
  files: File[]
  createdAt: string
  updatedAt: string

  constructor(id: string, name: string, description: string, createdAt: string, updatedAt: string ,files: File[]) {
    this.id = id;
    this.name = name;
    this.description = description
    this.files = files
    this.createdAt = createdAt
    this.updatedAt = updatedAt
  }
}
