using NZWalks.Api.Business.Models;

namespace NZWalks.Api.Business.Services
{
    public class WalkScoreCalculator
    {
        public int CalculateBaseScore(double lengthInKm)
        {
            if (lengthInKm <= 0)
            {
                throw new InvalidOperationException("Getal mag niet nul of negatief zijn.");
            }

            int score = 0;
            if (lengthInKm <= 5)
            {
                score = 5;
            }
            else if (lengthInKm <= 10)
            {
                score = 7;
            }
            else
            {
                score = 4;
            }
            return score;
        }

        public int CalculateClimateScore(Walk walk)
        {
            int climateScore = 0;

            switch (walk.Region.Climate)
            {
                case Climate.Rainy:
                    climateScore = -1;
                    break;

                case Climate.Sweltering:
                    climateScore = -1;
                    break;

                case Climate.Sunny:
                    climateScore = 2;
                    break;

                case Climate.Cloudy:
                    climateScore = -1;
                    break;

                case Climate.Unknown:
                case Climate.Misty:
                default:
                    climateScore = 0;
                    break;
            }

            return climateScore;
        }

        public int CalculateTotalScore(Walk walk)
        {
            int score = CalculateBaseScore(walk.LengthInKm);
            int climateScore = CalculateClimateScore(walk);
            int totalScore = score + climateScore;

            return totalScore;
        }
    }
}