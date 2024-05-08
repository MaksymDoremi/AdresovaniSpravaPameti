namespace Maturita
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * C# funguje s Stackem a Heapem
             * Stack - LIFO, last in first out, tady se ukladaji value data types
             * což jsou primitivní typy jako int, bool, double, float, long, struct...
             * Každé vlákno má svůj stack, má v něm svoje data(viz Alfa 1 jak jsme struglovali)
             * 
             * Heap - je dynamická paměť, data nejsou uspořádana, je pouze jedná na celý program.
             * Všechny mají přístup na něj, pokud data nebudem blokovat lock, private a td..
             * 
             * int a = 10; vytvoří se na stacku hodnotový typ
             * int b = a; hodnota a se překopíruje do b, žádne reference tady nebudou
             * 
             * Person p = new Person("Karel","Novak"); na stacku proměnná p bude mít adresu která
             * ukazuje na objekt v heapu   0x123
             * 
             * Person p2 = p; p2 dostane stejný odkaz co i p, tedy oboje odkazují na STEJNÝ objekt na heapu 0x123
             * p2.Jmeno = "Nový jméno" zasáhne objekt 0x123
             * 
             * tedy p a p2 ukazují na STEJNÝ objekt a změny na jednom uvidíme i na druhém
             * 
             * když udělám p = null; tak Karel Novák 0x123 furt bude v heapu
             * když dokonce udělám p2 = null; tak Karel Novák 0x123 bude smazán Garbage Collectorem
             * 
             */


            int number = 100;
            int number2 = number;

            Console.WriteLine("int number = 100;\nint number2 = number;");
            Console.WriteLine($"number is {number}");
            Console.WriteLine($"number2 is {number2}");

            number = 59;
            Console.WriteLine("number = 59;");
            Console.WriteLine($"number is {number}");
            Console.WriteLine($"number2 is {number2}");


            Console.WriteLine();

            ReportClass reportClass = new ReportClass() { Title = "Class report", Pages = 1000 };
            ReportClass reportClassCopy = reportClass;

            Console.WriteLine("ReportClass reportClass = instance;\nReportClass reportClassCopy = reportClass;");
            Console.WriteLine(reportClass.Display());
            Console.WriteLine(reportClassCopy.Display());
            Console.WriteLine();
            reportClass.Pages = 9999;
            Console.WriteLine("reportClass.Pages = 9999;");
            Console.WriteLine(reportClass.Display());
            Console.WriteLine(reportClassCopy.Display());
            Console.WriteLine();
            Console.WriteLine("Process => number = 333; reportClass.Title = \"Processed title\"");
            Process(number, reportClass);
            Console.WriteLine($"number is {number}");
            Console.WriteLine(reportClass.Display());
            Console.WriteLine(reportClassCopy.Display());

            Console.WriteLine();

            ReportStruct reportStruct = new ReportStruct() { Title = "Struct report", Pages = 1000 };
            ReportStruct reportStructCopy = reportStruct;

            Console.WriteLine("ReportStruct reportStruct = instance;\nReportStruct reportStructCopy = reportStruct;");
            Console.WriteLine(reportStruct.Display());
            Console.WriteLine(reportStructCopy.Display());
            Console.WriteLine();
            reportStruct.Pages = 9999;
            Console.WriteLine("reportStruct.Pages = 9999;");
            Console.WriteLine(reportStruct.Display());
            Console.WriteLine(reportStructCopy.Display());
            Console.WriteLine();
            Console.WriteLine("Process => number = 333; reportStruct.Title = \"Processed title\"");
            Process(number, reportStruct);
            Console.WriteLine($"number is {number}");
            Console.WriteLine(reportStruct.Display());
            Console.WriteLine(reportStructCopy.Display());
            Console.WriteLine();
            Console.WriteLine("Process => ref number = 333; ref reportStruct.Title = \"Processed title\"");
            Process(ref number, ref reportStruct);
            Console.WriteLine($"Processed number={number}");
            Console.WriteLine(reportStruct.Display());
            Console.WriteLine(reportStructCopy.Display());

        }


        public static void Process(int num, ReportClass report)
        {
            num = 333;
            report.Title = "Processed title";
        }

        public static void Process(int num, ReportStruct report)
        {
            num = 333;
            report.Title = "Processed title";
        }

        public static void Process(ref int num, ref ReportStruct report)
        {
            num = 333;
            report.Title = "Processed title";
        }

    }
    public class ReportClass
    {
        public string Title { get; set; }
        public int Pages { get; set; }

        public string Display()
        {
            return $"Class report Title={Title} Pages={Pages}";
        }
    }
    public struct ReportStruct
    {
        public string Title { get; set; }
        public int Pages { get; set; }

        public string Display()
        {
            return $"Struct report Title={Title} Pages={Pages}";
        }
    }
}