namespace Mentodo.Api.Model
{
    public class Todo
    {
        /// <summary>
        /// the id of the item
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// task done flag
        /// </summary>
        public bool done { get; set; }
        
        /// <summary>
        /// the task todo :-)
        /// </summary>
        public string info { get; set; }
        
        /// <summary>
        /// task priority
        /// </summary>
        public int priority { get; set; }
    }
}
