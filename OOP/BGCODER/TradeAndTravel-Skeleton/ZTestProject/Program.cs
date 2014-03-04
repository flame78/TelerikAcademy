using System;

namespace TestProject
{
    

    public class AdvancedStringReader : System.IO.TextReader
    {
        private System.IO.StringReader p;
        private bool showOnConsole;
        public AdvancedStringReader(string p,bool showOnConsole)
        {
            this.p = new System.IO.StringReader(p);
            this.showOnConsole = showOnConsole;
        }
        public override string ReadLine()
        {
            string line = p.ReadLine();
            if (showOnConsole==true) Console.WriteLine("==>" + line);
            return line;
        }
    }

  
    class Program
    {
        static bool showOnConsole = false;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            var result = new System.IO.StringWriter();
            result.WriteLine(
@"empty
100
theArmor
theArmor
95
empty
100
empty
Axe
MineClothes
gatheredAtBlackmarsh
gatheredAtCidna
Axe
MineClothes
gatheredAtBlackmarsh
gatheredAtCidna
craftedWeapon
craftedArmor");

            var input = new AdvancedStringReader(
@"create location town whiterun
create location town riften
create location mine cidna
create location forest blackmarsh
create item armor theArmor whiterun
create item weapon Axe blackmarsh
create item armor MineClothes blackmarsh
create traveller pesho whiterun
create merchant kiro whiterun
pesho inventory
pesho money
pesho pickup
pesho inventory
pesho travel riften
pesho drop
create shopkeeper joro riften
joro pickup
joro inventory
pesho buy theArmor joro
pesho money
pesho sell theArmor joro
pesho inventory
kiro travel riften
kiro buy theArmor joro
pesho buy theArmor kiro
kiro money
kiro travel blackmarsh
kiro gather x
kiro inventory
kiro pickup
kiro gather gatheredAtBlackmarsh 
kiro travel cidna
kiro gather gatheredAtCidna
kiro inventory
kiro craft weapon craftedWeapon
kiro craft armor craftedArmor
kiro inventory
end
",showOnConsole);
            Console.SetIn(input);
            using (input)
            {
                var output = new System.IO.StringWriter();

            if (showOnConsole==false)   Console.SetOut(output);

            using (output)
            {
                TradeAndTravel.Program.Main(null);

                if (showOnConsole == false)
                {
                    System.Windows.Forms.Clipboard.SetText(output.ToString());
                    if (output.ToString() != result.ToString()) throw new Exception("To Bad");
                }
            }
            }

        }
    }
}


/*
  public class AdvancedStringWriter : System.IO.TextWriter
    {
        private System.IO.StringWriter p;
        public AdvancedStringWriter()
        { this.p = new System.IO.StringWriter(); }


        public override void WriteLine(string obj)
        {
            if (obj.Substring(0,3) != "==>") this.p.WriteLine(obj);
            var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine(obj);
            Console.SetOut(this);
        }

        public override void WriteLine( object arg)
        {
            this.p.WriteLine( arg);
            var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine( arg);
            Console.SetOut(this);
        }
        public override string ToString()
        {
            return this.p.ToString();
        }

        public override System.Text.Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
    }
*/