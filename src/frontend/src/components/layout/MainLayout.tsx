import React from 'react'
import { Outlet, Link, useNavigate, useLocation } from 'react-router-dom'
import { useAuthStore } from '@/store/authStore'
import clsx from 'clsx'

interface MainLayoutProps {
  isAdmin?: boolean
}

export default function MainLayout({ isAdmin = false }: MainLayoutProps) {
  const { user, logout } = useAuthStore()
  const navigate = useNavigate()
  const location = useLocation()

  const handleLogout = () => {
    logout()
    navigate('/login')
  }

  const studentLinks = [
    { name: 'Dashboard', path: '/' },
    { name: 'Courses', path: '/courses' },
    { name: 'My Documents', path: '/documents' },
    { name: 'Quiz History', path: '/quiz/history' },
  ]

  const adminLinks = [
    { name: 'Admin Dashboard', path: '/admin' },
    { name: 'Manage Users', path: '/admin/users' },
    { name: 'Manage Courses', path: '/admin/courses' },
    { name: 'Statistics', path: '/admin/statistics' },
  ]

  const navLinks = isAdmin ? adminLinks : studentLinks

  return (
    <div className="layout-container">
      {/* Sidebar */}
      <aside className="sidebar">
        <div className="sidebar-header">
          <h2 className="sidebar-logo">FPT RAG Lab</h2>
          <span className="sidebar-badge">{isAdmin ? 'Admin' : 'Student'}</span>
        </div>
        
        <nav className="sidebar-nav">
          {navLinks.map((link) => {
            const isActive = location.pathname === link.path || 
                             (link.path !== '/' && link.path !== '/admin' && location.pathname.startsWith(link.path))
            
            return (
              <Link 
                key={link.path} 
                to={link.path} 
                className={`nav-link ${isActive ? 'active' : ''}`}
              >
                {link.name}
              </Link>
            )
          })}
        </nav>

        <div className="sidebar-footer">
          <div className="user-info">
            <div className="user-name">{user?.fullName || 'User'}</div>
            {!isAdmin && (
              <div className="user-tokens">
                Tokens: {user?.tokenUsed}/{user?.tokenQuota}
              </div>
            )}
          </div>
          <button onClick={handleLogout} className="logout-btn">
            Logout
          </button>
        </div>
      </aside>

      {/* Main Content */}
      <main className="main-content">
        <header className="main-header">
          <h1 className="page-title">
            {navLinks.find(l => l.path === location.pathname)?.name || 'Dashboard'}
          </h1>
          <div className="header-actions">
            <Link to="/profile" className="profile-link">Profile</Link>
          </div>
        </header>
        
        <div className="page-content">
          <Outlet />
        </div>
      </main>
    </div>
  )
}
