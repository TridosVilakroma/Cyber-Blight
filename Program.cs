namespace Program.Main
{

    using System;

    using CyberBlight.engine;
    using CyberBlight.data_IO;
    using CyberBlight.console;
    using CyberBlight.text;
    using CyberBlight.character_sheet;
    // using inventory;
    // using logic_dispatch;

    public static class GameStruct
    {
        public static void Main()
        {
            engine.clear_console();
            engine.slow_type("\n\n-Welcome to the world of Cyber Blight-\n", 100);
            Thread.Sleep(1000);
            string profile = engine.drop_down_string("Select your file",DataIO.existing_files(@"save_data\saves"));
            if (profile == "New Game")
            {
                NewGame();
            }
            else
            {
                //var save_data = DataIO.load(profile);
                ContinueGame();
            }
            GameLoop();
        }

        public static void NewGame()
        {
            Console.WriteLine("    Enter your name:\n    >>");
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
            logic_dispatch.focus_switch();
            logic_dispatch.aux_state();
        }
    }
}