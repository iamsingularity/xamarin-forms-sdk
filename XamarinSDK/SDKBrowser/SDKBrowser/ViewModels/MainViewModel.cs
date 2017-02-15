﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKBrowser
{
    public class MainViewModel
    {
        private static Random random = new Random();

        private static string[] countries = new string[] { "France", "Belguim", "Germany" };

        private static string[] Categories = new string[] { "Greenings", "Perfecto", "NearBy", "Family", "Fresh" };

        private static double[] randomDoubleValues = new double[] { 52.00d, 60.00d, 77.00d, 50.00d, 56.00d };
        private static double[] randomDoubleValues2 = new double[] { 83.00d, 88.00d, 61.00d, 94.00d, 72.00d };

        private static int[] randomIntValues = new int[] { 26, 29, 22, 15, 10, 19, 1, 29, 8, 8, 3, 12, 9, 17, 2, 28, 11, 6, 16, 13, 4, 14, 8, 30, 6, 9, 7, 16, 22, 25 };
        private static int[] randomIntValues2 = new int[] { 12, 3, 28, 19, 27, 0, 6, 8, 21, 6, 18, 6, 27, 20, 19, 3, 6, 20, 7, 2, 15, 1, 24, 9, 10, 10, 24, 18, 13, 24 };
        private static int[] randomIntValues3 = new int[] { 21, 12, 10, 24, 20, 21, 29, 20, 20, 29, 10, 24, 25, 15, 15, 21, 21, 16, 25, 11, 10, 23, 10, 24, 21, 12, 30, 27, 27, 12, 26, 16, 14, 10, 20, 26, 23, 21, 28, 29, 22, 21, 22, 15, 27, 10, 16, 20, 14, 12, 21, 13, 12, 12, 15, 26, 28, 12, 21, 26, 24, 29, 22, 28, 21, 21, 28, 30, 23, 20, 25, 22, 13, 28, 29, 19, 24, 13, 23, 25, 10, 24, 20, 19, 28, 22, 21, 10, 18, 10, 30, 24, 19, 15, 16, 25, 12, 14, 11, 21, 24, 28, 14, 15, 14, 20, 27, 30, 10, 22, 21, 16, 19, 16, 23, 29, 28, 26, 21, 27, 21, 26, 15, 25, 23, 30, 19, 24, 20, 25, 21, 30, 10, 27, 23, 26, 24, 19, 19, 20, 22, 18, 19, 21, 13, 24, 20, 24, 26, 17, 16, 23, 28, 30, 26, 15, 21, 16, 21, 19, 15, 13, 11, 30, 22, 18, 10, 15, 16, 18, 17, 27, 21, 25, 25, 21, 11, 18, 11, 26, 23, 16, 26, 11, 20, 30, 10, 28, 30, 11, 16, 24, 12, 16, 30, 10, 24, 26, 14, 27 };


        public IList Data1
        {
            get;
            set;
        }

        public IList Data2
        {
            get;
            set;
        }

        public IList Data3
        {
            get;
            set;
        }

        public MainViewModel()
        {

        }


        public static List<CategoricalData> GetCategoricalData()
        {
            List<CategoricalData> data = new List<CategoricalData>();
            for (int i = 0; i < Categories.Length; i++)
            {
                //data.Add(new CategoricalData() { Value = random.Next(50, 100), Category = Categories[i] });
                data.Add(new CategoricalData() { Value = randomDoubleValues[i], Category = Categories[i] });
            }

            return data;
        }

        public static List<CategoricalData> GetCategoricalData2()
        {
            List<CategoricalData> data = new List<CategoricalData>();
            for (int i = 0; i < Categories.Length; i++)
            {
                data.Add(new CategoricalData() { Value = randomDoubleValues2[i], Category = Categories[i] });
            }

            return data;
        }

        public static List<NumericalData> GetNumericData(int dataCount, int xDispersion, int yDispersion, Func<int, double> xFunc, Func<int, double> yFunc)
        {
            List<NumericalData> data = new List<NumericalData>();
            for (int i = 0; i < dataCount; i++)
            {
                data.Add(new NumericalData() { XData = xFunc(i) + random.Next(0, xDispersion), YData = yFunc(i) + random.Next(0, yDispersion) });
            }

            return data;
        }

        public static List<NumericalData> GetNumericData2(int dataCount, int xDispersion, int yDispersion, Func<int, double> xFunc, Func<int, double> yFunc, bool isReversed = false)
        {
            List<NumericalData> data = new List<NumericalData>();
            if (!isReversed)
            {
                for (int i = 0; i < dataCount; i++)
                {
                    data.Add(new NumericalData() { XData = xFunc(i) + randomIntValues[i], YData = yFunc(i) + randomIntValues2[i] });
                }
            }
            else
            {
                for (int i = 0; i < dataCount; i++)
                {
                    data.Add(new NumericalData() { XData = xFunc(i) + randomIntValues2[i], YData = yFunc(i) + randomIntValues[i] });
                }
            }
            return data;
        }


        public static IEnumerable GetSimpleData(int itemsCount, int selectedIndex)
        {
            List<SimpleData> items = new List<SimpleData>();
            for (int i = 0; i < itemsCount; i++)
            {
                SimpleData data = new SimpleData();
                data.Title = countries[i];
                data.Value = random.Next(20, 60);

                if (i == selectedIndex)
                {
                    data.IsSelected = true;
                }

                items.Add(data);
            }

            return items;
        }

        public static IList GetDateTimeData(int itemsCount)
        {
            var startDate = DateTime.Now.AddYears(-1);

            List<TemporalData> items = new List<TemporalData>();
            for (int i = 0; i < itemsCount; i++)
            {
                TemporalData data = new TemporalData();
                data.Date = startDate.AddDays(i);
                data.Value = random.Next(10, 30);

                items.Add(data);
            }

            return items;
        }

        public static IList GetDateTimeData2(int itemsCount)
        {
            var startDate = new DateTime(2016, 03, 01).AddYears(-1);

            List<TemporalData> items = new List<TemporalData>();
            for (int i = 0; i < itemsCount; i++)
            {
                TemporalData data = new TemporalData();
                data.Date = startDate.AddDays(i);
                data.Value = randomIntValues3[i];

                items.Add(data);
            }

            return items;
        }


    }
}
