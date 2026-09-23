import React, { forwardRef } from 'react'
import clsx from 'clsx'

interface InputProps extends React.InputHTMLAttributes<HTMLInputElement> {
  label?: string
  error?: string
  fullWidth?: boolean
}

const Input = forwardRef<HTMLInputElement, InputProps>(
  ({ label, error, fullWidth = true, className, ...props }, ref) => {
    
    const containerClass = clsx('input-container', fullWidth ? 'input-container-full' : 'input-container-auto')
    const inputClass = clsx('input-field', error ? 'error' : 'default', className)

    return (
      <div className={containerClass}>
        {label && <label className="input-label">{label}</label>}
        <input 
          ref={ref} 
          className={inputClass}
          {...props} 
        />
        {error && <span className="input-error-msg">{error}</span>}
      </div>
    )
  }
)

Input.displayName = 'Input'

export default Input
