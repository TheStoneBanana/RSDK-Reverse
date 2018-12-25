﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RSDKv5
{
    public class PaletteColour
    {

        public byte R, G, B;

        public PaletteColour(byte R = 0, byte G = 0, byte B = 0)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        internal PaletteColour(Reader reader)
        {
            this.Read(reader);
        }

        internal void Read(Reader reader)
        {
            R = reader.ReadByte();
            G = reader.ReadByte();
            B = reader.ReadByte();
        }

        internal void Write(Writer writer)
        {
            writer.Write(R);
            writer.Write(G);
            writer.Write(B);
        }
    }
}