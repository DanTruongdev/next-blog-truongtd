import React from 'react'

const Header: React.FC = () => {
  return (
    <nav className="navbar navbar-expand navbar-dark bg-white topbar mb-4 static-top shadow">
      <figure className="mt-3">
        <img
          width="60px"
          src="https://devfast.us/images/devfast-logo.png"
          alt="Alternate Text"
        />
      </figure>
      <div className="mx-auto mt-1">
        <h3 className="text-center text-dark">Blog Management</h3>
      </div>
    </nav>
  )
}

export default Header
