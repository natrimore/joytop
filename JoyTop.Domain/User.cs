namespace JoyTop.Domain
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or sets telegram id of the user
        /// </summary>
        public long TelegramId { get; set; }
        
        /// <summary>
        /// Gets or sets role of user
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets current state
        /// </summary>
        public string CurrentState { get; set; }

        /// <summary>
        /// Gets or sets default languge
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// User role type
    /// </summary>
    public enum Role : short
    {
        Customer
    }
    /// <summary>
    /// State type
    /// </summary>
    public enum State : short
    {
        Langauge, Contact, Menue, Setting, Location
    }
}
