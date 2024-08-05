import React from 'react'
//import BlogList from '../components/BlogList'
import dynamic from 'next/dynamic'
const BlogList = dynamic(() => import('../components/BlogList'), { ssr: false })
export default function Index() {
  return <BlogList />
  //return <h1> I'm ok. i'm fine. Quyn cha na. đeng đéng đeng đèng đeng</h1>
}
