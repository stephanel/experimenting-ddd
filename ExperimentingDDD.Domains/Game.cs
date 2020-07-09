namespace ExperimentingDDD.Domains
{
    public class Game
    {
        public string Name { get; private set; }

        private Game()
        { }

        public static Game Load(string name)
        {
            return new Game()
            {
                Name = name
            };
        }
    }
}
