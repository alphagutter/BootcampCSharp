namespace Core.Exceptions;

/// <summary>
/// Throws the exception when the logic of the Business does not match to the new Data
/// </summary>
public class BusinessLogicException : Exception
{
    //variables that the service throws to us    
    public string nameUsed {  get; }
    public string entityName { get; }

    //throws a message exception when the name exists in the entityname provided
    public BusinessLogicException(string nameUsed, string entityName) 
        : base($"Name '{nameUsed}' already exists for '{entityName}'")
    {
        this.nameUsed = nameUsed;
        this.entityName = entityName;
    }
}