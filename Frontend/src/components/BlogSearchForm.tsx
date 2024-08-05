import React from 'react'
type Props = {
  setSearchStringState: (searchString: string) => void
}
const BlogSearchForm: React.FC<Props> = ({ setSearchStringState }) => {
  return (
    <div className="container mt-5">
      <div className="row justify-content-center mb-3">
        <div className="col-md-8">
          <form
            className="d-flex"
            asp-controller="Blog"
            asp-action="SearchBlog"
            method="post"
          >
            <input
              name="searchString"
              className="form-control form-control-lg me-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
              onChange={(e) => setSearchStringState(e.target.value)}
            />
            <button className="btn btn-primary btn-lg" type="submit">
              Search
            </button>
          </form>
        </div>
      </div>
    </div>
  )
}
export default BlogSearchForm
