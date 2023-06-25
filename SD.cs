namespace SignalrApp
{
    public static class SD
    {
        static SD()
        {
            DealthyHallowRace = new Dictionary<string, int>
            {
                { Wand, 0 },
                { Stone, 0 },
                { Cloack, 0 }
            };
        }
        public const string Wand = "Wand";
        public const string Stone = "Stone";
        public const string Cloack = "Cloack";

        public static Dictionary<string, int> DealthyHallowRace;
    }
}
