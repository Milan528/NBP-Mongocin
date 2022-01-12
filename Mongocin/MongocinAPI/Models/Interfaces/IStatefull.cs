namespace MongocinAPI.Models
{
    public interface IStatefull
    {
        StateEnum State
        {
            get;
            set;
        }

    }

}
