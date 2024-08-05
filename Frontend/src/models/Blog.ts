import { Category } from './Category';
import { Location } from "./Location";

export type Blog = {
  id?: string
  title: string
  shortDescription?: string
  content: string
  category: Category
  location: Location
  isPublic: boolean
  image?: string
  publicDate: string
}
