namespace JoyTop.Domain.Entities
{
    /// <summary>
    /// Location entity
    /// </summary>
    public class Location
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets userId of user type
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Gets or sets latitude of location
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude of location
        /// </summary>
        public double Longitude { get; set; }
    }
}
