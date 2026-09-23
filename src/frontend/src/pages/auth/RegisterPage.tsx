import React from 'react'
import { Link } from 'react-router-dom'
import Button from '@/components/common/Button'
import Input from '@/components/common/Input'

export default function RegisterPage() {
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    // TODO: Implement actual registration logic
  }

  return (
    <div>
      <div className="auth-card-header">
        <h2 className="auth-card-title">Create an Account</h2>
        <p className="auth-card-subtitle">Sign up to start generating quizzes</p>
      </div>

      <form onSubmit={handleSubmit}>
        <Input 
          label="Full Name" 
          type="text" 
          placeholder="Nguyen Van A" 
          required 
        />
        
        <Input 
          label="FPT Email Address" 
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

        <Input 
          label="Confirm Password" 
          type="password" 
          placeholder="••••••••" 
          required 
        />

        <div className="mt-16">
          <Button type="submit" fullWidth size="lg">
            Sign Up
          </Button>
        </div>
      </form>

      <div className="auth-footer-text">
        <span>Already have an account? </span>
        <Link to="/login" className="auth-footer-link">
          Sign in
        </Link>
      </div>
    </div>
  )
}
