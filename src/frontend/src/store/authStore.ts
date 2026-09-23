import { create } from 'zustand'

export interface User {
  id: string
  email: string
  fullName: string
  role: 'Student' | 'Administrator'
  tokenQuota: number
  tokenUsed: number
}

interface AuthState {
  isAuthenticated: boolean
  user: User | null
  token: string | null
  login: (user: User, token: string) => void
  logout: () => void
  updateUser: (user: Partial<User>) => void
}

// In a real app, you might initialize state from localStorage/sessionStorage
export const useAuthStore = create<AuthState>((set) => ({
  isAuthenticated: false,
  user: null,
  token: null,
  login: (user, token) => set({ isAuthenticated: true, user, token }),
  logout: () => set({ isAuthenticated: false, user: null, token: null }),
  updateUser: (updatedUser) => 
    set((state) => ({
      user: state.user ? { ...state.user, ...updatedUser } : null
    }))
}))
