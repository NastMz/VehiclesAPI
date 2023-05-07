namespace VehiclesAPI.Models
{
    /// <summary>
    /// Class <c>Vehicle</c> Models a api response that contains information on the result of the operation.
    /// </summary>
    public class ApiResponse<T>
    {
        /// <value>
        /// Property <c>Success</c> indicates whether the operation was successful or not.
        /// </value>
        public bool Success { get; set; }
        /// <value>
        /// Property <c>Data</c> contains the data returned by the operation (if successful).
        /// </value>
        public T Data { get; set; }
        /// <value>
        /// Property <c>ErrorMessage</c> contains an error message in case the operation fails.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
