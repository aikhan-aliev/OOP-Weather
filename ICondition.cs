using Assign_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_2
{
    public interface ICondition
    {
        public Layer Apply(Layer layer);
    }

    public class Thunderstorm : ICondition
    {
        private static Thunderstorm value;

        private Thunderstorm() { }

        public static Thunderstorm Instance()
        {
            if (value == null)
            {
                value = new Thunderstorm();
            }
            return value;
        }

        public Layer Apply(Layer layer)
        {
            return layer.ReactWith(this);
        }

    }

    public class Sunshine : ICondition
    {
        private static Sunshine value;

        private Sunshine() { }

        public static Sunshine Instance()
        {
            if (value == null)
            {
                value = new Sunshine();
            }
            return value;
        }

        public Layer Apply(Layer layer)
        {
            return layer.ReactWith(this);
        }

    }

    public class OtherConditions : ICondition
    {
        private static OtherConditions value;
        private OtherConditions() { }

        public static OtherConditions Instance()
        {
            if (value == null)
            {
                value = new OtherConditions();
            }
            return value;
        }

        public Layer Apply(Layer layer)
        {
            return layer.ReactWith(this);
        }
    }
}
