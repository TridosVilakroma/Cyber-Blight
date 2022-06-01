namespace CyberBlight.text
{
    using CyberBlight.engine;

    public static class Text
    {

        public static void prologue()
        {
            engine.slow_type("The world has grown in population and technology.\n", 100);
            Thread.Sleep(1000);
            engine.slow_type(@"Computers created advanced algorithms that grew 
    in complexity exponentially for centuries.", 100);
            Thread.Sleep(1000);
            engine.slow_type(@"Long ago civilization moved into an era called The Nexus.
    Where the physical world is being merged into the cyber world.", 100);
            Thread.Sleep(1000);
            engine.slow_type(@"World leaders praise the machines, attributing peace and prosperity to them. 
    However there are factions who claim that true humanity was given up in exchange for 
    any percieved benefits the machines have brought.", 150);
            Thread.Sleep(1000);
            engine.slow_type(@"Hacker groups have formed in response to this cyber blight.
    They must remain cloaked and agile to avoid detection. ", 150);
            Thread.Sleep(2000);
            engine.slow_type("They are always recruting", new_line: false);
            engine.slow_type(".", new_line: false);
            Thread.Sleep(500);
            engine.slow_type(".", new_line: false);
            Thread.Sleep(500);
            engine.slow_type(".", new_line: false);
            Thread.Sleep(500);
            engine.slow_type(".", new_line: false);
        }
    }
}