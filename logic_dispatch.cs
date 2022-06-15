namespace CyberBlight.logic_dispatch
{
    using text;
    using character_sheet;
    using console;
    //using inventory;
    using engine;

    public static class StateMachine
    {
        public static void focus_switch()
        {
            if (Logic.focus == "console_main_menu")
            {engine.clear_console();Terminal.main_menu();}
            else if (Logic.focus == "console_terminal")
            {engine.clear_console();Terminal.terminal();}
            else if (Logic.focus == "console_network")
            {engine.clear_console();Terminal.network();}
            else if (Logic.focus == "console_email")
            {engine.clear_console();Terminal.email();}
            else if (Logic.focus == "console_settings")
            {engine.clear_console();Terminal.settings();}
            else if (Logic.focus == "console_profile")
            {engine.clear_console();Terminal.profile();}
        }
        
        public static void aux_state()
        {/*this may not be necessary.
            this is used for keeping something in the games memory that you want to run every loop
            untill a certain condition stops it e.g. a status condition like poison.
            
            it will check a list every loop and perform all functions listed(even if they are 
            duplicated it will only call them once.)
            
            in practice its similar to the focus switch, except it can have multiple targets every loop*/
        }
    }
}