using System;
namespace CyberBlight.engine 
{

    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Threading;

    public class Logic 
    {
            public static string focus = "console_main_menu";
    }
    
    
    public class engine
    {
        // these functions should be used throughout the project to automate
        // repetetive or complex tasks.
        // this is the 'engine' of our game.


        public static void slow_type(string text, int typing_speed = 100, bool new_line = true)
        {
        // print function that feels like a human is typing.
        //
        //typing_speed is an integer that equals words per minute.
        //
        //new_line is a boolean, it controls weather the console will begin 
        //the next print operation on the same line or a new line.
            Random rng = new Random();
            foreach (var letter in text)
            {
            //this looks at each letter and prints it, then waits a random amount of time.
                Console.Write(letter);
                //sys.stdout.flush();
                
                Thread.Sleep(rng.Next(0, typing_speed));

            }
            if (new_line)
            {
                Console.WriteLine("");
            }
        }
        public static object drop_down_object(string prompt,Dictionary<string,object> items, string input_prompt = ">")
        {

            /* makes a drop down menu from a dict of choices

             returns: a value from the dict passed into it,
             there is no way to exit this menu loop without a valid selection.

             if you want to add an exit clause, than make an exit value 
             in your dict to be returned and then handle that return value
             from your calling code.

             example:

             selection=drop_down(prompt,items={},input_prompt='>')
             if selection == exit_value:
                 break

             input_prompt defaults to a single '>'
             it is recommended to modify this to show how many menus
             deep a player is.

             if the input is not recognized too many times the menu 
             prompt will be re-printed to prevent the player from having to
             scroll up to read the available options.

             input will be valid if a key from the dict is typed out in upper
             or lowercase, or if the index of the menu item is input
            */

            void draw()
            {
                Console.WriteLine();
                Console.WriteLine(prompt + ":");
                foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                {
                    Console.WriteLine($"[{index+1}] {item}");
                }
            }
            draw();
            int typo = 0;
            while (true)
            {
                if (typo == 4)
                {
                    typo = 0;
                    draw();
                }
                Console.Write(input_prompt);
                var input = Console.ReadLine();
                try
                {
                    int selection = Convert.ToInt32(input) - 1;
                    foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                    {
                        if (index == selection)
                        {
                            return items[Convert.ToString(item)];
                        }
                    }
                }
                catch (FormatException)
                {
                    if(input!=null)
                    {
                        string selection = char.ToUpper(input[0]) + input.Substring(1);
                        if (items.ContainsKey(selection))
                        {
                            return items[selection];
                        }
                    }
                }
                Console.WriteLine("\nThat is not on the list.\nVerify your selection.");
                typo += 1;
            }
        }
        public static string drop_down(string prompt,Dictionary<string,string> items, string input_prompt = ">")
        {

            /* makes a drop down menu from a dict of choices

             returns: a value from the dict passed into it,
             there is no way to exit this menu loop without a valid selection.

             if you want to add an exit clause, than make an exit value 
             in your dict to be returned and then handle that return value
             from your calling code.

             example:

             selection=drop_down(prompt,items={},input_prompt='>')
             if selection == exit_value:
                 break

             input_prompt defaults to a single '>'
             it is recommended to modify this to show how many menus
             deep a player is.

             if the input is not recognized too many times the menu 
             prompt will be re-printed to prevent the player from having to
             scroll up to read the available options.

             input will be valid if a key from the dict is typed out in upper
             or lowercase, or if the index of the menu item is input
            */

            void draw()
            {
                Console.WriteLine();
                Console.WriteLine(prompt + ":");
                foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                {
                    Console.WriteLine($"[{index+1}] {item}");
                }
            }
            draw();
            int typo = 0;
            while (true)
            {
                if (typo == 4)
                {
                    typo = 0;
                    draw();
                }
                Console.Write(input_prompt);
                var input = Console.ReadLine();
                try
                {
                    int selection = Convert.ToInt32(input) - 1;
                    foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                    {
                        if (index == selection)
                        {
                            return items[item];
                        }
                    }
                }
                catch (FormatException)
                {
                    if(input!=null)
                    {
                        string selection = char.ToUpper(input[0]) + input.Substring(1);
                        if (items.ContainsKey(selection))
                        {
                            return items[selection];
                        }
                    }
                }
                Console.WriteLine("\nThat is not on the list.\nVerify your selection.");
                typo += 1;
            }
        }
        public static void clear_console()
        {
        // removes all text from the console preventing scrolling up
            Console.Clear();
            Console.WriteLine("\n\n");
        }
        public static void jump(int amount = 1)
        {
        /* prints new lines

            new lines are blank spaces between the last thing printed and the next.
            enter an amount of lines to skip. defaults to 1
        */
            for(int i = 0; i < amount; i++)
            {
                Console.WriteLine("\n");
            }
        }
        public static string carrot_menu(string prompt,Dictionary<string,string> items, string input_prompt = ">")
        {
            jump();
            Console.CursorVisible = false;
            int carrot = 0;
            int fps = 60;
            Console.WriteLine(prompt + ":");
            int cursorResetLeft  = Console.CursorLeft;
            int cursorResetTop  = Console.CursorTop;
            void draw()
            {
                Console.SetCursorPosition(cursorResetLeft,cursorResetTop);
                foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                {
                    for (int i = 0; i < items.Count+10; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorResetLeft,Console.CursorTop);
                    if (carrot==index)
                    {
                        Console.WriteLine($">[{index+1}] {item}");
                    }
                    else
                    {
                    Console.WriteLine($"[{index+1}] {item}");
                    }
                }
            }
            string getItem()
            {
                if (Console.KeyAvailable)
                { var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (carrot>0)
                            {
                                carrot-=1;
                                draw();
                            }
                            return "nada";
                        case ConsoleKey.DownArrow:
                            if (carrot<items.Count-1)
                            {
                                carrot+=1;
                                draw();
                            }
                            return "nada";
                        case ConsoleKey.Enter:
                            foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                            {
                                if (carrot==index)
                                {
                                    return item;
                                }
                            }
                            return "nada";
                    }
                }
                return "nada";
            }
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            void deltaTime()
            {
                time2 = DateTime.Now;
                float deltaTime = (time2.Ticks - time1.Ticks)/10000;//Ticks are 1/10,000 of a millisecond
                if (deltaTime<fps && deltaTime>0)
                {
                    Thread.Sleep((Convert.ToInt32(fps-deltaTime)));
                }
                time1 = time2;
            }
            draw();
            while(true)
            {
                deltaTime();
                string selection = getItem();
                if (selection!="nada")
                {
                    Console.CursorVisible = true;
                    return selection;
                }
            }

        }
    }
}