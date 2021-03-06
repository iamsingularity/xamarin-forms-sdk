﻿using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace SDKBrowser.Examples.ChartControl.AnnotationsCategory.GridLineAnnotationsExample
{
    public class GridLineAnnotationsCSharp : ContentView
    {
        public GridLineAnnotationsCSharp()
        {
            // >> chart-annotations-gridline-csharp
            var verticalAxis = new NumericalAxis();
            var chart = new RadCartesianChart
            {
                BindingContext = new ViewModel(),
                HorizontalAxis = new CategoricalAxis
                {
                    LabelFitMode = AxisLabelFitMode.MultiLine,
                },
                VerticalAxis = verticalAxis,
                Series =
                {
                    new BarSeries
                    {
                        ValueBinding = new PropertyNameDataPointBinding("Value"),
                        CategoryBinding = new PropertyNameDataPointBinding("Category")
                    }
                },
                Annotations =
                {
                    new CartesianGridLineAnnotation
                    {
                        Axis = verticalAxis,
                        StrokeThickness = 2,
                        Stroke = Color.FromHex("0E72F6"),
                        DashArray = new[] { 4.0, 2.0 }
                    }
                }
            };

            chart.Series[0].SetBinding(ChartSeries.ItemsSourceProperty, "Data");
            chart.Annotations[0].SetBinding(CartesianGridLineAnnotation.ValueProperty, "Threshold");
            // << chart-annotations-gridline-csharp

            this.Content = chart;
        }
    }
}
