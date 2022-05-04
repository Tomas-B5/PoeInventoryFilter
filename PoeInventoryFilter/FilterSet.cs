using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoeInventoryFilter
{
    //A set of ModFilters for a specific type e.g. Rings/Amulets etc.
    class FilterSet
    {
        double _minweight;
        List<ModFilter> _modfilters = new List<ModFilter>();

        public FilterSet(string path)
        {
            string[] lines = File.ReadAllLines(path);

            string minweightStr = lines[0].Split('=')[1];
            _minweight = Convert.ToDouble(minweightStr);

            for(int i = 1; i < lines.Length;i++)
            {
                string[] splitline = lines[i].Split(';');

                string text = splitline[0];
                DelimType delim = GetDelimType(splitline[1]);
                int color = Convert.ToInt32(splitline[2], 16);
                double weight = Convert.ToDouble(splitline[3]);

                ModFilter filter = new ModFilter(text, color, weight, delim);

                _modfilters.Add(filter);
            }
        }

        private DelimType GetDelimType(string str)
        {
            DelimType result = DelimType.none;

            if (str == "+")
                result = DelimType.plus;
            else if (str == "+%")
                result = DelimType.pluspercent;
            else if (str == "%")
                result = DelimType.percent;
            else if (str == "to")
                result = DelimType.to;

            return result;
        }
    }
}
