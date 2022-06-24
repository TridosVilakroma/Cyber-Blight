namespace CyberBlight.engine 
{

    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Threading;
    using character_sheet;
    using CyberBlight.input_device;

    public class Logic
    {
        public static string focus = "console_main_menu";
    }


    public class engine
    {
        // these functions should be used throughout the project to automate
        // repetetive or complex tasks.
        // this is the 'engine' of our game.

        public static int align_left_x(string _text)
        {
            return Console.WindowWidth/2-_text.Length;
        }
        public static void center_text(string _text,int center=-1,bool newLine=true)
        {
            /* By default this will center the text that is passed to it.

            If you are trying to align text with previous calls to center_text() then you
            should pass in a center value.
            (use align_left_x() on the first line you want to set as the base "left",
            then use the return value as the "center" argument passed to center_text()
            for all strings, including the first)

            newLine is a bool, fairly obvious.
            true will use Console.WriteLine()
            false will use Console.Write()
            */

            if (center==-1)
            {
                Console.SetCursorPosition(Console.WindowWidth/2-_text.Length/2, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(center, Console.CursorTop);
            }
            if (newLine)
            {
                Console.WriteLine(_text);
            }
            else
            {
                Console.Write(_text);
            }
        }
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
                Console.ReadLine();
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
        public static string mouse_menu(string prompt,Dictionary<string,string> items, string input_prompt = ">")
        {
            jump();
            Console.CursorVisible = false;
            draw();
            int cursorResetLeft  = Console.CursorLeft;
            int cursorResetTop  = Console.CursorTop;
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            void draw()
            {
                Console.WriteLine();
                int _center = align_left_x(prompt + ":");
                center_text(prompt + ":",_center);
                foreach (var (item, index) in items.Keys.ToArray().Select((item, index) => ( item, index )))
                {
                    center_text($"[{index+1}] {item}",_center);
                }
            }
            while(true)
            {
                string selection = ConsoleMouse.getOption();
                if (selection!="nada")
                {
                    foreach(var item in items.Keys)
                    {
                        if (item.Contains(selection))
                        {
                            Console.CursorVisible = true;
                            return items[item];
                        }
                    }
                }
            }

        }
        public static string drop_down_terminal(string prompt,Dictionary<string,string> items, string input_prompt = ">")
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

                Console.WriteLine($@"$~/user/{Player.name}/{prompt}".ToLower());
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
                Console.ReadLine();
                typo += 1;
            }
        }
        public static string getInput(string prompt,string input_prompt = ">>")
        {
            /* getInput acts like a secondary menu to supplement a primary
                menu. It will return any string the player enters.

                Useful when asking a player to name something.
                Because anything can be input, this is not suitable for
                controlling much more than that.

                Be aware that if the player hits enter without pressing any
                other keys, an empty string will be returned, not null
            */
            Console.Write("    "+prompt+":\n    "+input_prompt);
            var input = Console.ReadLine();
            if (input!=null)
            {
                return input;
            }
            return "";
        }
        public static void flushKeyboard()
        {
            /* keyboard inputs are added to a buffer, and then handled sequentially.
                Even during blocking code the buffer will fill up, and the inputs
                will be passed to the next available method (usually asking for player input)
                causing unwanted behavior.

                This function allows the buffer to be emptied.
                Use this before most methods requesting input.
            */
            while (Console.KeyAvailable == true)
            {
                Console.ReadKey(true);
            }
        }
         public static string hack_menu(string prompt,Dictionary<string,string> items, string input_prompt = ">",string helperText="nada")
        {

            /* prompts player to type commands.

             the helper text will be written to screen to give the player 
             an idea of what they should try typing;
             this is important as the dict will not be printed for them to read.

             returns: a value from the dict passed into it,
             there is no way to exit this menu loop without a valid selection.

             if you want to add an exit clause, than make an exit value 
             in your dict to be returned and then handle that return value
             from your calling code.

             example:

             selection=hack_menu(prompt,items={},input_prompt='>',helperText="nada")
             if selection == exit_value:
                 break

             input_prompt defaults to nothing.
             it is used to keep menus hot swappable.
             not in use for this menu.

             prompt:
             you should pass in the "directory path" the player is in.

             if the input is not recognized the prompt will be rewritten,
             however after too many times the console will be cleared 
             and the menu prompt will be re-printed to prevent the player from having to
             scroll up to read the available options.

             input will be valid if a key from the dict is typed out in upper
             or lowercase, or if the index of the menu item is input
            */

            void draw()
            {
                clear_console();
                if (helperText!="nada")
                {
                Console.WriteLine($"[{helperText}]");
                }
                Console.WriteLine();
                Console.Write(prompt + input_prompt);
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
                catch(Exception e)
                {
                    if (e is FormatException)
                    {
                        if(!String.IsNullOrEmpty(input))
                        {
                            string selection = char.ToUpper(input[0]) + input.Substring(1);
                            if (items.ContainsKey(selection))
                            {
                                return items[selection];
                            }
                        }
                    }
                    else if (e is not IndexOutOfRangeException)
                    {
                        throw;
                    }
                    
                }
                Console.WriteLine("\nCommand not recognized.\nType Close to exit.\n");
                Console.Write(prompt + "/");
                typo += 1;
            }
        }
    }


    public class effects {


        // Adds a glitch animation with 1s and 0s
        // Alternating between background and text color
        public static void glitch(int loopAmt, System.ConsoleColor color1, System.ConsoleColor color2)
        {
            System.ConsoleColor bgColor = Console.BackgroundColor;
            System.ConsoleColor txtColor = Console.ForegroundColor;
            Random rand = new Random();
            for (int i = 0; i < loopAmt; i++)
            {

                 if (i % 2 == 0)
                {
                    Console.BackgroundColor = color1;
                    Console.ForegroundColor = color2;
                } else 
                {
                    Console.BackgroundColor = color2;
                    Console.ForegroundColor = color1;
                }

                for (int j = 1; j <= 7; j++)
                {
                    for (int s = 1; s <= 8; s++)
                    {
                        int randomColor = rand.Next(10);
                        int n = rand.Next(2);
                        Console.Write(n);
                    }
                    if (j != rand.Next(10) )
                    {
                        Console.Write(" ");
                    }
                }
            }
            
            Console.ForegroundColor = txtColor;
            Console.BackgroundColor = bgColor;
            Console.Write(" ");
            Console.Clear();
        }

    }







}