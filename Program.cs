using System;
using System.Collections.Generic;

namespace Day03_2a
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Point, int> Tiles = new Dictionary<Point, int>();
            Tiles.Add(new Point { X = 0, Y = 0 }, 0);


        }

        // 
    }

    enum Direction
    {
        North,
        East,
        South,
        West
    }
    class Environment
    {
        bool isPlaceOnTheLeftEmpy(Dictionary<Point, int> currentPattern, Point currentLocation)
        {
            Point checkThis = new Point { X = currentLocation.X - 1, Y = currentLocation.Y };
            return currentPattern.ContainsKey(checkThis);

        }

        long DetermineValueOfTile(Dictionary<Point, int> currentPattern, Point currentLocation)
        {
            long sum = 0;
            // einmal rundherum
            int x0 = currentLocation.X, y0 = currentLocation.Y;
            // check: (x0-1,y0-1),(x0-1,y0),(x0-1,y0+1),(x0,y0-1),...
            // left side
            for (int xCheck = x0 - 1; xCheck <= x0 + 1; xCheck += 2)
            {
                for (int yCheck = -1; yCheck <= 1; yCheck++)
                {
                    Point checkThis = new Point(xCheck, yCheck);
                    if (currentPattern.ContainsKey(checkThis))
                        sum += currentPattern[currentLocation];
                }
            }
            return sum;

        }
    }
}

