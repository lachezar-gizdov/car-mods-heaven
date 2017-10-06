namespace CarModsHeaven.Data.Models.Common
{
    public class Score
    {
        public int Sum { get; set; }

        public int VotersCount { get; set; }

        public int GetScore()
        {
            if (VotersCount == 0)
            {
                return 0;
            }
            else
            {
                return Sum / VotersCount;
            }
        }
    }
}
