
// Inform player of situation and options
Console.WriteLine("You are an adventurer, you find yourself at a fork in the road. You can go left (1), turning into a town. You can also go right (2), heading towards a mountain. Which one will you choose?");
// Read player input
string playerChoice = Console.ReadLine();

// Process player input and inform them of their choices
if (playerChoice == "1")
{
    Console.WriteLine("You head left, turning into the small town looking for an Inn for the night.");
}
else if (playerChoice == "2")
{
    Console.WriteLine("You head right, preferring the isolation the mountain path will provide when compared to any socialistic activities.");
}
else // Handle input errors
{
    Console.WriteLine("You chose an incorrect input.");
}
