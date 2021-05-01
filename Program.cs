using System;
using System.Globalization;

namespace lastupdated
{
    class Program
    {
        private static string RegionInfo = "en-GB";
        static void Main(string[] args)
        {
            Console.WriteLine("Processing Messages...");
            Console.WriteLine("...");

            // Run Examples
            Console.WriteLine(GenerateOutput(DateTime.Now));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddMinutes(-1)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddMinutes(-2)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddMinutes(-30)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddMinutes(-60)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddMinutes(-120)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-1)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-2)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-7)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-14)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-30)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-60)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddDays(-365)));
            Console.WriteLine(GenerateOutput(DateTime.Now.AddYears(-3)));
        }

        public static string GenerateOutput(DateTime messagetime)
        {
            Console.WriteLine("Current Date: " + (DateTime.Now.ToString("d MMM yyyy hh:mm",
                  CultureInfo.CreateSpecificCulture(RegionInfo))));
            Console.WriteLine("Message Updated Date: " + (messagetime.ToString("d MMM yyyy hh:mm",
            CultureInfo.CreateSpecificCulture(RegionInfo))));
            Console.Write("Last Updated Message: Last Updated: ");
            return TimeSince(messagetime);
        }

        public static string TimeSince(DateTime originalTime)
        {
            TimeSpan ts = DateTime.Now.Subtract(originalTime);
            DateTime now = DateTime.Now;
            return (now - originalTime) switch
            {
                { TotalMinutes: < 1 } => ResponseStructure("NA", ""),
                { TotalMinutes: < 2 } => ResponseStructure("Minute", "1"),
                { TotalHours: < 1 } => ResponseStructure("Minute", $"{ts.Minutes}"),
                { TotalHours: < 2 } => ResponseStructure("Hour", "1"),
                { TotalDays: < 1 } => ResponseStructure("Hour", $"{ts.Hours}"),
                { TotalDays: < 2 } => ResponseStructure("Day", "1"),
                { TotalDays: < 7 } => ResponseStructure("Day", $"{ts.Days}"),
                { TotalDays: < 14 } => ResponseStructure("Week", "1"),
                { TotalDays: < 30 } => ResponseStructure("Week", $"{Math.Floor(ts.TotalDays / 7)}"),
                { TotalDays: < 60 } => ResponseStructure("Month", "1"),
                { TotalDays: < 365 } => ResponseStructure("Month", $"{Math.Floor(ts.TotalDays / 30)}"),
                { TotalDays: < 730 } => ResponseStructure("Year", "1"),
                var x => ResponseStructure("Year", $"{Math.Floor(ts.TotalDays / 365)}")
            };
        }

        public static string ResponseStructure(string timereference, string timevalue)
        {
            switch (RegionInfo)
            {
                // Add further language support here for different regions if required
                case "en-US":
                case "en-GB":
                default:
                    string prefix = "";
                    string suffix = " " + timereference;
                    if (timevalue == "") return "Just Now";
                    if (timevalue != "1")
                    {
                        suffix += "s";
                    }
                    suffix += " Ago";
                    return prefix + timevalue + suffix;
            }
        }
    }
}
