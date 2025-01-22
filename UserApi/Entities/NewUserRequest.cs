using System.ComponentModel.DataAnnotations;

namespace UserApi.Entities
{
    public class NewUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
