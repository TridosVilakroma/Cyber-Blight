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
    using CyberBlight.input_device;

    public static class GameStruct
    {
        public static void Main()
        {
            engine.clear_console();
            // Console.WriteLine("hello world, this is a test!");
            // while(true){ConsoleMouse.listen();}
            Console.Title ="Cyber blight";
            effects.glitch(150, ConsoleColor.Black, ConsoleColor.DarkGreen);
            engine.slow_type("\n\n-Welcome to the world of Cyber Blight-", 75, false);
            Thread.Sleep(1000);
            engine.jump(1);
            engine.flushKeyboard();
            string profile = engine.mouse_menu("Select your file",DataIO.existing_files(@"save_data\saves"));
            if (profile == "New Game")
            {
                NewGame();
            }
            else
            {
                ContinueGame(profile);
            }
            while (true)
            {
                GameLoop();
            }
            
        }

        public static void NewGame()
        {
            var player_name = engine.getInput("Enter your name");
            if (player_name!=null)
            {
                Player.name=player_name;
                DataIO.save(Player.name, player_name);
            }
            engine.clear_console();
            Text.prologue();
            Thread.Sleep(2000);
            engine.jump(3);
            engine.slow_type("You sit down at your console");
            Thread.Sleep(2000);
            engine.jump(2);
            engine.flushKeyboard();
        }

        public static void ContinueGame(string profile)
        {
            Player.name=profile;
            object data = DataIO.load(Player.name);
            Player.loadPath=Player.name;
            //load game func using data needed here
            engine.clear_console();
        }

        public static void GameLoop()
        {
            StateMachine.focus_switch();
            StateMachine.aux_state();
        }
    }
}