namespace CalendarSystem.ConsoleClient
{
    using System;

    internal class program
    {
        internal static void Main()
        {
            var em = new EM();
            var proc = new Niki(em);

            while (true)
            {
                var ct = Console.ReadLine();
                if (ct == "End" || ct == null)
                {
                    goto end;
                }

                try
                {
                    // The sequence of commands is finished
                    Console.WriteLine(proc.ProcessCommand(Command.Parse(ct)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            end:
            {
            }
        }
    }
}





