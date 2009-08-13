using System;
using System.Globalization;
using System.Threading;

namespace Now
{
    class Program
    {
        static int Main(string[] args)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            var now = DateTime.Now;

            if (args.Length == 0 || args.Length > 2)
            {
                Console.WriteLine("Usage: now [format] <culture>");
                Console.WriteLine();
                Console.WriteLine("Now 1.0. Copyright (c) 2008 Richard Hubers");
                Console.WriteLine("http://www.codeplex.com/now");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("  now {0,-30} {1}", "D en-US", now.ToString("D", new CultureInfo("en-US")));
                Console.WriteLine("  now {0,-30} {1}", "D en-GB", now.ToString("D", new CultureInfo("en-GB")));
                Console.WriteLine("  now {0,-30} {1}", "D nl-NL", now.ToString("D", new CultureInfo("nl-NL")));

                foreach (var format in new[] {"d", "dd", "dddd", "F", "M", "MM", "MMMM", "r", "T", "u", "U", "H:mm:ss.fff", "yyyy-MM-dd (HH:mm:ss)"})
                {
                    var value = now.ToString(format);
                    var quote = format.Contains(" ") ? "\"" : string.Empty;
                    Console.WriteLine("  now {0,-30} {1}", quote + format + quote, value);
                }
                return -1;
            }

            try
            {
                if (args.Length == 2)
                {
                    ci = new CultureInfo(args[1]);
                }
                Console.Write(now.ToString(args[0], ci));
                return 0;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid culture '{0}'.", args[1]);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid culture '{0}'.", args[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format '{0}'.", args[0]);
            }
            return 1;
        }
    }
}