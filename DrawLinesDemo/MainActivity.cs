using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;

namespace DrawLinesDemo
{
    [Activity(Label = "DrawLinesDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var series = new List<StackedProductivityItem>();
            series.Add(new StackedProductivityItem(74, Color.Rgb(179, 198, 24))); // green
            series.Add(new StackedProductivityItem(5, Color.Rgb(129, 164, 188))); // blue
            series.Add(new StackedProductivityItem(6, Color.Rgb(225, 112, 54))); // red
            series.Add(new StackedProductivityItem(15, Color.Rgb(253, 213, 86))); // yellow

            var stackedView = FindViewById<StackedProductivityView>(Resource.Id.StackedProductivityChart);
            stackedView.Stretch = false;
            stackedView.SetSeries(series);
        }
    }
}