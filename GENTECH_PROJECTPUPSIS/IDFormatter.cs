using System;
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public static class IDFormatter
    {
        // Student: 136, 2024 → "2024-00136-SM-0"
        public static string FormatStudentID(int studentId, int year, string campusCode = "SM")
        {
            return $"{year}-{studentId:D5}-{campusCode}-0";
        }

        // Faculty: 5, 2024 → "F-2024-005"
        public static string FormatFacultyID(int facultyId, int year)
        {
            return $"F-{year}-{facultyId:D3}";
        }

        // Admin: 3, 2024 → "A-2024-003"
        public static string FormatAdminID(int adminId, int year)
        {
            return $"A-{year}-{adminId:D3}";
        }

        // Enrollment: 100, 2024 → "ENR-2024-00100"
        public static string FormatEnrollmentID(int credentialId, int year)
        {
            return $"ENR-{year}-{credentialId:D5}";
        }
    }
}