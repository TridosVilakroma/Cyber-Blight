namespace CyberBlight.logic_dispatch
{
    using text;
    using character_sheet;
    using console;
    //using inventory;
    using engine;

    public static class focusSwitch
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
        {
        }
    }
}