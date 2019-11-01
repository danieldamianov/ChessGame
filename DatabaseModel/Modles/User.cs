using DatabaseModel.Modles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class User
    {
        public User()
        {
            this.UsersGamesLikeWhite = new List<UsersGame>();
            this.UsersGamesLikeBlack = new List<UsersGame>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public List<UsersGame> UsersGamesLikeWhite { get; set; }
        public List<UsersGame> UsersGamesLikeBlack { get; set; }
    }
}