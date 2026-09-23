import { Routes, Route, Navigate } from 'react-router-dom'
import { useAuthStore } from '@/store/authStore'
import MainLayout from '@/components/layout/MainLayout'
import AuthLayout from '@/components/layout/AuthLayout'

// Pages – Auth
import LoginPage from '@/pages/auth/LoginPage'
import RegisterPage from '@/pages/auth/RegisterPage'

// Pages – Student
import DashboardPage from '@/pages/DashboardPage'
import CourseCatalogPage from '@/pages/course/CourseCatalogPage'
import CourseDetailPage from '@/pages/course/CourseDetailPage'
import DocumentListPage from '@/pages/document/DocumentListPage'
import QuizGeneratePage from '@/pages/quiz/QuizGeneratePage'
import QuizTakePage from '@/pages/quiz/QuizTakePage'
import QuizResultPage from '@/pages/quiz/QuizResultPage'
import QuizHistoryPage from '@/pages/quiz/QuizHistoryPage'
import ProfilePage from '@/pages/ProfilePage'

// Pages – Admin
import AdminDashboardPage from '@/pages/admin/AdminDashboardPage'
import AdminUsersPage from '@/pages/admin/AdminUsersPage'
import AdminCoursesPage from '@/pages/admin/AdminCoursesPage'
import AdminStatisticsPage from '@/pages/admin/AdminStatisticsPage'

/** Route guard: redirect to login if not authenticated */
function PrivateRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated } = useAuthStore()
  return isAuthenticated ? <>{children}</> : <Navigate to="/login" replace />
}

/** Route guard: only allow admin role */
function AdminRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated, user } = useAuthStore()
  if (!isAuthenticated) return <Navigate to="/login" replace />
  if (user?.role !== 'Administrator') return <Navigate to="/" replace />
  return <>{children}</>
}

export default function App() {
  return (
    <Routes>
      {/* ── Auth Routes ─────────────────────────────────── */}
      <Route element={<AuthLayout />}>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
      </Route>

      {/* ── Student Routes ──────────────────────────────── */}
      <Route
        element={
          <PrivateRoute>
            <MainLayout />
          </PrivateRoute>
        }
      >
        <Route path="/" element={<DashboardPage />} />
        <Route path="/courses" element={<CourseCatalogPage />} />
        <Route path="/courses/:courseId" element={<CourseDetailPage />} />
        <Route path="/documents" element={<DocumentListPage />} />
        <Route path="/quiz/generate" element={<QuizGeneratePage />} />
        <Route path="/quiz/:quizId/take" element={<QuizTakePage />} />
        <Route path="/quiz/attempts/:attemptId" element={<QuizResultPage />} />
        <Route path="/quiz/history" element={<QuizHistoryPage />} />
        <Route path="/profile" element={<ProfilePage />} />
      </Route>

      {/* ── Admin Routes ────────────────────────────────── */}
      <Route
        path="/admin"
        element={
          <AdminRoute>
            <MainLayout isAdmin />
          </AdminRoute>
        }
      >
        <Route index element={<AdminDashboardPage />} />
        <Route path="users" element={<AdminUsersPage />} />
        <Route path="courses" element={<AdminCoursesPage />} />
        <Route path="statistics" element={<AdminStatisticsPage />} />
      </Route>

      {/* Fallback */}
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}
