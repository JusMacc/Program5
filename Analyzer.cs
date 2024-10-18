using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    abstract internal class Analyzer
    {
       
            private char[,] grid;
            private Tuple<int, int, bool>[] samples;
            private int guessCount;
            private int rows;
            private int cols;

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

            //Getter functions
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

            //this function creates the samples and makes sure that the
            //samples are not in the same spot
            private void PlaceSamples()
            {
                Random rand = new Random();
                samples[0] = new Tuple<int, int, bool>(rand.Next(rows), rand.Next(cols), false);
                do
                {
                    samples[1] = new Tuple<int, int, bool>(rand.Next(rows), rand.Next(cols), false);
                } while (samples[1].Item1 == samples[0].Item1 && samples[1].Item2 == samples[0].Item2);
            }

            //this function displays the grid to the form
            public void DisplayGrid(ListBox listBox)
            {
                listBox.Items.Clear();
                for (int i = 0; i < rows; i++)
                {
                    string row = "";
                    for (int j = 0; j < cols; j++)
                    {
                        row += grid[i, j];
                    }
                    listBox.Items.Add(row);
                }
            }

        }
    }
