namespace FunApp.Web.Models.Jokes
{
    public class CreateJokeInputModel
    {
        public string Content  { get; set; }

        [ValidateCategoryId]
        public int CategoryId { get; set; }
    }
}
