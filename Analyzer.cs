using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    abstract internal class Analyzer
    {
            protected char[,] grid;
            protected Tuple<int, int, bool>[] samples;
            protected int guessCount;
            protected int rows;
            protected int cols;

            public Analyzer(int rows, int cols)
            {
                this.rows = rows;
                this.cols = cols;
                grid = new char[rows, cols];
                samples = new Tuple<int, int, bool>[2];
                guessCount = 0;
                InitializeGrid();
                PlaceSamples();
            }

            // Abstract methods to be implemented by derived classes
            public abstract void AnalyzeSample(int row, int col);
            public abstract void MakeGuess(int row, int col);

            //getter fucntions
            public int GetRows()
            {
                return rows;
            }
            public int GetCols()
            {
                return cols;
            }
            public int GetGuessCount()
            {
                return guessCount;
            }
            //setter functions
            public void SetGuessCount(int x)
            {
                guessCount = x;
            }

            // Concrete method: Initializes the grid with '~'
            private void InitializeGrid()
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        grid[i, j] = '~';
                    }
                }
            }

            // Concrete method: Places the samples at random positions
            private void PlaceSamples()
            {
                Random rand = new Random();
                samples[0] = new Tuple<int, int, bool>(rand.Next(rows), rand.Next(cols), false);
                do
                {
                    samples[1] = new Tuple<int, int, bool>(rand.Next(rows), rand.Next(cols), false);
                } while (samples[1].Item1 == samples[0].Item1 && samples[1].Item2 == samples[0].Item2);
            }
        }

        public class DNAAnalyzer : Analyzer
        {
            public DNAAnalyzer(int rows, int cols) : base(rows, cols) { }

            // Example of how to implement the abstract method for analyzing a sample
            public override void AnalyzeSample(int row, int col)
            {
                // Simple analysis logic (for example, marking the sample as analyzed)
                if (samples[0].Item1 == row && samples[0].Item2 == col)
                    samples[0] = new Tuple<int, int, bool>(row, col, true);
                else if (samples[1].Item1 == row && samples[1].Item2 == col)
                    samples[1] = new Tuple<int, int, bool>(row, col, true);
            }

            // Example of how to implement the abstract method for making a guess
            public override void MakeGuess(int row, int col)
            {
                guessCount++;
                if (grid[row, col] == '~')
                {
                    grid[row, col] = 'X'; // Mark the guessed position
                }
            }

        }
    }
