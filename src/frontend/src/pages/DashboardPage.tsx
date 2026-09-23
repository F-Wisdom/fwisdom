import React from 'react'
import { Link } from 'react-router-dom'

export default function DashboardPage() {
  return (
    <div>
      <div className="dashboard-grid">
        
        {/* Quick Actions */}
        <div className="dashboard-card">
          <h2 className="dashboard-card-title">Quick Actions</h2>
          <div className="action-btn-group">
            <Link to="/documents" className="action-btn">
              📄 Upload Study Materials
            </Link>
            <Link to="/quiz/generate" className="action-btn primary">
              🤖 Generate New Quiz
            </Link>
          </div>
        </div>

        {/* Stats Summary */}
        <div className="dashboard-card">
          <h2 className="dashboard-card-title">Your Activity</h2>
          <div className="stats-grid">
            <div className="stat-box">
              <div className="stat-value">12</div>
              <div className="stat-label">Quizzes Taken</div>
            </div>
            <div className="stat-box">
              <div className="stat-value">85%</div>
              <div className="stat-label">Avg. Score</div>
            </div>
            <div className="stat-box">
              <div className="stat-value">5</div>
              <div className="stat-label">Documents</div>
            </div>
            <div className="stat-box">
              <div className="stat-value">1.2k</div>
              <div className="stat-label">Tokens Used</div>
            </div>
          </div>
        </div>

      </div>

      {/* Recent Quizzes */}
      <div className="dashboard-card mt-24">
        <h2 className="dashboard-card-title">Recent Quizzes</h2>
        <p className="text-secondary">You haven't taken any quizzes recently.</p>
      </div>
    </div>
  )
}
