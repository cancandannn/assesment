using System;

public class Rover
{
    private int x;
    private int y;
    private char direction;
    private readonly int plateauX;
    private readonly int plateauY;

    public Rover(int x, int y, int plateauX, int plateauY, char direction)
    {
        this.x = x;
        this.y = y;
        this.plateauX = plateauX;
        this.plateauY = plateauY;
        this.direction = direction;
    }

    public void Move(char command)
    {
        switch (command)
        {
            default:
                throw new ArgumentException("Unexpected command");
            case 'L':
            case 'l':
                TurnLeft();
                break;
            case 'R':
            case 'r':
                TurnRight();
                break;
            case 'M':
            case 'm':
                MoveForward();
                break;
        }
    }

    private void TurnLeft()
    {
        switch (direction)
        {
            case 'N':
            case 'n':
                direction = 'W';
                break;
            case 'W':
            case 'w':
                direction = 'S';
                break;
            case 'S':
            case 's':
                direction = 'E';
                break;
            case 'E':
            case 'e':
                direction = 'N';
                break;
        }
    }

    private void TurnRight()
    {
        switch (direction)
        {
            case 'N':
            case 'n':
                direction = 'E';
                break;
            case 'E':
            case 'e':
                direction = 'S';
                break;
            case 'S':
            case 's':
                direction = 'W';
                break;
            case 'W':
            case 'w':
                direction = 'N';
                break;
        }
    }

    private void MoveForward()
    {
        switch (direction)
        {
            case 'N':
            case 'n':
                if (y + 1 <= plateauY)
                {
                    y++;
                }
                break;
            case 'E':
            case 'e':
                if (x + 1 <= plateauX)
                {
                    x++;
                }
                break;
            case 'S':
            case 's':
                if (y - 1 >= 0)
                {
                    y--;
                }
                break;
            case 'W':
            case 'w':
                if (x - 1 >= 0)
                {
                    x--;
                }
                break;
        }
    }

    public override string ToString()
    {
        return $"{x} {y} {direction}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] plateauSize = Console.ReadLine().Split(' ');
        int plateauX = int.Parse(plateauSize[0]);
        int plateauY = int.Parse(plateauSize[1]);

        while (true)
        {
            string[] currentPosition = Console.ReadLine().Split(' ');
            int x = int.Parse(currentPosition[0]);
            int y = int.Parse(currentPosition[1]);
            char direction = char.Parse(currentPosition[2]);

            Rover rover = new Rover(x, y, direction, plateauX, plateauY);

            string commands = Console.ReadLine();
            foreach (char command in commands)
            {
                rover.Move(command);
            }
            Console.WriteLine(rover.ToString());
            string question = "Do You Want To Add Another Rover ? (Y/N)";
            Console.WriteLine(question);

            string moreRovers = Console.ReadLine();
            if (moreRovers != "Y" && moreRovers != "y")
            {
                break;
            }
        }
    }
}