// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



// Choose floor 1 then 2 and repeat to see 'goto' example


int choice;

int x = 5;
if  (x == 5)
{
    firstFloor:

    Console.WriteLine("Lore lore and more lore. Pick your lore.\n(1)Lore one\n(2)Lore two");
    choice = int.Parse(Console.ReadLine());
    if (choice == 1)
    {
        Console.WriteLine("you chose 1, (1) keep going?\n(2) Go Back");
        choice = int.Parse(Console.ReadLine());
        if (choice == 2)
        {
            goto firstFloor;
        }
    }
}