using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanExam
{
    internal class Team
    {
        #region Properties
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public int TeamScore { get; set; }
        #endregion Properties

        #region constructors
        public Team()
        {
            
        }

        #endregion constructors

        #region methods

        public override string ToString()
        {
            return $"{Name} - {TeamScore}";
        }

        public void CalculateTeamScore()
        {
            // Declare Variables
            int scoreSum = 0;

            // Calculate Each players points and add to team score

            foreach(Player player in Players)
            {
                for (int i = 0; i < player.ResultRecord.Length; i++)
                {
                    if (player.ResultRecord[i] == 'W')
                    {
                        scoreSum += 3;
                    }
                    else if (player.ResultRecord[i] == 'D')
                    {
                        scoreSum += 1;
                    }
                }
            }
            TeamScore = scoreSum;
        }
        #endregion methods
    }
}
