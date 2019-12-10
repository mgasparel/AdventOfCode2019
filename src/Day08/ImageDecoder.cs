using System.Collections.Generic;

namespace AdventOfCode2019.Day08
{
    public class ImageDecoder
    {
        readonly int[] image;

        int width;

        int height;

        public List<int[]> Layers = new List<int[]>();

        public ImageDecoder(int[] image)
        {
            this.image = image;
        }

        public void DecodeImage(int width, int height)
        {
            this.width = width;
            this.height = height;

            int area = width * height;

            int numLayers = image.Length / area;

            int layerStart;
            int layerEnd;
            for (int i = 0; i < numLayers; i++)
            {
                layerStart = i * area;
                layerEnd = layerStart + area;

                Layers.Add(image[layerStart..layerEnd]);
            }
        }
    }
}
