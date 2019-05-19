using AGI.Foundation;
using AGI.Foundation.Celestial;
using AGI.Foundation.Coordinates;
using System;

namespace STKComponentsTutorials
{
    class Example004
    {
        static void Main(string[] args)
        {
            // 球坐标转为笛卡尔坐标
            var spherical0 = new Spherical(Math.PI / 4, Math.PI / 8, 100.0);
            var cartesian0 = new Cartesian(spherical0);
            Console.WriteLine("球坐标：{0}；笛卡尔坐标：{1}", spherical0, cartesian0);

            // 笛卡尔坐标归一化
            UnitCartesian unitCartesian1 = cartesian0.Normalize();
            Console.WriteLine("单位矢量笛卡尔坐标：{0}", unitCartesian1);

            // 地图坐标转为笛卡尔坐标
            var cartographic2 = new Cartographic(Trig.DegreesToRadians(120), Trig.DegreesToRadians(30), 100);
            EarthCentralBody earth = CentralBodiesFacet.GetFromContext().Earth;
            Cartesian cartesian2 = earth.Shape.CartographicToCartesian(cartographic2);
            Console.WriteLine("地图坐标：{0}；笛卡尔坐标：{1}", cartographic2, cartesian2);

            // 笛卡尔坐标转为地图坐标
            Cartographic cartographic3 = earth.Shape.CartesianToCartographic(cartesian2);
            Console.WriteLine("笛卡尔坐标：{0}；地图坐标：{1}", cartesian2, cartographic3);

            // 新坐标系绕原坐标系z轴旋转90度，原向量(1,0,0)
            var vector4 = new Cartesian(1, 0, 0);
            var rotation4 = new ElementaryRotation(AxisIndicator.Third, Trig.DegreesToRadians(90));
            Cartesian newVector4 = new Matrix3By3(rotation4).Multiply(vector4);
            Console.WriteLine("旋转前：{0}；旋转后：{1}", vector4, newVector4);

            // 欧拉旋转
            var vector5 = new Cartesian(1, 0, 0);
            double angle = Trig.DegreesToRadians(90);
            var euler = new EulerSequence(angle, angle, angle, EulerSequenceIndicator.Euler321);
            Cartesian newVector5 = new Matrix3By3(euler).Multiply(vector5);
            Console.WriteLine("旋转前：{0}；旋转后：{1}", vector5, newVector5);

            // 偏航俯仰翻滚旋转
            var vector6 = new Cartesian(1, 0, 0);
            double angle6 = Trig.DegreesToRadians(90);
            var ypr = new YawPitchRoll(angle, angle, angle, YawPitchRollIndicator.YPR);
            Cartesian newVector6 = new Matrix3By3(ypr).Multiply(vector6);
            Console.WriteLine("旋转前：{0}；旋转后：{1}", vector6, newVector6);

            Console.Read();
        }
    }
}
