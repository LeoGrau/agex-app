export class File {
  
  url: string
  name: string
  description: string
  createdAt: string
  updateAt: string

  constructor(url: string, name: string, description: string, createdAt: string, updateAt: string) {
    this.url = url
    this.name = name
    this.description = description
    this.createdAt = createdAt
    this.updateAt = updateAt
  }
  
}