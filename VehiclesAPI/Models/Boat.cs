namespace VehiclesAPI.Models
{
    /// <summary>
    /// Class <c>Boat</c> Models a vehicle.
    /// </summary>
    public class Boat
    {
        /// <value>
        /// Property <c>Id</c> represents the vehicle's unique Id.
        /// </value>
        public string Id { get; set; }

        /// <value>
        /// Property <c>Type</c> represents the specific characteristics and attributes that make them suitable for different purposes, such as recreational sailing, cargo transportation, or commercial fishing.
        /// </value>
        public string Type { get; set; }

        /// <value>
        /// Property <c>Name</c> represents  the unique identifier or title given to a boat, such as Titanic.
        /// </value>
        public string Name { get; set; }

        /// <value>
        /// Property <c>Size</c> represents the physical dimensions, such as length, width, and height.
        /// </value>
        public string Size { get; set; }

        /// <value>
        /// Property <c>Length</c> represents the total length of a boat's hull.
        /// </value>
        public string Length { get; set; }

        /// <value>
        /// Property <c>Capacity</c> represents the amount of cargo or passengers it can safely carry.
        /// </value>
        public string Capacity { get; set; }


    }

    /// <summary>
    /// Class <c>Vehicle</c> Models a vehicle without Id.
    /// </summary>

    public class BoatRequest
    {

        /// <value>
        /// Property <c>Type</c> represents the specific characteristics and attributes that make them suitable for different purposes, such as recreational sailing, cargo transportation, or commercial fishing.
        /// </value>
        public string Type { get; set; }

        /// <value>
        /// Property <c>Name</c> represents  the unique identifier or title given to a boat, such as Titanic.
        /// </value>
        public string Name { get; set; }

        /// <value>
        /// Property <c>Size</c> represents the physical dimensions, such as length, width, and height.
        /// </value>
        public string Size { get; set; }

        /// <value>
        /// Property <c>Length</c> represents the total length of a boat's hull.
        /// </value>
        public string Length { get; set; }

        /// <value>
        /// Property <c>Capacity</c> represents the amount of cargo or passengers it can safely carry.
        /// </value>
        public string Capacity { get; set; }

    }
}
