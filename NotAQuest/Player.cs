namespace NotAQuest
{
    class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            this.Name = name.Trim();
        }
    }
}
