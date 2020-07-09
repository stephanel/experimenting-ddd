namespace ExperimentingDDD.Domains
{
    public class LineItem
    {
        public Game Game { get; internal set; }

        private LineItem()
        { }

        public static LineItem Load(Game game)
        {
            return new LineItem()
            {
                Game = game
            };
        }
    }
}
