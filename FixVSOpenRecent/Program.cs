using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using QuickType;
using System.Xml.XPath;
using System.Collections.Generic;

namespace RecUsedEdit
{
    class Program
    {
        static Func<FileEntry, bool> NotInPath(string s) => v => !v.Key.StartsWith(s, StringComparison.InvariantCultureIgnoreCase);
        static bool IsFav(FileEntry v) => v.Value.IsFavorite.GetValueOrDefault();
        static Func<FileEntry, bool> FavOrNewerThan(int n) =>
            v => IsFav(v) || (v.Value.LastAccessed.HasValue && v.Value.LastAccessed.Value > (DateTime.Now - TimeSpan.FromDays(n)));

        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"c:\Users\thomas\AppData\Local\Microsoft\VisualStudio\16.0_19f5538c\ApplicationPrivateSettings.xml");
            XElement recentNode = doc.XPathSelectElement("/content/indexed/collection[@name='CodeContainers.Offline']/value");
            List<FileEntry> recentData = FileEntry.FromJson(recentNode.Value);
            Console.WriteLine(recentData.Count);
            var relevantData = recentData
                .Where(NotInPath("c:\\oop"))
                .Where(NotInPath("c:\\2021"))
                .Where(NotInPath("C:\\Users\\thomas\\Downloads"))
                .Where(FavOrNewerThan(180))
                .ToList();
            foreach (FileEntry item in relevantData)
            {
                Console.WriteLine(item.Value.LastAccessed);
                Console.WriteLine(item.Key);
            }

            Console.WriteLine(recentData.Count);
            Console.WriteLine(relevantData.Count);

            recentNode.Value = Serialize.ToJson(relevantData);
            using FileStream output = File.Open(@"c:\Users\thomas\AppData\Local\Microsoft\VisualStudio\16.0_19f5538c\ApplicationPrivateSettings.xml", FileMode.Truncate);
            doc.Save(output);
        }
    }
}
