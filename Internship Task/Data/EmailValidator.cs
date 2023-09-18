namespace Internship_Task.Data
{
    public class EmailValidator
    {
        /// <summary>
        /// Checks if the Email is entered correctly
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>True if the Email is entered correctly. Otherwise, false</returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
