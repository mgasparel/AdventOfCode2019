using System.Collections.Generic;

namespace AdventOfCode2019.Day08
{
    public class ImageParser
    {
        readonly int[] image;

        public ImageParser(int[] image)
        {
            this.image = image;
        }

        public List<int[]> ParseLayers(int width, int height)
        {
            var layers = new List<int[]>();

            int area = width * height;
            int numLayers = image.Length / area;

            int layerStart;
            int layerEnd;
            for (int i = 0; i < numLayers; i++)
            {
                layerStart = i * area;
                layerEnd = layerStart + area;

                layers.Add(image[layerStart..layerEnd]);
            }

            return layers;
        }
    }
}
