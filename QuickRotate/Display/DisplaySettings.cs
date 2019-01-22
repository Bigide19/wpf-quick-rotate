﻿namespace Display
{
    struct DisplaySettings
    {
        public int Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Orientation Orientation { get; set; }
        public int BitCount { get; set; }
        public int Frequency { get; set; }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture,
                "{0} by {1}, {2}, {3} Bit, {4} Hertz",
                Width, Height, (int)Orientation, BitCount, Frequency);
        }
    }
}