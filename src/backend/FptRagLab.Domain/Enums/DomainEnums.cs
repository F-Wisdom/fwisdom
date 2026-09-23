namespace FptRagLab.Domain.Enums
{
    public enum UserRole
    {
        Student = 0,
        Administrator = 1
    }

    public enum DocumentStatus
    {
        Processing = 0,
        Completed = 1,
        Failed = 2
    }

    public enum QuizDifficulty
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    public enum CourseStatus
    {
        Active = 0,
        Inactive = 1
    }
}
