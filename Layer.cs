using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_2
{
    public abstract class Layer
    {
        public char Type { get; set; }
        public double Thickness { get; set; }

        public Layer(char type, double thickness)
        {
            Type = type;
            Thickness = thickness;
        }

        public abstract Layer ReactWith(Thunderstorm thunderstorm);
        public abstract Layer ReactWith(Sunshine sunshine);
        public abstract Layer ReactWith(OtherConditions other);
        public virtual bool isOkay()
        {
            return Thickness >= 0.5;
        }
    }

    public class OzoneLayer : Layer
    {
        public OzoneLayer(char type, double thickness) : base(type, thickness) { }
        public override Layer ReactWith(Thunderstorm thunderstorm)
        {
            return this;
        }

        public override Layer ReactWith(Sunshine sunshine)
        {
            return this;
        }

        public override Layer ReactWith(OtherConditions other)
        {
            double thickness = Thickness * 0.05;
            Thickness -= thickness;
            return new OxygenLayer('X', thickness);
        }
    }

    public class OxygenLayer : Layer
    {
        public OxygenLayer(char type, double thickness) : base(type, thickness) { }
        public override Layer ReactWith(Thunderstorm thunderstorm)
        {
            double thickness = Thickness * 0.5;
            Thickness -= thickness;
            return new OzoneLayer('Z', thickness);
        }

        public override Layer ReactWith(Sunshine sunshine)
        {
            double thickness = Thickness * 0.05;
            Thickness -= thickness;
            return new OzoneLayer('Z', thickness);
        }

        public override Layer ReactWith(OtherConditions other)
        {
            double thickness = Thickness * 0.1;
            Thickness -= thickness;
            return new CarbonLayer('C', thickness);
        }
    }

    public class CarbonLayer : Layer
    {
        public CarbonLayer(char type, double thickness) : base(type, thickness) { }
        public override Layer ReactWith(Thunderstorm thunderstorm)
        {
            return this;
        }

        public override Layer ReactWith(Sunshine sunshine)
        {
            double thickness = Thickness * 0.05;
            Thickness -= thickness;
            return new OxygenLayer('X', thickness);
        }

        public override Layer ReactWith(OtherConditions other)
        {
            return this;
        }
    }
}