
namespace Core.Exceptions
{

    /// <summary>
    /// class to throw an exception when an entity was not founded by their id
    /// </summary>
    public class NotFoundByIdException : NotFoundException

    {
        //it recieves both of this variables, to print a personalized exception for it
        public string entityName { get; }
        public int id { get; }

        /// <summary>
        /// prints the entity that does not exist
        /// </summary>
        public NotFoundByIdException(string entityName, int id) 
            : base($"Entity '{entityName}' with ID: {id} does not exist")
        {
            this.entityName = entityName;
            this.id = id;
        }
    }
}
