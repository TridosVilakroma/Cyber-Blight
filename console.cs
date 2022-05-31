namespace CyberBlight.console
{
    using System.Collections.Generic;
    using CyberBlight.engine;


    public class Terminal
    {

        public Terminal(){}
        public void main_menu()
        {
            string action = engine.drop_down_string("Console", new Dictionary<string, string>
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
        
        public void terminal()
        {
            string action = engine.drop_down_string("Terminal", new Dictionary<string, string>
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
        
        public void network()
        {
        }
        
        public void email()
        {
            engine.clear_console();
            string action = engine.drop_down_string("E-mail", new Dictionary<string, string>
            {
                {
                    "Inbox",
                    "console_email_inbox"},
                {
                    "Close",
                    "console_main_menu"}}, ">>");
            Logic.focus = action;
        }
        
        public void inbox()
        {
        }
        
        public void settings()
        {
        }
    }
}