// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            // Initialize variables
            string[] spaces = {"1","2","3","4","5","6","7","8","9"}; // Board spaces with number assigned
            int selected = 0; // The space determined by the user
            int player = 1; // The player to go next
            int complete = 0; // Is the game complete (0 is no; 1 or 2 for winner; -1 is a Draw)

            // Continue to allow each player to select squares until a player wins or a draw occurs with all spaces selected
            while(complete == 0) {
                Console.Clear();  // Clear the board after each turn
                Console.WriteLine("Player " + player + " turn:"); // Identify which player's turn it is

                // Generate a simple board
                Console.WriteLine("--------------------------");
                Console.WriteLine("|  "+spaces[0]+"    |    "+spaces[1]+"   |   "+spaces[2]+"   |");
                Console.WriteLine("--------------------------");
                Console.WriteLine("|   "+spaces[3]+"   |    "+spaces[4]+"   |   "+spaces[5]+"   |");
                Console.WriteLine("--------------------------");
                Console.WriteLine("|   "+spaces[6]+"   |    "+spaces[7]+"   |   "+spaces[8]+"   |");
                Console.WriteLine("--------------------------");

                // Prompt user for input
                Console.WriteLine("Please input a number between 1 and 9:");

                // Catch number exception
                try{
                    selected = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Number exception: " + e.Message);                    
                    Console.WriteLine("Please input a number between 1 and 9:");
                    selected = int.Parse(Console.ReadLine());
                }

                // Verify that the users selection is in the range of spaces available
                while( selected < 1 || selected > spaces.Length) {
                    Console.WriteLine("Please input a number between 1 and 9:");
                    selected = int.Parse(Console.ReadLine());
                }

                // Provide feedback for the player selection
                Console.WriteLine("Player " + player + " selected cell: " + (selected));

                // Determine which character to assign to the space on the board selected
                if(spaces[selected-1] != "X" && spaces[selected-1] != "O"){
                    if(player == 1) {
                        spaces[selected-1] = "X";
                        if(Complete(spaces,"X",1) != player)
                        {
                            player++;
                        } else {
                            complete = player;
                        }
                    } else {
                        spaces[selected-1] = "O";
                        if(Complete(spaces,"O",1) != player)
                        {
                            player--;
                        } else {
                            complete = player;
                        }
                    }
                }

                // Check for a draw
                if(Complete(spaces,"X",1) == -1) {
                    complete = -1;
                }

            }
           
            // The game is complete
            if(complete != -1) { // Display the winner
                Console.WriteLine("The winner is: " + complete + "!");
            } else { // Display Draw message
                Console.WriteLine("The game was a DRAW!");
            }
    

        }

        // Test for completed game, determine if win or draw
        private static int Complete(string[] spaces, string lttr, int player) {
            
            int status = 0;
            int count = 0;

            // Horizontal Row 1
            if(spaces[0] == lttr && spaces[1] == lttr && spaces[2] == lttr) {
                status = player;
            }
            // Horizontal Row 2
            if(spaces[3] == lttr && spaces[4] == lttr && spaces[5] == lttr) {
                status = player;
            }
            // Horizontal Row 3
            if(spaces[6] == lttr && spaces[7] == lttr && spaces[8] == lttr) {
                status = player;
            }
            // Diagonal Top Left to Bottom Right
            if(spaces[0] == lttr && spaces[4] == lttr && spaces[8] == lttr) {
                status = player;
            }
            // Diagonal Bottom Left to Top Right
            if(spaces[2] == lttr && spaces[4] == lttr && spaces[6] == lttr) {
                status = player;
            }
            // Vertical Column 1
            if(spaces[0] == lttr && spaces[3] == lttr && spaces[5] == lttr) {
                status = player;
            }
            // Vertical Column 2
            if(spaces[1] == lttr && spaces[4] == lttr && spaces[7] == lttr) {
                status = player;
            }
            // Vertical Column 3
            if(spaces[2] == lttr && spaces[5] == lttr && spaces[8] == lttr) {
                status = player;
            }

            // Check to see if the game was a draw
            for(int i = 0; i < spaces.Length; i++) {
                if(spaces[i] != (i+1).ToString()){
                    count++;   
                }
            }
 
            if(count == spaces.Length) {
                status = -1;
            }

            return status;

        }
    }

    
}
