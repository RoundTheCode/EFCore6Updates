namespace RoundTheCode.EFCore.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public int TeamId {  get; set; }

        public string FirstName { get; set; }

        public string Surname {  get; set; }

        public Team Team {  get; set; }
    }
}
