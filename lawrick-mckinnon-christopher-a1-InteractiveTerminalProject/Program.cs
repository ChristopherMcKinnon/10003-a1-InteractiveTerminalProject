// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");




/* Note 
 
 I was not allowed to use loops, classes, functions, lists, string attributes (e.g. length, split)
 
 
 */



bool flag1 = false;
bool flag2 = false;
bool flag3 = false;
bool flag4 = false;


string rule1 = "Rule 1: Create a strong password";
string rule2 = "Rule 2: Create a password containing a common fruit";
string rule3 = "Rule 3: There must be no roman numerals in your name";
string rule4 = "Rule 4: Create a password containing a common fruit";

// Introduction

Console.WriteLine("You are a penetration tester trying to find the single-best password a person can have.");

// Challenge 1

// Print challenge
Console.WriteLine(rule1);
// Get player input
string playerInput = Console.ReadLine();

Console.WriteLine($"Your password: {playerInput}");

Console.WriteLine("Challenge 1 completed.");

flag1 = true;

// Challenge 2
if (flag1 == true)
{
    // Print challenge
    Console.WriteLine(rule1);
    Console.WriteLine(rule2);
    // Get player input
    playerInput = Console.ReadLine();
    Console.WriteLine($"Your password: {playerInput}");

    // Check against current rules (2)
    if (playerInput.Contains("apple") || playerInput.Contains("banana") || playerInput.Contains("orange"))
    {
        Console.WriteLine("Challenge 2 completed.");
        flag2 = true;
    }
    else
    {
        Console.WriteLine("You failed");
    }

}

// Challenge 3
if  (flag2 == true)
{
    // Print challenge
    Console.WriteLine(rule1);
    Console.WriteLine(rule2);
    Console.WriteLine(rule3);

    // Get player input
    playerInput = Console.ReadLine();

    // Check against current rules (3)
    if (playerInput.Contains("apple") || playerInput.Contains("banana") || playerInput.Contains("orange"))
    {
        if (!playerInput.Contains('i') && !playerInput.Contains(I) && !playerInput.Contains('e') && !playerInput.Contains('E') && !playerInput.Contains('v') && !playerInput.Contains('V') && !playerInput.Contains('x') && !playerInput.Contains('X') && !playerInput.Contains('l') && !playerInput.Contains('L') && !playerInput.Contains('c') && !playerInput.Contains('C') && !playerInput.Contains('d') && !playerInput.Contains('D') && !playerInput.Contains('m') && !playerInput.Contains('M'))
        {
            Console.WriteLine("Yipee");
        } else
        {
            Console.WriteLine("You failed");
        }
    } else
    {
        Console.WriteLine("You failed");
    }
}