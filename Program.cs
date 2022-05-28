namespace Program.Main
{

    using System;

    using CyberBlight.engine;
    using CyberBlight.data_IO;
    using text;
    using character_sheet;
    using console;
    using inventory;
    using logic_dispatch;

    public static class GameLoop
    {
        public static void Main()
        {
            engine.clear_console();
            engine.slow_type("\n\n-Welcome to the world of Cyber Blight-\n", 100);
            Thread.Sleep(1000);
            string profile = engine.drop_down("Select your file",DataIO.existing_files(@"save_data\saves"));
        }
            data_IO.save(player, player_name);
            engine.clear_console();
            text.prologue();
            Thread.Sleep(2000);
            engine.jump(3);
            engine.slow_type("You sit down at your console");
            engine.jump(2);
            engine.clear_console();
            logic_dispatch.focus_switch();
            logic_dispatch.aux_state();

        public static object profile = engine.drop_down("Select your file", data_IO.existing_files(@"save_data\saves"));

        public static object player_name = input("    Enter your name:\n    >>");

        public static object player = character_sheet.Player(player_name);

        public static object save_data = data_IO.load(profile);
    }
}