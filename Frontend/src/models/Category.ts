import { Blog } from "./Blog"
export type Category = {
    id: string
    name: string
    blogs?: Blog[]
  }