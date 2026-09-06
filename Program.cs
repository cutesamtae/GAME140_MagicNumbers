/*****************************************************************************
 // File Name:         Program.cs
 // Author:            Hongseok Kim
 // Creation Date:     Sep 6, 2026
 //
 // Brief Description: A turn-based game in which the player and the computer take turns placing stones.
    The player who places the last stone loses.
 *****************************************************************************/

using System;
using System.Threading;

// Function: Main
// Description: The main execution loop of the Magic Numbers game.
class Program
{
    static void Main(string[] args)
    {
        // Seed the random number generator
        Random random = new Random();

        bool KeepPlaying = true;

        while (KeepPlaying)
        {
            // A Random value between 10 and 20
            int numStonesRemaining = random.Next(10, 21);
            int numStonesToTake = 0;

            Console.WriteLine("*********************");
            Console.WriteLine("*** Magic Numbers ***");
            Console.WriteLine("*********************");

            Console.WriteLine($"There are {numStonesRemaining} stones. Take 1, 2, or 3.");
            Console.WriteLine("To win, don't take the last one.");
            
            // First Player Option
            bool isPlayerTurn = true; // True is Player Turn, False is Computer's Turn

            while (true)
            {
                Console.WriteLine("Do you want to go first? (y/n): ");
                string? FirstPlayerInput = Console.ReadLine();

                if (FirstPlayerInput == "y")
                {
                    isPlayerTurn = true;
                    break;
                }
                else if (FirstPlayerInput == "n")
                {
                    isPlayerTurn = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            // Core Game Loop
            while (numStonesRemaining > 0)
            {
                if (isPlayerTurn)
                {
                    // Player Turn Logic
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
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            numStonesToTake = 0;
                        }
                    } while (numStonesToTake == 0);

                    Console.WriteLine($"The player takes away {numStonesToTake} stones!");
                    numStonesRemaining -= numStonesToTake;
                    Console.WriteLine($"There are now {numStonesRemaining} stones!");
    
                    if (numStonesRemaining == 0)
                    {
                        Console.WriteLine("\nThe player took the last stone. You lose!");
                        break; // End of Game
                    }
                
                    // Pass Turn
                    isPlayerTurn = false;
                }
                else
                {
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
                    else if (numStonesRemaining == 1)
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
                        break; // End of Game
                    }
                    
                    // Pass Turn
                    isPlayerTurn = true;
                }
            }

            // Play again options
            while (true)
            {
                Console.Write("Play Again? (y/n): ");
                string? PlayAgain = Console.ReadLine();

                if (PlayAgain == "y")
                {
                    KeepPlaying = true;
                    break;
                }
                else if (PlayAgain == "n")
                {
                    KeepPlaying = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
        }
    }
}


