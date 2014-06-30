using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace DrawLinesDemo
{
    public class StackedProductivityView : View
    {
        List<StackedProductivityItem> series;
        float startPoint;

        public List<StackedProductivityItem> Series
        {
            get
            {
                return series;
            }
            set
            {
                series = value;
                PostInvalidate();
            }
        }

        public bool Stretch
        {
            get;
            set;
        }

        public StackedProductivityView(Context context) : base(context)
        {
            Initialize();
        }

        public StackedProductivityView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        public StackedProductivityView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize();
        }

        public StackedProductivityView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Initialize();
        }

        void Initialize()
        {
            series = new List<StackedProductivityItem>();
        }

        public void SetSeries(List<StackedProductivityItem> series)
        {
            this.series = series;
            Invalidate();
            RequestLayout();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec);
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawColor(Color.Gray);

            var itemLength = 1f;

//            if (Stretch)
//                itemLength = canvas.Width / series.Sum(p => p.ProductivityValue);

            var y = 1;
            var paint = new Paint();
            paint.SetStyle(Paint.Style.Fill);

            Console.WriteLine("ItemLength: " + itemLength);
            Console.WriteLine("ItemLength Streched: " + Stretch);

            foreach (var productivityItem in series)
            {
                var width = productivityItem.ProductivityValue;

                if (width.CompareTo(0) == 0)
                    continue;

                paint.Color = productivityItem.Color;
                paint.StrokeWidth = canvas.Height / series.Count;

                var startx = startPoint;
                var starty = y * paint.StrokeWidth;
                var stopx = width * itemLength;
                var stopy = y * paint.StrokeWidth;

                Console.WriteLine("\r\nY-Axis: " + y);
                Console.WriteLine("Width (ProductivityValue): " + width);
                Console.WriteLine("PaintStrokeWidth: " + paint.StrokeWidth);

                Console.WriteLine("StartPoint: " + startPoint);

                Console.WriteLine("Start X: " + startx);
                Console.WriteLine("Stop X: " + stopx);

                Console.WriteLine("Start Y: " + starty);
                Console.WriteLine("Stop Y: " + stopy);

                canvas.DrawLine(startx, starty, stopx, stopy, paint);

                startPoint += width * itemLength;

                y++;
            }
        }
    }

    public class StackedProductivityItem
    {
        public Color Color
        {
            get;
            set;
        }

        public float ProductivityValue
        {
            get;
            set;
        }

        public StackedProductivityItem()
        { }

        public StackedProductivityItem(float productivityValue, Color color)
        {
            ProductivityValue = productivityValue;
            Color = color;
        }
    }
}