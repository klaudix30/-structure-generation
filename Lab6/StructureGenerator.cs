using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab6
{
    class StructureGenerator
    {
        Dictionary<string, List<string>> twoLetter;
        Dictionary<string, List<string>> threeLetter;
        List<string> listOfSurname;
        List<Double> times;
        Encoding enc = Encoding.GetEncoding("Windows-1250");

        public StructureGenerator()
        {
            twoLetter = new Dictionary<string, List<string>>();
            threeLetter = new Dictionary<string, List<string>>();
            listOfSurname = new List<string>();
            times = new List<Double>();

        }
        int i = 0;
        public void loadSurname()
        {
            string line;
            StreamReader file = new StreamReader("../../Data/nazwiska.txt", enc);
            while (i < 10)
            {
                i++;
                while ((line = file.ReadLine()) != null)
                {
                    var surname1 = line.Split(' ', '\t');
                    listOfSurname.Add(surname1[1]);
                }
            }


        }
        public void generateStruct(Dictionary<string, List<string>> structure, int length)
        {

            foreach (string surname in listOfSurname)
            {
                if (surname.Length > length)
                {
                    String key = surname.Substring(0, length);
                    List<string> value;
                    if (!structure.TryGetValue(key, out value))
                    {
                        value = new List<string>();
                        structure[key] = value;
                    }
                    value.Add(surname);
                }
            }

        }

        public List<Double> checkTime()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            loadSurname();
            watch.Stop();
            times.Add(watch.Elapsed.TotalSeconds);


            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            generateStruct(twoLetter, 2);
            watch1.Stop();
            times.Add(watch1.Elapsed.TotalSeconds);


            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            generateStruct(threeLetter, 3);
            watch2.Stop();
            times.Add(watch2.Elapsed.TotalSeconds);
            return times;


        }
        public List<string> getListOfSurname()
        {
            return listOfSurname;
        }
    }
}
