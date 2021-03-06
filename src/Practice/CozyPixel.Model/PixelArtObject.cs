﻿using System.Drawing;

namespace CozyPixel.Model
{
    // 单个像素画model
    public class PixelArtObject
    {
        public const int DefaultPixelWidth = 20;

        public const int DefaultGridWidth = 2;

        public Bitmap data { get; set; }

        public bool ShowGrid { get; set; } = true;

        public int GridWidth { get; set; } = DefaultGridWidth;

        public int PixelWidth { get; set; } = DefaultPixelWidth;

        public int Width { get { return data != null ? data.Width : 0; } }

        public int Height { get { return data != null ? data.Height : 0; } }

        public Color GridColor { get; set; } = Color.Black;

        public Color BackColor { get; set; } = Color.White;

        public void Resize(int width, int height)
        {
            data = new Bitmap(width, height);
        }

        public void SetPixel(int x, int y, Color color)
        {
            data.SetPixel(x, y, color);
        }

        public Color GetPixel(int x, int y)
        {
            return data.GetPixel(x, y);
        }

        public void Save(string filename)
        {
            data.Save(filename);
        }
    }
}
