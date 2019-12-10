using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day08
{
    public class ImageRenderer
    {
        public static int transparent = 2;

        List<int[]> layers;

        int width;

        int height;

        public List<int[]> Lines { get; set; } = new List<int[]>();

        public ImageRenderer(List<int[]> layers, int width, int height)
        {
            this.layers = layers;
            this.width = width;
            this.height = height;
        }

        public void Render()
        {
            int?[] image = new int?[width * height];

            foreach (var layer in layers)
            {
                ApplyLayer(image, layer);
            }

            Lines = ParseLines(image.Select(x => x.Value).ToArray()).ToList();
        }

        public void PrintLines()
        {
            foreach (var line in Lines)
            {
                Console.WriteLine(RenderLine(line));
            }
        }

        IEnumerable<int[]> ParseLines(int[] image)
        {
            for (int i = 0; i < height; i++)
            {
                int lineStart = i * width;
                int lineEnd = lineStart + width;

                yield return image[lineStart..lineEnd];
            }
        }

        void ApplyLayer(int?[] image, int[] layer)
        {
            // Overwrite each pixel in the image array, unless the source pixel is transparent.
            for (int i = 0; i < layer.Length; i++)
            {
                if(layer[i] == transparent)
                {
                    continue;
                }

                image[i] ??= layer[i];
            }
        }

        string RenderLine(int[] line)
        {
            string output = "";
            for (int i = 0; i < line.Length; i++)
            {
                output += line[i];
            }

            return output;
        }
    }
}
