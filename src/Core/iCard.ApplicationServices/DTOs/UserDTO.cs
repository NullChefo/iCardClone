namespace iCard.ApplicationServices.DTOs
{
    public class UserDTO
    {   
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Active { get; set; }
        
    }
}