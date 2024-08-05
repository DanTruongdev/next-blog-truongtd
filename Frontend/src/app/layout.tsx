import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import './globals.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import './../assets/css/sb-admin-2.min.css'
// import './../assets/js/bootstrap.bundle.min.js'
import Header from '@/components/Header'
import Menu from '@/components/Menu'
import Footer from '@/components/Footer'

const inter = Inter({ subsets: ['latin'] })
type LayoutProps = Readonly<{
  children: React.ReactNode
}>

export const metadata: Metadata = {
  title: 'Blog',
  description: 'My blog app',
}

export default function Layout({ children }: LayoutProps) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <div id="wrapper">
          <Menu />
          <div id="content-wrapper" className="d-flex flex-column">
            <div id="content">
              <Header />
              {children}
              <Footer />
            </div>
          </div>
        </div>
      </body>
    </html>
  )
}
