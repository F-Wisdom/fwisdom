import React from 'react'
import { Outlet, Navigate } from 'react-router-dom'
import { useAuthStore } from '@/store/authStore'

export default function AuthLayout() {
  const { isAuthenticated } = useAuthStore()

  // Redirect to dashboard if already logged in
  if (isAuthenticated) {
    return <Navigate to="/" replace />
  }

  return (
    <div className="auth-container">
      <div className="auth-left-panel">
        <div className="auth-left-content">
          <h1 className="auth-title">FPT RAG Lab</h1>
          <p className="auth-subtitle">
            Outcome-Aligned Quiz Generation Platform for FPT University
          </p>
          <div className="auth-features">
            <div className="auth-feature">
              <div className="auth-feature-icon">📚</div>
              <div>Upload course materials</div>
            </div>
            <div className="auth-feature">
              <div className="auth-feature-icon">🤖</div>
              <div>Generate quizzes with AI</div>
            </div>
            <div className="auth-feature">
              <div className="auth-feature-icon">🎯</div>
              <div>Aligned with Learning Outcomes</div>
            </div>
          </div>
        </div>
      </div>
      
      <div className="auth-right-panel">
        <div className="auth-card animate-fade-in">
          <Outlet />
        </div>
      </div>
    </div>
  )
}
