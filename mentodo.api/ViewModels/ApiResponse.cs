namespace Mentodo.Api.ViewModels
{
    /// <summary>
    /// The generic API response model
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// operation result
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// operation result message
        /// </summary>
        /// <remarks>This field can contain message in all cases (success or false)</remarks>
        public string message { get; set; }

        /// <summary>
        /// during save, this will contain the saved item id
        /// </summary>
        /// <remarks>This is usefull during "add" operation, 
        /// because the client can highlight the newly added item</remarks>
        public int id { get; set; }
    }
}
