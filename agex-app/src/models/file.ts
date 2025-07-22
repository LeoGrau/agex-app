export class File {
  id: string
  url: string
  name: string
  description: string
  createdAt: string
  updateAt: string

  constructor(id: string, url: string, name: string, description: string, createdAt: string, updateAt: string) {
    this.id = id
    this.url = url
    this.name = name
    this.description = description
    this.createdAt = createdAt
    this.updateAt = updateAt
  }
  
}