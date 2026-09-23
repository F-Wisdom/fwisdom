import React from 'react'
import { Link } from 'react-router-dom'
import Button from '@/components/common/Button'
import Input from '@/components/common/Input'
import { useAuthStore } from '@/store/authStore'

export default function LoginPage() {
  const { login } = useAuthStore()

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    // TODO: Implement actual login logic with React Hook Form & API
    login(
      {
        id: '1',
        email: 'student@fpt.edu.vn',
        fullName: 'FPT Student',
        role: 'Student',
        tokenQuota: 50000,
        tokenUsed: 12500
      },
      'fake-jwt-token'
    )
  }

  return (
    <div>
      <div className="auth-card-header">
        <h2 className="auth-card-title">Welcome back</h2>
        <p className="auth-card-subtitle">Enter your credentials to access your account</p>
      </div>

      <form onSubmit={handleSubmit}>
        <Input 
          label="Email Address" 
          type="email" 
          placeholder="student@fpt.edu.vn" 
          required 
        />
        
        <Input 
          label="Password" 
          type="password" 
          placeholder="••••••••" 
          required 
        />
        
        <div className="form-options">
          <label className="checkbox-label">
            <input type="checkbox" />
            <span>Remember me</span>
          </label>
          <a href="#" className="auth-footer-link">Forgot password?</a>
        </div>

        <Button type="submit" fullWidth size="lg">
          Sign In
        </Button>
      </form>

      <div className="auth-footer-text">
        <span>Don't have an account? </span>
        <Link to="/register" className="auth-footer-link">
          Sign up
        </Link>
      </div>
    </div>
  )
}
