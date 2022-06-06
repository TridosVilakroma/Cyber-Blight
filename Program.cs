namespace Program.Main
{

    using System;

    using CyberBlight.engine;
    using CyberBlight.data_IO;
    //using CyberBlight.console;
    using CyberBlight.text;
    using CyberBlight.character_sheet;
    // using inventory;
    using CyberBlight.logic_dispatch;

    public static class GameStruct
    {
        public static void Main()
        {
            engine.clear_console();
            effects.glitch(150, ConsoleColor.Black, ConsoleColor.DarkGreen);
            engine.slow_type("\n\n-Welcome to the world of Cyber Blight-", 75, false);
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();
            string profile = engine.carrot_menu("Select your file",DataIO.existing_files(@"save_data\saves"));
            if (profile == "New Game")
            {
                NewGame();
            }
            else
            {
                //var save_data = DataIO.load(profile); this should return the data, then a seperate
                //function should initialize the game with that data
                ContinueGame();
            }
            GameLoop();
        }

        public static void NewGame()
        {
            Console.Write("    Enter your name:\n    >>");
            var player_name = Console.ReadLine();
            if (player_name!=null)
            {
            Player.name=player_name;
            }
            //DataIO.save(player, player_name);
            engine.clear_console();
            Text.prologue();
            Thread.Sleep(2000);
            engine.jump(3);
            engine.slow_type("You sit down at your console");
            Thread.Sleep(2000);
            engine.jump(2);
        }

        public static void ContinueGame()
        {
            //load game func needed here
            engine.clear_console();
        }

        public static void GameLoop()
        {
            StateMachine.focus_switch();
            StateMachine.aux_state();
            engine.clear_console();
            GameLoop();
        }
    }
}