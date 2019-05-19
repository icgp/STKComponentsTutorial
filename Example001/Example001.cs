using AGI.Foundation;
using AGI.Foundation.Celestial;
using AGI.Foundation.Geometry;
using AGI.Foundation.Time;
using System;

namespace STKComponentsTutorials
{
    class Example001
    {
        static void Main(string[] args)
        {
            // 显示版本号
            Console.WriteLine("DisplayVersion: {0}", StkComponentsCore.DisplayVersion);
            Console.WriteLine("Version: {0}", StkComponentsCore.Version);

            // 显示当前时刻地球质心和月球质心之间的距离
            DateTime now = DateTime.Now;
            EarthCentralBody earth = CentralBodiesFacet.GetFromContext().Earth;
            MoonCentralBody moon = CentralBodiesFacet.GetFromContext().Moon;
            var vector = new VectorTrueDisplacement(earth.CenterOfMassPoint, moon.CenterOfMassPoint);
            double distance = vector.GetEvaluator().Evaluate(new JulianDate(now)).Magnitude;

            Console.WriteLine("当前时间：{0:yyyy-MM-dd HH:mm:ss.fff}，当前日月距离：{1:0.000}千米",now, distance / 1000);
            Console.Read();
        }
    }
}
