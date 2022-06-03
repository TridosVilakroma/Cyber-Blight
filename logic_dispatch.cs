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
            {
                Terminal.main_menu();
            } else if (Logic.focus == "console_terminal")
            {
                Terminal.terminal();
            } else if (Logic.focus == "console_network")
            {
                Terminal.network();
            } else if (Logic.focus == "console_email")
            {
                Terminal.email();
            } else if (Logic.focus == "console_settings")
            {
                Terminal.settings();
            }
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