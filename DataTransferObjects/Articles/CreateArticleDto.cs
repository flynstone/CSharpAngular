using System.ComponentModel.DataAnnotations;

namespace CSharpAngular.Api.DataTransferObjects.Articles
{
    public class CreateArticleDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    }
}
