namespace WebApplication4.Models
{
     [Serializable]
    public class FlatCollection
    {
       
            public List<FlatModel> Collection { get; set; }
            public FlatCollection()
            {
                Collection = new List<FlatModel>();
            }

            public FlatCollection(List<FlatModel> collection)
            {
                Collection = collection;
            }
    }
}

