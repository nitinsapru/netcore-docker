namespace docker.worker.manager.SharedModel.UserService
{
    /// <summary>
    ///     Represents the user object.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Gets or sets the user Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the user email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the user address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        ///     Gets or sets the user phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the user website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        ///     Gets or sets the user company.
        /// </summary>
        public Company Company { get; set; }
    }


}
