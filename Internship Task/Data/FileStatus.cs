using Microsoft.AspNetCore.Components.Forms;

namespace Internship_Task.Data
{
    public static class FileStatus
    {
        public static bool Selected { get; set; }
        public static bool Uploaded { get; set; }
        public static bool Exists { get; set; }
        public static bool LimitExceeded { get; set; }
        /// <summary>
        /// Checks if the user's file can be uploaded
        /// </summary>
        /// <param name="file">.docx file</param>
        /// <param name="email">Email</param>
        /// <returns>True if the user .docx file can be uploaded. Otherwise, false</returns>
        public static bool CanBeUploaded(IBrowserFile? file, string? email)
        {
            if (file != null)
            {
                EmailValidator emailValidator = new EmailValidator();
                if (emailValidator.IsValidEmail(email))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
