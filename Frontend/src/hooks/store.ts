import { create } from 'zustand'

interface StoreState {
  blogId: string | null
  setBlogId: (newData: string) => void
}
const useBlogStore = create<StoreState>((set) => ({
  blogId: '',
  setBlogId: (newData) => set({ blogId: newData }),
}))

export default useBlogStore