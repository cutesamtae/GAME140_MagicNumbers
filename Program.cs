// Seed the random number generator
Random random = new Random();

// A Random value between 10 and 20
int numStonesRemaining = random.Next(10, 21);
int numStonesToTake = 0;

Console.WriteLine("*********************");
Console.WriteLine("*** Magic Numbers ***");
Console.WriteLine("*********************");

Console.WriteLine($"There are {numStonesRemaining} stones. Take 1, 2, or 3.");
Console.WriteLine("To win, don't take the last one.");

/*string output = "*********************\n" +
                "*** Magic Numbers ***\n" +
                "*********************\n\n";
Console.WriteLine(output);*/

while (numStonesRemaining > 0)
{
    // Player Turn
    Console.WriteLine("\nPlayer's Turn.");
    Console.WriteLine($"\nThere are currently {numStonesRemaining} stones left.");
    do
    {
        Console.Write("Enter the number of stones to take : ");
        string? playerInput = Console.ReadLine();

        Console.WriteLine("The player responded with " + playerInput);

        if (playerInput == "1")
        {
            numStonesToTake = 1;
        }
        else if ((playerInput == "2") && (numStonesRemaining >= 2))
        {
            numStonesToTake = 2;
        }
        else if ((playerInput == "3") && (numStonesRemaining >= 3))
        {
            numStonesToTake = 3;
        }
        else if (numStonesRemaining == 1)
        {
            numStonesToTake = 1;
        }
        else
        {
            Console.WriteLine("Invalied input. Try again.");
            numStonesToTake = 0;
        }
    } while (numStonesToTake == 0);

    Console.WriteLine($"The player takes away {numStonesToTake} stones!");
    numStonesRemaining -= numStonesToTake;
    Console.WriteLine($"There are now {numStonesRemaining} stones!");
    
    if (numStonesRemaining == 0)
    {
        Console.WriteLine("\nThe player took the last stone. You lose!");
        break;
    }
    
    // Computers(AI) Turn
    Console.WriteLine("\nComputer's Turn.");
    Thread.Sleep(millisecondsTimeout:1000);

    if (numStonesRemaining == 3)
    {
        numStonesToTake = 2;
    }
    else if (numStonesRemaining == 2)
    {
        numStonesToTake = 1;
    }
    else
    {
        numStonesToTake = random.Next(1, 4);
    }
    
    Console.WriteLine($"The computer takes away {numStonesToTake} stones!");
    numStonesRemaining -= numStonesToTake;
    Console.WriteLine($"There are now {numStonesRemaining} stones!");

    if (numStonesRemaining == 0)
    {
        Console.WriteLine("\nThe computer took the last stone. You win!");
    }
}


