using System.Globalization;
using System.Reflection.Emit;
using TextFile;

namespace Assign_2
{
    public class Program
    {
        static void Main()
        {
            TextFileReader reader = new TextFileReader("C:\\Users\\Ayxan\\Desktop\\oop\\input.txt"); //my path to input file

            List<Layer> layers = new List<Layer>();
            reader.ReadLine(out string line);
            int N = int.Parse(line);

            try
            {
                for (int i = 0; i < N; ++i)
                {
                    char[] splitChars = { ' ', '\t' };

                    Layer newLayer = null;
                    string inputLine = reader.ReadLine();
                    if (!string.IsNullOrEmpty(inputLine))
                    {
                        string[] dataParts = inputLine.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                        char layerType = char.Parse(dataParts[0]);
                        double thicknessValue = double.Parse(dataParts[1], CultureInfo.InvariantCulture);

                        switch (layerType)
                        {
                            case 'Z':
                                newLayer = new OzoneLayer(layerType, thicknessValue);
                                break;
                            case 'X':
                                newLayer = new OxygenLayer(layerType, thicknessValue);
                                break;
                            case 'C':
                                newLayer = new CarbonLayer(layerType, thicknessValue);
                                break;
                        }
                    }

                    if (newLayer != null)
                    {
                        layers.Add(newLayer);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return;
            }

            List<ICondition> atmospheres = new();
            while (reader.ReadChar(out char c))
            {
                switch (c)
                {
                    case 'T':
                        atmospheres.Add(Thunderstorm.Instance());
                        break;
                    case 'S'
                    :
                        atmospheres.Add(Sunshine.Instance());
                        break;
                    case 'O':
                        atmospheres.Add(OtherConditions.Instance());
                        break;
                }
            }

            bool simulationComplete = false;
            int count = 1;
            while (!simulationComplete)
            {
                foreach (ICondition atmosphere in atmospheres)
                {
                    Console.WriteLine($"Cycle {count}: -");
                    foreach (Layer layer in new List<Layer>(layers))
                    {
                        atmosphere.Apply(layer);
                        Console.WriteLine($"{layer.Type} : {layer.Thickness:0.00}");
                    }
                    count++;

                    simulationComplete = IsAnyLayerPerished(layers);
                    if (simulationComplete) break;
                }

                Vanish(layers);
            }
            Console.WriteLine();
            Console.WriteLine("These Layers remain:");
            foreach (Layer layer in layers)
            {
                Console.WriteLine($"{layer.Type} : {layer.Thickness:F2}");
            }
        }

        private static bool IsAnyLayerPerished(List<Layer> layers)
        {
            bool hasOzone = false, hasOxygen = false, hasCarbonDioxide = false;
            foreach (var layer in layers)
            {
                switch (layer.Type)
                {
                    case 'Z':
                        hasOzone = true;
                        break;
                    case 'X':
                        hasOxygen = true;
                        break;
                    case 'C':
                        hasCarbonDioxide = true;
                        break;
                }
                if (hasOzone && hasOxygen && hasCarbonDioxide) return false;
            }
            return !(hasOzone && hasOxygen && hasCarbonDioxide);
        }

        private static void Vanish(List<Layer> layer)
        {
            for (int i = 0; i < layer.Count; i++)
            {
                if (!layer[i].isOkay())
                {
                    layer.RemoveAt(i);
                }
            }
        }
    }
}
