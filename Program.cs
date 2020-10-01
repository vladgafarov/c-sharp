using System;

namespace Square
{
    class Program
    {
        static void Main()
        {
            CheckSquare(0, 1, 1, 0, 1, 1); // 0 0
            CheckSquare(0, 0, 1, 0, 1, 1); // 0 1
            CheckSquare(0, 0, -1, 0, 0, -1); // -1 -1
            CheckSquare(-1, 1, 1, 3, 1, 1); // -1 3
            CheckSquare(-1, 0, 10, 3, 11, 1); // It's not a square
        }

        public static double GetLength(int x1, int y1, int i, int j)
        {
            var length = Math.Sqrt((x1 - i) * (x1 - i) + (y1 - j) * (y1 - j));
            return length;
        }

        public static double CompareX1(int x1, int y1, int j, int length)
        {
            var x = x1 - Math.Sqrt(-(y1 * y1) + 2 * y1 * j - j * j + length * length);
            return x;
        }

        public static double CompareX2(int x1, int y1, int j, int length)
        {
            var x = x1 + Math.Sqrt(-(y1 * y1) + 2 * y1 * j - j * j + length * length);
            return x;
        }

        public static void CheckSquare(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            if (x1 == x2 && y1 == y2 || x3 == x2 && y3 == y2 || x1 == x3 && y1 == y3)
            {
                Console.WriteLine("Not 3 uniq items");
            }  
            else
            {
                var length1 = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
                var length2 = Math.Sqrt(Math.Pow((x2 - x3), 2) + Math.Pow((y2 - y3), 2));
                var length3 = Math.Sqrt(Math.Pow((x1 - x3), 2) + Math.Pow((y1 - y3), 2));

                if (length1 == length2)
                {
                    if ((float)(2 * length2 * length2) == (float)(length3 * length3))
                    {
                        Console.WriteLine("It's square");
                        FindCoordinates(x1, y1, x2, y2, x3, y3, 2, (int)Math.Ceiling(length1));
                    }
                    else Console.WriteLine("It's not a square");
                }
                else if (length2 == length3)
                {
                    if ((float)(2 * length2 * length2) == (float)(length1 * length1))
                    {
                        Console.WriteLine("It's square");
                        FindCoordinates(x1, y1, x2, y2, x3, y3, 3, (int)Math.Ceiling(length2));
                    }
                    else Console.WriteLine("It's not a square");
                }
                else if (length1 == length3)
                {
                    if ((float)(2 * length1 * length1) == (float)(length2 * length2))
                    {
                        Console.WriteLine("It's square");
                        FindCoordinates(x1, y1, x2, y2, x3, y3, 1, (int)Math.Ceiling(length1));
                    }
                    else Console.WriteLine("It's not a square");
                }
                else Console.WriteLine("It's not a square");

            }
        }
        public static void FindCoordinates(int x1, int y1, int x2, int y2, int x3, int y3, int commonPoint, int length)
        {
            int x = 100;
            int y = 100;
            int nearX;
            int nearY;
            int nearX2;
            int nearY2;
            int oppositeX;
            int oppositeY;

            if (commonPoint == 1)
            {
                nearX = x2; 
                nearY = y2;
                nearX2 = x3;
                nearY2 = y3;
                oppositeX = x1;
                oppositeY = y1;
            }    
            else if (commonPoint == 2)
            {
                nearX = x3; 
                nearY = y3;
                nearX2 = x1;
                nearY2 = y1;
                oppositeX = x2;
                oppositeY = y2;
            }  
            else
            {
                nearX = x1; 
                nearY = y1;
                nearX2 = x2;
                nearY2 = y2;
                oppositeX = x3;
                oppositeY = y3;
            }

            for (int i = nearX - length; i <= nearX + length; i++)
            {
                for (int j = nearY - length; j <= nearY + length; j++)
                {
                    if (i == CompareX1(nearX, nearY, j, length)
                        && length == GetLength(nearX, nearY, i, j)
                        && length == GetLength(nearX2, nearY2, i, j)
                        && length*Math.Sqrt(2) == GetLength(oppositeX, oppositeY, i, j))
                    {
                        x = i;
                        y = j;
                    }
                    if (i == CompareX2(nearX, nearY, j, length)
                        && length == GetLength(nearX, nearY, i, j)
                        && length == GetLength(nearX2, nearY2, i, j)
                        && length * Math.Sqrt(2) == GetLength(oppositeX, oppositeY, i, j))
                    {
                        x = i;
                        y = j;
                    }
                }
            }
 
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);
        }
    }
}
