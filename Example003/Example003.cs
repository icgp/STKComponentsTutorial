using AGI.Foundation.Time;
using System;

namespace Example003
{
    class Example003
    {
        static void Main(string[] args)
        {
            var dateTime = new DateTime(2019, 5, 20);
            // 时间转换为JulianDate的协调世界时（UTC）,
            var jdUTC = new JulianDate(dateTime, TimeStandard.CoordinatedUniversalTime);
            Console.WriteLine("时间：{0}，儒略日：{1}", jdUTC, jdUTC.TotalDays);

            // 时间转换为JulianDate的国际原子时（TAI）,
            var jdTAI = new JulianDate(dateTime, TimeStandard.InternationalAtomicTime);
            Console.WriteLine("时间：{0}，儒略日：{1}", jdTAI, jdTAI.TotalDays);

            // 与J2000时刻的时间差
            var jdTT = new JulianDate(dateTime, TimeStandard.TerrestrialTime);
            Duration diff = jdTT - TimeConstants.J2000;
            Console.WriteLine("时间差：{0}天", diff.TotalDays);

            // UTC转为TAI
            JulianDate jdTAI2 = jdUTC.ToTimeStandard(TimeStandard.InternationalAtomicTime);
            Console.WriteLine("时间：{0}，儒略日：{1}", jdTAI2, jdTAI2.TotalDays);

            // TAI转UTC
            JulianDate jdUTC2 = TimeStandardConverter.Convert(jdTAI2, TimeStandard.CoordinatedUniversalTime);
            Console.WriteLine("时间：{0}，儒略日：{1}", jdUTC2, jdUTC2.TotalDays);

            // 加上指定天数
            JulianDate jd = jdUTC.AddDays(7);
            Console.WriteLine("时间：{0}，儒略日：{1}", jd, jd.TotalDays);

            Console.Read();
        }
    }
}
