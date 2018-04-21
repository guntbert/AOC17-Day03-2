using System;
using System.Collections.Generic;

namespace Day03_2a
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Point, int> Tiles = new Dictionary<Point, int>();
            // the active element
            Head activeSpot = new Head() { Coords = new Point(0, 0), Heading = Direction.East };
            Tiles.Add(activeSpot.Coords, 0);




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
        bool isPlaceOnTheLeftEmpy(Dictionary<Point, int> currentPattern, Head currentItem)
        {
            Point locationToCheck = new Point();
            switch (currentItem.Heading)
            {
                case Direction.East:
                    // left is north
                    locationToCheck.X = currentItem.Coords.X;
                    locationToCheck.Y = currentItem.Coords.Y - 1;
                    break;
                case Direction.North:
                    //left is west
                    locationToCheck.X = currentItem.Coords.X-1;
                    locationToCheck.Y = currentItem.Coords.Y ;
                    break;
                case Direction.West:
                    //left is south
                    locationToCheck.X = currentItem.Coords.X;
                    locationToCheck.Y = currentItem.Coords.Y + 1;
                    break;
                case Direction.South:
                    //left is east
                    locationToCheck.X = currentItem.Coords.X+1;
                    locationToCheck.Y = currentItem.Coords.Y ;
                    break;

                default:
                throw new ArgumentException();
            }
            return currentPattern.ContainsKey(locationToCheck);

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

