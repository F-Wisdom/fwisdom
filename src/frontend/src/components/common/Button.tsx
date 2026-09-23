import React from 'react'
import clsx from 'clsx'

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary' | 'danger' | 'ghost'
  size?: 'sm' | 'md' | 'lg'
  isLoading?: boolean
  fullWidth?: boolean
}

export default function Button({
  children,
  variant = 'primary',
  size = 'md',
  isLoading = false,
  fullWidth = false,
  className,
  disabled,
  ...props
}: ButtonProps) {
  
  const buttonClass = clsx(
    'btn-base',
    `btn-${variant}`,
    `btn-${size}`,
    fullWidth && 'btn-full',
    (disabled || isLoading) && 'btn-disabled',
    className
  )

  return (
    <button className={buttonClass} disabled={disabled || isLoading} {...props}>
      {isLoading ? (
        <span className="btn-content-loading">
          <span className="spinner"></span>
          Processing...
        </span>
      ) : (
        children
      )}
    </button>
  )
}
