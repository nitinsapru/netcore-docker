namespace docker.worker.manager.SharedModel.UserService
{
    /// <summary>
    ///     Represents the user address details.
    /// </summary>
    public class Address
    {
        /// <summary>
        ///     Gets or sets the street address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the suite address.
        /// </summary>
        public string Suite { get; set; }

        /// <summary>
        ///     Gets or sets the city address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        ///     Gets or sets the geographical location of the user.
        /// </summary>
        public Geo Geography { get; set; }
    }
}
