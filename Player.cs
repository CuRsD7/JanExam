using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanExam
{
    internal class Player
    {
        #region Properties
        public string Name { get; set; }
        public string ResultRecord { get; set; }
        public int Score { get; set; }
        #endregion Properties
        
        #region constructors
        public Player()
        {

        }

        #endregion constructors

        #region methods
        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {Score}";
        }

        public void CalculateScore()
        {
            // Declare Variables
            int scoreSum = 0;

            // Calculate Score
            for (int i = 0; i < ResultRecord.Length; i++)
            {
                if (ResultRecord[i] == 'W')
                {
                    scoreSum += 3;
                }
                else if (ResultRecord[i] == 'D')
                {
                    scoreSum += 1;
                }
            }
            Score = scoreSum;
        }
        #endregion methods
    }
}
