namespace CyberBlight.console
{
    using System.Collections.Generic;
    using CyberBlight.engine;
    using CyberBlight.character_sheet;
    using CyberBlight.data_IO;


    public class Terminal
    {

        public Terminal(){}
        public static void main_menu()
        {
            string action = engine.mouse_menu("Console", new Dictionary<string, string>
            {
                {
                    "Terminal",
                    "console_terminal"},
                {
                    "Network",
                    "console_network"},
                {
                    "Email",
                    "console_email"},
                {
                    "Settings",
                    "console_settings"}});
            Logic.focus=action;
        }
        
        public static void terminal()
        {
            string action = engine.drop_down_terminal("Terminal", new Dictionary<string, string>
            {
                {
                    "Search",
                    "console_terminal"},
                {
                    "DDOS",
                    "console_network"},
                {
                    "Ping",
                    "console_email"},
                {
                    "IP Flush",
                    "console_settings"}});
            Logic.focus = action;
        }
        
        public static void network()
        {
            Logic.focus="console_main_menu";
        }
        
        public static void email()
        {
            engine.clear_console();
            string action = engine.drop_down("E-mail", new Dictionary<string, string>
            {
                {
                    "Inbox",
                    "console_email_inbox"},
                {
                    "Close",
                    "console_main_menu"}}, ">>");
            Logic.focus = action;
        }
        
        public static void inbox()
        {
            Logic.focus="console_main_menu";
        }
        
        public static void settings()
        {
            engine.clear_console();
            string action = engine.mouse_menu("Settings", new Dictionary<string, string>
            {
                {
                    "Profile",
                    "console_profile"},
                {
                    "Text Speed",
                    "console_text_speed"},
                {
                    "System Colors",
                    "console_color"},
                {
                    "Save Game",
                    "console_save"},
                {
                    "Close",
                    "console_main_menu"}},">>");
            if (action == "console_save")
            {
                if (Player.loadPath=="nada")
                {
                    DataIO.save(Player.name, Player.name);
                }
                else
                {
                    DataIO.save(Player.name, Player.loadPath);
                }
                
                action="console_settings";
            }
            Logic.focus=action;
        }
        public static void profile()
        {
            engine.clear_console();
            string action = engine.mouse_menu("Console", new Dictionary<string, string>
            {
                {
                    "User Name",
                    "console_user_name"},
                {
                    "Close",
                    "console_settings"}
                }, ">>>");
            if (action == "console_user_name")
            {
                Player.name=engine.getInput("Enter new user name",">>>>");
                action = "console_profile";
            }
            Logic.focus=action;
        }
    }
}