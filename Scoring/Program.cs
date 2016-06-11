using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring {

    /// <summary>
    /// 
    /// 
    /// A program that displays various items from an Olympic Diving Competition
    /// Written by: Martin-Timothy Vu, N9454870 (CAB201)
    /// 
    /// </summary>
    class Program {

        const int LOWEST_POSSIBLE_SCORE = 1;
        const int HIGHEST_POSSIBLE_SCORE = 10;

        //Main method
        static void Main(string[] args) {

            int[,] results ={
                              { 4, 7, 9, 3, 8, 6},
                              { 4, 7, 9, 3, 8, 6},
                              { 4, 8, 6, 4, 8, 5},
                              { 1, 1, 1, 1, 1, 1 },
                              {10, 10, 10, 10, 10, 10},
                             };
            int lowestScore;
            int highestScore;
            int[] competitorTotalScores = new int[results.GetLength(0)];
            int highestTotalScore;
            int[] judgeTotalScores = new int[results.GetLength(1)];
            int highestTotalJudgeScore;

            DisplayWelcomeMessage();

            //For loop displays all relevant information for each competitor
            for (int i = 0; i < results.GetLength(0); i++) {
                DisplayScores(i, results);
                lowestScore = FindLowestScore(i, results);
                highestScore = FindHighestScore(i, results);

                //Places competitor's total score into an array
                competitorTotalScores[i] = CalculateTotalScore(lowestScore, highestScore, i, results);
                DisplayTotalScore(competitorTotalScores[i]);
            }

            highestTotalScore = CalculateHighestTotalScore(competitorTotalScores);
            PrepareToAnnounceWinner();
            DisplayWinners(highestTotalScore, competitorTotalScores);

            //For loop to loop through all judges
            for (int j = 0; j < results.GetLength(1); j++) {
                //Places a judge's total score into an array
                judgeTotalScores[j] = CalculateTotalJudgeScore(j, results);
            }

            highestTotalJudgeScore = CalculateHighestTotalJudgeScore(judgeTotalScores);
            PrepareToAnnounceJudge();
            DisplayHighestTotalJudges(highestTotalJudgeScore, judgeTotalScores);

            PromptExit();
        }//end Main


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Displays a competitor's number and score
        /// </summary>
        /// <param name="competitorNumber"> The number of a competitor e.g Competitor 1, Competitor 2 etc. </param>
        /// <param name="results"> Array of all competitor's individual judge scores </param>
        static void DisplayScores(int competitorNumber, int[,] results) {

            Console.Write("Competitor {0} your scores are\t", (competitorNumber + 1));
            for (int i = 0; i < results.GetLength(1); i++) {
                Console.Write(" " + results[competitorNumber, i]);
            }

            Console.WriteLine();
        }


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Finds the lowest score that was given to a competitor by a judge
        /// </summary>
        /// <param name="competitorNumber"> The number of a competitor e.g Competitor 1, Competitor 2 etc. </param>
        /// <param name="results"> Array of all competitor's individual judge scores </param>
        /// <returns> A competitor's lowest score </returns>
        static int FindLowestScore(int competitorNumber, int[,] results) {

            int lowestScore = HIGHEST_POSSIBLE_SCORE;

            for (int i = 0; i < results.GetLength(1); i++) {
                if (results[competitorNumber, i] < lowestScore) {
                    lowestScore = results[competitorNumber, i];
                } else {
                }
            }

            return lowestScore;
        }
        //end FindLowestScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Finds the highest score that was given to a competitor by a judge
        /// </summary>
        /// <param name="competitorNumber"> The number of a competitor e.g Competitor 1, Competitor 2 etc. </param>
        /// <param name="results"> Array of all competitor's individual judge scores </param>
        /// <returns> A competitor's highest score </returns>
        static int FindHighestScore(int competitorNumber, int[,] results) {

            int highestScore = LOWEST_POSSIBLE_SCORE;

            for (int i = 0; i < results.GetLength(1); i++) {
                if (results[competitorNumber, i] > highestScore) {
                    highestScore = results[competitorNumber, i];
                } else {
                }
            }

            return highestScore;
        }
        //end FindHighestScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Calculates the overall score given to the competitor
        /// </summary>
        /// <param name="lowestScore"> The lowest score received by a competitor </param>
        /// <param name="highestScore"> The highest score received by a competitor </param>
        /// <param name="competitorNumber"> The number of a competitor e.g Competitor 1, Competitor 2 etc. </param>
        /// <param name="results"> Array of all competitor's individual judge scores </param>
        /// <returns> Sum of a competitor's total scores </returns>
        static int CalculateTotalScore(int lowestScore, int highestScore, int competitorNumber, int[,] results) {

            int sumScores = 0;

            for (int i = 0; i < results.GetLength(1); i++) {
                sumScores += results[competitorNumber, i];
            }

            sumScores -= highestScore;
            sumScores -= lowestScore;

            return sumScores;
        }
        //end CalculateTotalScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Displays the overall score given to the competitor
        /// </summary>
        /// <param name="sumScores"> sum of a competitor's scores </param>
        static void DisplayTotalScore(int sumScores) {

            Console.WriteLine("\n\t\tand your score was {0}\n", sumScores);
        }
        //endDisplayTotalScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Calculates the highest total score
        /// </summary>
        /// <param name="competitorTotalScores"> An array of all the competitor's total scores </param>
        /// <returns> The highest total competitor score </returns>
        static int CalculateHighestTotalScore(int[] competitorTotalScores) {

            int highestTotalScore = 0;

            //For loop finds the highest total score out of the competitors
            for (int i = 0; i < competitorTotalScores.Length; i++) {
                if (competitorTotalScores[i] > highestTotalScore) {
                    highestTotalScore = competitorTotalScores[i];
                } else {
                }
            }

            return highestTotalScore;
        }
        //end CalculateHighestTotalScore


        //-------------------------------------------------------------------------------------------------------------------


        //Prepares to announce the winner/winners
        static void PrepareToAnnounceWinner() {

            Console.Write("\n\nand the winner/winners is/are");
        }
        //end PrepareToAnnounceWinner


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Displays the winner/winners
        /// </summary>
        /// <param name="highestTotalScore"> The highest total compeitor score </param>
        /// <param name="competitorTotalScores"> An array of all the competitor's total scores </param>
        static void DisplayWinners(int highestTotalScore, int[] competitorTotalScores) {

            for (int i = 0; i < competitorTotalScores.Length; i++) {
                if (competitorTotalScores[i] == highestTotalScore) {
                    Console.Write(" competitor {0}", (i + 1));
                }
            }
        }
        //end DisplayWinner


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Displays the winning score
        /// </summary>
        /// <param name="highestTotalScore"> The highest total competitor score </param>
        static void DisplayWinningScore(int highestTotalScore) {

            Console.WriteLine(" with a score of {0}", highestTotalScore);
        }
        //end DisplayWinningScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Calculates the judges total score
        /// </summary>
        /// <param name="judgeNumber"> The number of a judge i.e 1st judge, 2nd judge etc. </param>
        /// <param name="results"> Array of all competitor's individual judge scores </param>
        /// <returns> The total score for a judge </returns>
        static int CalculateTotalJudgeScore(int judgeNumber, int[,] results) {

            int tempTotalJudgeScore = 0;

            for (int k = 0; k < results.GetLength(0); k++) {
                tempTotalJudgeScore += results[k, judgeNumber];
            }

            return tempTotalJudgeScore;
        }
        //end CalculateTotalJudgeScore


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Calculates the highest total judge score
        /// </summary>
        /// <param name="judgeTotalScores"> Total judge score for a judge </param>
        /// <returns> The highest total judge score </returns>
        static int CalculateHighestTotalJudgeScore(int[] judgeTotalScores) {

            int highestJudgeTotal = 0;

            //For loop finds the highest average score out of all the judges
            for (int i = 0; i < judgeTotalScores.Length; i++) {
                if (judgeTotalScores[i] > highestJudgeTotal) {
                    highestJudgeTotal = judgeTotalScores[i];
                } else {
                }
            }

            return highestJudgeTotal;
        }
        //end CalculateHighestJudgeTotal


        //-------------------------------------------------------------------------------------------------------------------


        //Prepares to announce the judge/judges with the highest score total
        static void PrepareToAnnounceJudge() {

            Console.Write("\n\n\nthe judge/judges");
        }
        //end PrepareToAnnounceJudge


        //-------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Displays the judge/judges with the highest totals
        /// </summary>
        /// <param name="highestTotalJudgeScore"> The highest total judge score </param>
        /// <param name="judgeTotalScores"> An array of all the judges total scores </param>
        static void DisplayHighestTotalJudges(int highestTotalJudgeScore, int[] judgeTotalScores) {

            for (int l = 0; l < judgeTotalScores.Length; l++) {
                if (judgeTotalScores[l] == highestTotalJudgeScore) {
                    Console.Write(" {0},", (l + 1));
                } else {
                }
            }

            Console.WriteLine(" with the highest scores total of {0}", highestTotalJudgeScore);
        }
        //end DisplayHighestJudge


        //-------------------------------------------------------------------------------------------------------------------

        //Displays a welcome message
        static void DisplayWelcomeMessage() {

            Console.WriteLine("Welcome to the judging for Olympic Diving!\n\n\n");
        }
        //end DisplayWelcomeMessage


        //-------------------------------------------------------------------------------------------------------------------


        //Prompts user for input before exiting     
        static void PromptExit() {

            Console.WriteLine("\n\n\nPress any key to exit:");
            Console.ReadKey();
        }
        //end PromptExit

    }//end class
}//end namespace
