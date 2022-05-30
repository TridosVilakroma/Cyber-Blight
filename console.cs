namespace Namespace {
    
    using System.Collections.Generic;
    
    public static class Module {
        
        public class Console {
            
            public Console() {
            }
            
            public virtual object main_menu() {
                var action = drop_down("Console", new Dictionary<object, object> {
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
                game.focus = action;
            }
            
            public virtual object terminal() {
                var action = drop_down("Terminal", new Dictionary<object, object> {
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
                game.focus = action;
            }
            
            public virtual object network() {
            }
            
            public virtual object email() {
                clear_console();
                var action = drop_down("E-mail", new Dictionary<object, object> {
                    {
                        "Inbox",
                        "console_email_inbox"},
                    {
                        "Close",
                        "console_main_menu"}}, ">>");
                game.focus = action;
            }
            
            public virtual object inbox() {
            }
            
            public virtual object settings() {
            }
        }
    }
}