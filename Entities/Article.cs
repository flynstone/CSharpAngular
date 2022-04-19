using System.ComponentModel.DataAnnotations;

namespace CSharpAngular.Api.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
