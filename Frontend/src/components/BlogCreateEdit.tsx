import React, { useEffect, useState } from 'react'
import { Category } from '../models/Category'
import { Location } from '../models/Location'
import formatDate from '../utils/formatDate'
import { Blog } from '../models/Blog'
import { ToastContainer } from 'react-toastify'
import { Textbox } from 'react-inputs-validation'
import displayToast from '../utils/displayToast'
import 'react-toastify/dist/ReactToastify.css'
import { useRouter } from 'next/navigation'
import apiClient from './../api/http-common'
type BlogForm = Omit<Blog, 'category' | 'location' | 'image'> & {
  uploadImage?: File
  categoryId: string
  locationId: string
}

type Props = {
  data?: Blog
}

const BlogCreateEdit: React.FC<Props> = ({ data }) => {
  const router = useRouter()
  const [blogId, setBlogId] = useState<string>(data?.id ?? '')
  const [blogTitle, setBlogTitle] = useState<string>(data?.title ?? '')
  const [categoryList, setCategoryList] = useState<Category[]>([])
  const [locationList, setLocationList] = useState<Location[]>([])
  const [blogShortDescription, setBlogShortDescription] = useState<string>(
    data?.shortDescription ?? ''
  )
  const [blogContent, setBlogContent] = useState<string>(data?.content ?? '')
  const [locationId, setLocationId] = useState<string>(data?.location.id ?? '')
  const [categoryId, setCategoryId] = useState<string>(data?.category.id ?? '')
  const [blogImage, setBlogImage] = useState<File>()
  const [isPublic, setIsPublic] = useState<boolean>(data?.isPublic ?? true)
  const [publicDate, setPublicDate] = useState<string>(
    data?.publicDate
      ? formatDate(data?.publicDate)
      : formatDate(new Date().toDateString())
  )

  useEffect(() => {
    apiClient
      .get<Category[]>('/category')
      .then((res) => {
        const categories: Category[] = res.data
        if (!categoryId) {
          console.log('categoryId reset')
          setCategoryId(categories?.[0].id ?? '')
        }
        setCategoryList(categories)
      })
      .catch((err) => {
        console.error(err)
      })
    apiClient
      .get('/location')
      .then((res) => {
        const locations: Location[] = res.data
        if (!locationId) {
          console.log('locationId reset')
          setLocationId(locations?.[0].id ?? '')
        }
        setLocationList(locations)
      })
      .catch((err) => console.log(err))
  }, [])

  const getFormData = (): FormData => {
    var formData = new FormData()
    formData.append('title', blogTitle)
    formData.append('shortDescription', blogShortDescription ?? '')
    formData.append('content', blogContent)
    formData.append('locationId', locationId)
    formData.append('categoryId', categoryId)
    formData.append('isPublic', isPublic.toString())
    formData.append('publicDate', new Date(publicDate).toISOString())
    if (blogImage) {
      formData.append('image', blogImage)
    }
    return formData
  }

  const createNewBlog = (): void => {
    const formData: FormData = getFormData()
    apiClient
      .post('/blog/add', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      .then((response) => {
        console.log(response.data)
        displayToast('success', 'Create new blog successfully')
      })
      .catch((err) => {
        console.log(err)
        displayToast('error', 'Failed to create blog!')
      })
  }

  const updateBlog = (): void => {
    const formData: FormData = getFormData()
    formData.append('id', blogId)
    formData.forEach((data) => console.log(data))
    apiClient
      .put('/blog/update', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      .then((response) => {
        console.log(response.data)
        displayToast('success', 'Update the blog successfully')
        setTimeout(() => router.push('/'), 1000)
      })
      .catch((err) => {
        console.log(err)
        displayToast('error', 'Failed to update blog!')
      })
  }

  const clearForm = () => {
    setBlogTitle('')
    setBlogShortDescription('')
    setBlogContent('')
    setLocationId(locationList?.[0]?.id ?? '')
    setCategoryId(categoryList?.[0]?.id ?? '')
    setIsPublic(true)
    setPublicDate(formatDate(new Date().toDateString()))
  }
  return (
    <div className="card shadow m-4">
      <div className="card-header py-3">
        <h3 className="m-0 font-weight-bold text-primary">
          {data ? 'Update' : 'Add new'} blog
        </h3>
      </div>
      <div className="card-body">
        <form id="blog-form" method="post" encType="multipart/form-data">
          <input type="text" value={blogId} style={{ display: 'none' }} />
          <div className="form-group">
            <label htmlFor="exampleFormControlInput1">Title:</label>
            <Textbox
              attributesInput={{
                id: 'exampleFormControlInput1',
                placeholder: 'Enter title here',
                type: 'text',
              }}
              classNameInput="form-control"
              value={blogTitle}
              onChange={(title, e) => {
                setBlogTitle(title)
              }}
              onBlur={(e) => {}}
              validationOption={{
                name: 'Blog title',
                check: true,
                required: true,
                customFunc: (title: string) => {
                  if (title.length < 50 && title.length > 2) {
                    return true
                  } else {
                    return 'The blog title must be between 2 and 50 characters'
                  }
                },
              }}
            />
            {/* <input
              type="text"
              className="form-control"
              id="exampleFormControlInput1"
              placeholder="Enter title here..."
              value={blogTitle}
              onChange={(e) => setBlogTitle(e.target.value)}
            /> */}
          </div>
          <div className="form-group">
            <label htmlFor="exampleFormControlInput1">Short Description:</label>
            <Textbox
              attributesInput={{
                id: 'exampleFormControlInput1',
                placeholder: 'Enter short description here',
                type: 'text',
              }}
              classNameInput="form-control"
              value={blogShortDescription}
              onChange={(shortDescription, e) => {
                setBlogShortDescription(shortDescription)
              }}
              onBlur={(e) => {}}
              validationOption={{
                name: 'Short description',
                check: true,
                required: true,
                customFunc: (shortDescription: string) => {
                  if (
                    shortDescription.length < 100 &&
                    shortDescription.length > 2
                  ) {
                    return true
                  } else {
                    return 'The blog short description must be between 2 and 100 characters'
                  }
                },
              }}
            />
            {/* <input
              type="text"
              className="form-control"
              id="exampleFormControlInput1"
              placeholder="Enter short description here..."
              value={blogShortDescription}
              onChange={(e) => setBlogShortDescription(e.target.value)}
            /> */}
          </div>
          <div className="form-group">
            <label htmlFor="exampleFormControlTextarea1">Content:</label>
            <textarea
              className="form-control"
              id="exampleFormControlTextarea1"
              rows={3}
              defaultValue={''}
              value={blogContent}
              onChange={(e) => setBlogContent(e.target.value)}
            />
            <span className="text-danger" asp-validation-for="Content" />
          </div>
          <div className="form-group">
            <label htmlFor="exampleFormControlInput1">Image:</label>
            <div className="row-cols-4">
              <input
                type="file"
                className="form-control"
                id="exampleFormControlInput1"
                onChange={(e) => setBlogImage(e.target?.files?.[0])}
              />
            </div>
          </div>
          <div className="form-group d-flex justify-content-start">
            <label>Location:</label> <br />
            {locationList?.map((location, index) => (
              <div
                className="form-check"
                style={{ marginLeft: '15px' }}
                key={location.id}
              >
                <input
                  className="form-check-input"
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  value={location.id}
                  checked={locationId === location.id}
                  onChange={(e) => setLocationId(e.target.value)}
                />
                <label className="form-check-label">{location.name}</label>
              </div>
            ))}
          </div>
          <div className="form-group">
            <label htmlFor="exampleFormControlSelect1">Public:</label> <br />
            <div>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  checked={isPublic}
                  onChange={(e) => setIsPublic(true)}
                />
                <label className="form-check-label" htmlFor="flexRadioDefault1">
                  Yes
                </label>
              </div>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  onChange={(e) => setIsPublic(false)}
                  checked={!isPublic}
                />
                <label className="form-check-label" htmlFor="flexRadioDefault2">
                  No
                </label>
              </div>
            </div>
          </div>
          <div className="form-group row">
            <div className="col">
              <div className="col-4">
                <label htmlFor="exampleFormControlInput1">Category:</label>{' '}
                <br />
                <select
                  className="form-control"
                  aria-label=".form-select-lg example"
                  value={categoryId}
                  onChange={(e) => setCategoryId(e.target.value)}
                >
                  {categoryList?.map((category) => (
                    <option key={category.id} value={category.id}>
                      {category.name}
                    </option>
                  ))}
                </select>
              </div>
            </div>
            <div className="col">
              <div className="col-5">
                <label htmlFor="exampleFormControlInput1">Public Date:</label>
                <input
                  type="date"
                  className="form-control"
                  id="exampleFormControlInput1"
                  value={publicDate}
                  onChange={(e) => setPublicDate(e.target.value)}
                />
                <span
                  className="text-danger"
                  asp-validation-for="PublictDate"
                />
              </div>
            </div>
          </div>
          <hr className="sidebar-divider" />
          <div className="container d-flex justify-content-center">
            <div className="d-flex gap-2">
              <input
                type="button"
                value={data ? 'Update' : 'Create'}
                className="btn btn-success mr-3"
                onClick={() => {
                  if (!data) {
                    createNewBlog()
                  } else {
                    updateBlog()
                  }
                }}
              />

              <input
                type="button"
                defaultValue="Clear"
                className="btn btn-primary"
                onClick={() => clearForm()}
              />
            </div>
          </div>
        </form>
      </div>
      <ToastContainer />
    </div>
  )
}
export default BlogCreateEdit
