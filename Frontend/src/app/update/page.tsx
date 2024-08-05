'use client'
import React, { useEffect, useState } from 'react'
import BlogCreateEdit from '@/components/BlogCreateEdit'
import { Blog } from '@/models/Blog'
import useBlogStore from '@/hooks/store'
import apiClient from './../../api/http-common'
import { useRouter } from 'next/navigation'

const UpdatePage: React.FC = () => {
  const [blog, setBlog] = useState<Blog>()
  const [isLoading, setIsLoading] = useState<boolean>(true)
  const [currentId, setCurrentId] = useState<string>(
    useBlogStore((state) => state.blogId!)
  )
  const router = useRouter()

  useEffect(() => {
    if (!currentId) {
      console.log(currentId)
      router.push('/')
    } else {
      apiClient
        .get(`/blog/${currentId}`)
        .then((response) => {
          setBlog(response.data)
          setIsLoading(false)
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }, [])

  if (isLoading) return <div>Loading...</div>
  return <BlogCreateEdit data={blog} />
}

export default UpdatePage
