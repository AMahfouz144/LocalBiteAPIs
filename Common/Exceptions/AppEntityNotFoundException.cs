namespace Common
{
    public class AppEntityNotFoundException : AppException
    {
        public string EntityName { set; get; }
        public object EntityId { set; get; }

        public AppEntityNotFoundException()
            : base(ExceptionType.EntityNotFound)
        {
           this.StatusCode = 406;
        }
    }

    public class AppEntityNotFoundException<T> : AppEntityNotFoundException
    {
        public AppEntityNotFoundException(object entityId)
            : base()
        {
            this.EntityName = nameof(T);
            this.ClientMessage = $"{this.EntityName} object with id : {entityId} is not exists in datasource.";
            this.EntityId = entityId;
        }
    }
}