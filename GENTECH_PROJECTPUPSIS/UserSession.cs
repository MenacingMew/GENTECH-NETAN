// UserSession.cs
using System;

namespace GENTECH_PROJECTPUPSIS
{
    public static class UserSession
    {
        // ==================== COMMON FIELDS ====================
        public static int? UserID { get; private set; }
        public static string UserRole { get; private set; }
        public static string Password { get; private set; }
        public static string FirstName { get; private set; }
        public static string LastName { get; private set; }
        public static string Email { get; private set; }
        public static bool IsLoggedIn { get; private set; }

        // ==================== STUDENT-SPECIFIC FIELDS ====================
        public static int? StudentID { get; private set; }
        public static int? ProgramID { get; private set; }
        public static string ProgramCode { get; private set; }    // NEW - Program_Code
        public static string ProgramName { get; private set; }
        public static DateTime? BirthDate { get; private set; }
        public static string ContactNumber { get; private set; }
        public static int? YearLevel { get; private set; }
        public static int? Section { get; private set; }

        // ==================== FACULTY-SPECIFIC FIELDS ====================
        public static int? FacultyID { get; private set; }
        public static int? DepartmentID { get; private set; }
        public static string DepartmentName { get; private set; }

        // ==================== ENROLLMENT STAFF-SPECIFIC FIELDS ====================
        public static int? CredentialID { get; private set; }
        public static int? EnrollmentStudentID { get; private set; }

        // ==================== ADMIN-SPECIFIC FIELDS ====================
        public static int? AdminID { get; private set; }
        public static string RoleDescription { get; private set; }

        // ==================== ROLE CONSTANTS ====================
        public const string ROLE_STUDENT = "STUDENT";
        public const string ROLE_FACULTY = "FACULTY";
        public const string ROLE_ENROLLMENT = "ENROLLMENT";
        public const string ROLE_ADMIN = "ADMIN";

        // ==================== SET STUDENT DATA ====================
        public static void SetStudentData(
            int studentId,
            string firstName,
            string lastName,
            string email,
            string contactNumber,
            DateTime birthDate,
            int? yearLevel,
            int? programId,
            string programCode = null,     // NEW parameter
            string programName = null,
            int? section = null,
            string password = null)
        {
            ClearSession();

            UserID = studentId;
            UserRole = ROLE_STUDENT;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            StudentID = studentId;
            ProgramID = programId;
            ProgramCode = programCode;     // NEW
            ProgramName = programName;
            BirthDate = birthDate;
            ContactNumber = contactNumber;
            YearLevel = yearLevel;
            Section = section;

            IsLoggedIn = true;
        }

        // ==================== SET FACULTY DATA ====================
        public static void SetFacultyData(
            int facultyId,
            string firstName,
            string lastName,
            string email,
            int? departmentId,
            string departmentName = null,
            string password = null)
        {
            ClearSession();

            UserID = facultyId;
            UserRole = ROLE_FACULTY;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            FacultyID = facultyId;
            DepartmentID = departmentId;
            DepartmentName = departmentName;

            IsLoggedIn = true;
        }

        // ==================== SET ENROLLMENT STAFF DATA ====================
        public static void SetEnrollmentStaffData(
            int credentialId,
            int studentId,
            string firstName,
            string lastName,
            string email,
            string contactNumber,
            DateTime birthDate,
            int? yearLevel,
            int? programId,
            string programCode = null,     // NEW parameter
            string programName = null,
            int? section = null,
            string password = null)
        {
            ClearSession();

            UserID = credentialId;
            UserRole = ROLE_ENROLLMENT;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            CredentialID = credentialId;
            EnrollmentStudentID = studentId;

            StudentID = studentId;
            ProgramID = programId;
            ProgramCode = programCode;     // NEW
            ProgramName = programName;
            BirthDate = birthDate;
            ContactNumber = contactNumber;
            YearLevel = yearLevel;
            Section = section;

            IsLoggedIn = true;
        }

        // ==================== SET ADMIN DATA ====================
        public static void SetAdminData(
            int adminId,
            string firstName,
            string lastName,
            string email,
            string roleDescription,
            string password = null)
        {
            ClearSession();

            UserID = adminId;
            UserRole = ROLE_ADMIN;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            AdminID = adminId;
            RoleDescription = roleDescription;

            IsLoggedIn = true;
        }

        // ==================== HELPER METHODS ====================

        public static string GetFullName()
        {
            return $"{FirstName} {LastName}".Trim();
        }

        public static int? GetRoleSpecificID()
        {
            switch (UserRole)
            {
                case ROLE_STUDENT:
                    return StudentID;
                case ROLE_FACULTY:
                    return FacultyID;
                case ROLE_ENROLLMENT:
                    return CredentialID;
                case ROLE_ADMIN:
                    return AdminID;
                default:
                    return UserID;
            }
        }

        // Get program display (Code + Name)
        public static string GetProgramDisplay()
        {
            if (!string.IsNullOrEmpty(ProgramCode) && !string.IsNullOrEmpty(ProgramName))
                return $"{ProgramCode} - {ProgramName}";
            else if (!string.IsNullOrEmpty(ProgramCode))
                return ProgramCode;
            else if (!string.IsNullOrEmpty(ProgramName))
                return ProgramName;
            else
                return "No Program";
        }

        public static string GetUserDetails()
        {
            string details = $"ID: {GetRoleSpecificID()}\n" +
                           $"Name: {GetFullName()}\n" +
                           $"Role: {UserRole}\n" +
                           $"Email: {Email}\n";

            switch (UserRole)
            {
                case ROLE_STUDENT:
                    details += $"Student ID: {StudentID}\n" +
                              $"Program: {GetProgramDisplay()}\n" +  // NEW - uses ProgramCode + ProgramName
                              $"Year Level: {YearLevel}\n" +
                              $"Section: {Section}\n" +
                              $"Contact: {ContactNumber}\n" +
                              $"Birth Date: {BirthDate:MM/dd/yyyy}";
                    break;

                case ROLE_FACULTY:
                    details += $"Faculty ID: {FacultyID}\n" +
                              $"Department: {DepartmentName}\n";
                    break;

                case ROLE_ENROLLMENT:
                    details += $"Credential ID: {CredentialID}\n" +
                              $"Student ID: {EnrollmentStudentID}\n" +
                              $"Program: {GetProgramDisplay()}\n" +  // NEW
                              $"Year Level: {YearLevel}\n" +
                              $"Section: {Section}";
                    break;

                case ROLE_ADMIN:
                    details += $"Admin ID: {AdminID}\n" +
                              $"Role: {RoleDescription}";
                    break;
            }

            return details;
        }

        public static bool HasRole(string role)
        {
            return IsLoggedIn && UserRole?.ToUpper() == role?.ToUpper();
        }

        public static bool IsStudent() => HasRole(ROLE_STUDENT);
        public static bool IsFaculty() => HasRole(ROLE_FACULTY);
        public static bool IsEnrollmentStaff() => HasRole(ROLE_ENROLLMENT);
        public static bool IsAdmin() => HasRole(ROLE_ADMIN);

        public static string GetSectionDisplay()
        {
            return Section.HasValue ? $"Section {Section.Value}" : "No Section";
        }

        public static void ClearSession()
        {
            UserID = null;
            UserRole = null;
            Password = null;
            FirstName = null;
            LastName = null;
            Email = null;
            IsLoggedIn = false;

            StudentID = null;
            ProgramID = null;
            ProgramCode = null;    // NEW
            ProgramName = null;
            BirthDate = null;
            ContactNumber = null;
            YearLevel = null;
            Section = null;

            FacultyID = null;
            DepartmentID = null;
            DepartmentName = null;

            CredentialID = null;
            EnrollmentStudentID = null;

            AdminID = null;
            RoleDescription = null;
        }
    }
}