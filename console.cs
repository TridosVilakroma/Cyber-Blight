namespace CyberBlight.console
{
    using System.Collections.Generic;
    using CyberBlight.engine;


    public class Terminal
    {

        public Terminal(){}
        public static void main_menu()
        {
            string action = engine.drop_down("Console", new Dictionary<string, string>
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
            string action = engine.drop_down("Terminal", new Dictionary<string, string>
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
            Logic.focus = action;
        }
        
        public static void network()
        {
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
        }
        
        public static void settings()
        {
        }
    }
}