using System;
using System.Collections.Generic;
using System.Text;



namespace PoeInventoryFilter
{
    enum DelimType { none, plus, percent, pluspercent, to };

    class ModFilter
    {
        string _text;
        int _color;
        DelimType _delimType;
        double _modWeight;
		public ModFilter(string text, int color, double modweight, DelimType delimtype)
		{
			_text = text;
			_color = color;
			_modWeight = modweight;
			_delimType = delimtype;
		}
		ModFilter(string text, int color)
		{
			_text = text;
			_color = color;
			_modWeight = 0;
		}
	}
}
