namespace ATAS.Indicators.Technical
{
    using System.ComponentModel;
    using ATAS.Indicators;
    using OFT.Rendering.Context;
    using Color = System.Windows.Media.Color;
    using Colors = System.Windows.Media.Colors;
    using ATAS.Indicators.Technical.Properties;
    using System.Drawing;
    using ATAS.Indicators.Drawing;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Utils.Common.Localization;
    using Utils.Common;
    using OFT.Rendering.Tools;

    public class EMACOLORS
    {
        public static Color EMA5 = Color.FromRgb(254, 234, 74);
        public static Color EMA50 = Color.FromRgb(31, 188, 211);
        public static Color EMA100 = Color.FromRgb(220, 225, 128);
        public static Color EMA200 = Color.FromRgb(255, 255, 255);
        public static Color EMA800 = Color.FromRgb(50, 34, 144);
        // opacity 40%
        public static Color EMACloud = Color.FromArgb(60, 155, 47, 174);
    }
    public class MarketData
    {
        public static Color London = Color.FromArgb(75, 123, 134, 120);
        public static Color LondonLabel = Color.FromArgb(255, 123, 134, 120);

        public static Color NewYork = Color.FromArgb(75, 251, 86, 91);
        public static Color NewYorkLabel = Color.FromArgb(255, 251, 86, 91);

        public static Color Tokyo = Color.FromArgb(75, 80, 174, 85);
        public static Color TokyoLabel = Color.FromArgb(255, 80, 174, 85);

        public static Color HongKong = Color.FromArgb(75, 128, 127, 23);
        public static Color HongKongLabel = Color.FromArgb(255, 128, 127, 23);

        public static Color Sydney = Color.FromArgb(75, 37, 228, 123);
        public static Color SydneyLabel = Color.FromArgb(255, 37, 228, 123);

        public static Color EUBrinks = Color.FromArgb(65, 255, 255, 255);
        public static Color EUBrinksLabel = Color.FromArgb(255, 255, 255, 255);

        public static Color USBrinks = Color.FromArgb(65, 255, 255, 255);
        public static Color USBrinksLabel = Color.FromArgb(255, 255, 255, 255);

        public static Color Frankfurt = Color.FromArgb(75, 253, 152, 39);
        public static Color FrankfurtLabel = Color.FromArgb(255, 253, 152, 39);

        public static TimeSpan LondonStart = new TimeSpan(9, 0, 0);
        public static TimeSpan LondonEnd = new TimeSpan(17, 30, 0);

        public static TimeSpan NewYorkStart = new TimeSpan(15, 30, 0);
        public static TimeSpan NewYorkEnd = new TimeSpan(22, 0, 0);

        public static TimeSpan TokyoStart = new TimeSpan(3, 30, 0);
        public static TimeSpan TokyoEnd = new TimeSpan(10, 0, 0);

        public static TimeSpan HongKongStart = new TimeSpan(1, 0, 0);
        public static TimeSpan HongKongEnd = new TimeSpan(9, 30, 0);

        public static TimeSpan SydneyStart = new TimeSpan(0, 0, 0);
        public static TimeSpan SydneyEnd = new TimeSpan(8, 0, 0);

        public static TimeSpan EUBrinksStart = new TimeSpan(9, 0, 0);
        public static TimeSpan EUBrinksEnd = new TimeSpan(10, 0, 0);

        public static TimeSpan USBrinksStart = new TimeSpan(15, 0, 0);
        public static TimeSpan USBrinksEnd = new TimeSpan(16, 0, 0);

        public static TimeSpan FrankfurtStart = new TimeSpan(7, 0, 0);
        public static TimeSpan FrankfurtEnd = new TimeSpan(16, 30, 0);
    }

    [DisplayName("PVSRA_EMA50")]
    [LocalizedDescription(typeof(Resources), "EMA50")]
    [Display(GroupName ="EMA50")]
    public class EMA50: EMA
    {
        public EMA50() : base()
        {
            this.Name = "EMA50";
            this.Period = 50;
            this.BullishColor = EMACOLORS.EMA50;
            this.BearishColor = EMACOLORS.EMA50;
            this.DataSeries[0].DrawAbovePrice = false;
            this.DataSeries[0].Name = "EMA50";
        }
    }

    [DisplayName("PVSRA_EMA100")]
    [LocalizedDescription(typeof(Resources), "EMA100")]
    public class EMA100 : EMA
    {
        public EMA100() : base()
        {
            this.Name = "EMA100";
            this.Period = 100;
            this.BullishColor = EMACOLORS.EMA100;
            this.BearishColor = EMACOLORS.EMA100;
            this.DataSeries[0].DrawAbovePrice = false;
            this.DataSeries[0].Name = "EMA100";
        }
    }

    [DisplayName("PVSRA_EMA200")]
    [LocalizedDescription(typeof(Resources), "EMA200")]
    public class EMA200 : EMA
    {
        public EMA200() : base()
        {
            this.Period = 200;
            this.BullishColor = EMACOLORS.EMA200;
            this.BearishColor = EMACOLORS.EMA200;
            this.DataSeries[0].DrawAbovePrice = false;
            this.DataSeries[0].Name = "EMA200";
        }
    }
    [DisplayName("PVSRA_EMA800")]
    public class EMA800 : EMA
    {
        public EMA800() : base()
        {
            this.Period = 800;
            this.BullishColor = EMACOLORS.EMA800;
            this.BearishColor = EMACOLORS.EMA800;
            this.DataSeries[0].DrawAbovePrice = false;
            this.DataSeries[0].Name = "EMA800";

        }
    }

    public static class Calc
    {
        public static TimeSpan CalcSessionTimeSpan(TimeSpan ts, int tz)
        {
            if (tz > 0)
            {
                return ts += TimeSpan.FromHours(tz);
            }
            if (tz < 0)
            {
                return ts -= TimeSpan.FromHours(tz);
            }
            return ts;
        }
    }

    [DisplayName("PVSRA_SessionLondon")]
    public class PVSRA_SessionLondon : PVSRA_SessionBox
    {
        public PVSRA_SessionLondon() : base()
        {
            this.StartTime = MarketData.LondonStart;
            this.EndTime = MarketData.LondonEnd;
            this.AreaColor = MarketData.London;
            this.SessionBoxColor = MarketData.LondonLabel;
            this.SessionName = "London";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionNewYork")]
    public class PVSRA_SessionNewYork : PVSRA_SessionBox
    {
        public PVSRA_SessionNewYork() : base()
        {
            this.StartTime = MarketData.NewYorkStart;
            this.EndTime = MarketData.NewYorkEnd;
            this.AreaColor = MarketData.NewYork;
            this.SessionBoxColor = MarketData.NewYorkLabel;
            this.SessionName = "New York";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionTokyo")]
    public class PVSRA_SessionTokyo : PVSRA_SessionBox
    {
        public PVSRA_SessionTokyo() : base()
        {
            this.StartTime = MarketData.TokyoStart;
            this.EndTime = MarketData.TokyoEnd;
            this.AreaColor = MarketData.Tokyo;
            this.SessionBoxColor = MarketData.TokyoLabel;
            this.SessionName = "Tokyo";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionHongKong")]
    public class PVSRA_SessionHongKong : PVSRA_SessionBox
    {
        public PVSRA_SessionHongKong() : base()
        {
            this.StartTime = MarketData.HongKongStart;
            this.EndTime = MarketData.HongKongEnd;
            this.AreaColor = MarketData.HongKong;
            this.SessionBoxColor = MarketData.HongKongLabel;
            this.SessionName = "Hong Kong";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionSydney")]
    public class PVSRA_SessionSydney : PVSRA_SessionBox
    {
        public PVSRA_SessionSydney() : base()
        {
            this.StartTime = MarketData.SydneyStart;
            this.EndTime = MarketData.SydneyEnd;
            this.AreaColor = MarketData.Sydney;
            this.SessionBoxColor = MarketData.SydneyLabel;
            this.SessionName = "Sydney";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionEUBrinks")]
    public class PVSRA_SessionEUBrinks : PVSRA_SessionBox
    {
        public PVSRA_SessionEUBrinks() : base()
        {
            this.StartTime = MarketData.EUBrinksStart;
            this.EndTime = MarketData.EUBrinksEnd;
            this.AreaColor = MarketData.EUBrinks;
            //this.SessionBoxColor = MarketData.EUBrinksLabel;
            this.SessionName = "EU Brinks";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionUSBrinks")]
    public class PVSRA_SessionUSBrinks : PVSRA_SessionBox
    {
        public PVSRA_SessionUSBrinks() : base()
        {
            this.StartTime = MarketData.USBrinksStart;
            this.EndTime = MarketData.USBrinksEnd;
            this.AreaColor = MarketData.USBrinks;
            //this.SessionBoxColor = MarketData.USBrinksLabel;
            this.SessionName = "US Brinks";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    [DisplayName("PVSRA_SessionFrankfurt")]
    public class PVSRA_SessionFrankfurt : PVSRA_SessionBox
    {
        public PVSRA_SessionFrankfurt() : base()
        {
            this.StartTime = MarketData.FrankfurtStart;
            this.EndTime = MarketData.FrankfurtEnd;
            this.AreaColor = MarketData.Frankfurt;
            this.SessionBoxColor = MarketData.FrankfurtLabel;
            this.SessionName = "Frankfurt";
        }

        public override string ToString()
        {
            return this.GetTypeName();
        }
    }

    public class PVSRA: Indicator

    {
        public TimeSpan CalcSessionTimeSpan(TimeSpan ts)
        {
            if (InstrumentInfo.TimeZone > 0)
            {
                return ts += TimeSpan.FromHours(InstrumentInfo.TimeZone);
            }
            if (InstrumentInfo.TimeZone <0)
            {
                return ts -= TimeSpan.FromHours(InstrumentInfo.TimeZone);
            }
            return ts;
    }


        public decimal CandleSpread(IndicatorCandle c)
        {
            return c.Volume * (c.High - c.Low);
        }

        public decimal SumPrevVolume(int bar, int prev)
        {
            decimal vol = 0m;

            for (int i = bar - prev; i < bar; i++)
            {
                vol += GetCandle(i).Volume;
            }

            return vol;
        }

        public decimal HighestVolumeSpread(int bar, int prev)
        {
            decimal hs = 0;
            for (int i = bar - prev; i < bar; i++)
            {
                var c = GetCandle(i);
                var s = CandleSpread(c);
                if (s > hs)
                {
                    hs = s;
                }
            }
            return hs;
        }

        public decimal SumVolumeSpread(int bar, int prev)
        {
            decimal s = 0;
            for (int i = bar-prev; i < bar; i++)
            {
                s += CandleSpread(GetCandle(i));

            }
            return s;
        }

        readonly PaintbarsDataSeries _paintbars = new PaintbarsDataSeries("Paint Bars") { };

        public PVSRA()
            : base(true)
        {
            this.EnableCustomDrawing = true;
            DataSeries[0] = _paintbars;
            SubscribeToDrawingEvents(DrawingLayouts.LatestBar);
            _paintbars.IsHidden = true;

        }

        public Color Color1 = Color.FromRgb(0, 230, 118);
        public Color Color2 = Color.FromRgb(255, 82, 82);
        public Color Color3 = Color.FromRgb(41, 98, 255);
        public Color Color4 = Color.FromRgb(224, 64, 251);
        public Color Color5 = Color.FromRgb(153, 153, 153);
        public Color Color6 = Color.FromRgb(77, 77, 77);

        protected override void OnCalculate(int bar, decimal value)
        {

            var candle = GetCandle(bar);

            //_renderSeries[bar].High = candle.High;
            //_renderSeries[bar].Low = candle.Low;
            //_renderSeries[bar].Open = candle.Open;
            //_renderSeries[bar].Close = candle.Close;

            if (bar < 11) {
                return;
            }
            var averageVolume = SumPrevVolume(bar, 10) / 10;
            var volumeSpread = CandleSpread(candle);
            var highestVolumeSpread = HighestVolumeSpread(bar, 10);
            var averageVolumeSpread = SumVolumeSpread(bar, 10) / 10;

            if ((GetCandle(bar).Volume >= 2 * averageVolume) || (volumeSpread >= highestVolumeSpread)) {
                _paintbars[bar] = candle.Close > candle.Open ? Color1 : Color2;
            }
            else if (GetCandle(bar).Volume >= 1.5m * averageVolume)
            {
                _paintbars[bar] = candle.Close > candle.Open ? Color3 : Color4;
            } else
            {
                _paintbars[bar] = candle.Close > candle.Open ? Color5 : Color6;
            }
        }

        private readonly CandleDataSeries _renderSeries=new CandleDataSeries("Candles");

        protected override void OnRender(RenderContext context, DrawingLayouts layout)
        {

        }
    }

    [DisplayName("PVSRA_SessionBox")]
    [LocalizedDescription(typeof(Resources), "PVSRA_SessionBox")]
    public class PVSRA_SessionBox : Indicator
    {
        private class Session
        {
            public int FirstBar { get; }

            public int LastBar { get; private set; }

            private DateTime End { get; }

            private DateTime Start { get; }

            public Session(DateTime start, DateTime end, int bar)
            {
                Start = start;
                End = end;
                FirstBar = (LastBar = bar);
            }

            public bool TryAddCandle(int i, DateTime time)
            {
                if (time >= End)
                {
                    return false;
                }

                if (time < Start)
                {
                    return false;
                }

                if (i > LastBar)
                {
                    LastBar = i;
                }

                return true;
            }
        }

        private readonly List<Session> _sessions = new List<Session>();

        private readonly object _syncRoot = new object();

        private System.Drawing.Color _areaColor = System.Drawing.Color.FromArgb(63, 65, 105, 225);

        private Session _currentSession;

        private TimeSpan _endTime = new TimeSpan(12, 0, 0);

        private System.Drawing.Color _fillBrush;

        private int _lastEndAlert;

        private int _lastSessionBar;

        private int _lastStartAlert;

        private TimeSpan _startTime;

        [Display(ResourceType = typeof(Resources), Name = "ShowAboveChart", GroupName = "Settings", Order = 10)]
        public bool ShowAboveChart
        {
            get
            {
                return base.DrawAbovePrice;
            }
            set
            {
                base.DrawAbovePrice = value;
            }
        }

        [Display(ResourceType = typeof(Resources), Name = "ShowArea", GroupName = "Settings", Order = 20)]
        public bool ShowArea { get; set; } = true;


        [Display(ResourceType = typeof(Resources), Name = "AreaColor", GroupName = "Settings", Order = 30)]
        public System.Windows.Media.Color AreaColor
        {
            get
            {
                return _areaColor.Convert();
            }
            set
            {
                _areaColor = value.Convert();
                _fillBrush = _areaColor;
                RecalculateValues();
            }
        }

        [Display(ResourceType = typeof(Resources), Name = "StartTime", GroupName = "Settings", Order = 10)]
        public TimeSpan StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                RecalculateValues();
            }
        }

        [Display(ResourceType = typeof(Resources), Name = "EndTime", GroupName = "Settings", Order = 20)]
        public TimeSpan EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                RecalculateValues();
            }
        }

        [Display(ResourceType = typeof(Resources), Name = "UseAlerts", GroupName = "Open", Order = 30)]
        public bool UseOpenAlert { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "AlertFile", GroupName = "Open", Order = 40)]
        public string AlertOpenFile { get; set; } = "alert1";


        [Display(ResourceType = typeof(Resources), Name = "UseAlerts", GroupName = "Close", Order = 30)]
        public bool UseCloseAlert { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "AlertFile", GroupName = "Close", Order = 40)]
        public string AlertCloseFile { get; set; } = "alert1";


        [Display(ResourceType = typeof(Resources), Name = "SessionName", GroupName = "Box", Order = 40)]
        public string SessionName { get; set; } = "Sydney";

        [Display(ResourceType = typeof(Resources), Name = "SessionFont", GroupName = "Box", Order = 40)]
        public float SessionFont { get; set; } = 16;

        [Display(ResourceType = typeof(Resources), Name = "SessionBoxColor", GroupName = "Box", Order = 30)]
        public Color SessionBoxColor { get; set; } = Color.FromArgb(63, 65, 105, 225);

        public PVSRA_SessionBox()
            : base(useCandles: true)
        {
            base.DataSeries[0].IsHidden = true;
            base.DenyToChangePanel = true;
            base.EnableCustomDrawing = true;
            SubscribeToDrawingEvents(DrawingLayouts.Historical);
        }
        protected override void OnCalculate(int bar, decimal value)
        {
            lock (_syncRoot)
            {
                if (bar == 0)
                {
                    _sessions.Clear();
                    _currentSession = null;
                    _lastSessionBar = -1;
                    _lastEndAlert = (_lastStartAlert = -1);
                }

                IndicatorCandle candle = GetCandle(bar);
                int timeZone = base.InstrumentInfo!.TimeZone;
                DateTime dateTime = candle.Time.AddHours(timeZone);
                DateTime dateTime2 = candle.LastTime.AddHours(timeZone);
                DateTime dateTime3;
                DateTime dateTime4;
                if (EndTime >= StartTime)
                {
                    dateTime3 = dateTime.Date + StartTime;
                    dateTime4 = dateTime.Date + EndTime;
                }
                else
                {
                    dateTime3 = ((bar > 0) ? (dateTime.Date + StartTime) : (dateTime.Date.AddDays(-1.0) + StartTime));
                    dateTime4 = ((bar > 0) ? (dateTime.Date.AddDays(1.0) + EndTime) : (dateTime.Date + EndTime));
                }

                if (_currentSession == null)
                {
                    int num = StartSession(dateTime3, dateTime4, bar);
                    if (num != -1)
                    {
                        _currentSession = new Session(dateTime3, dateTime4, num);
                        _sessions.Add(_currentSession);
                        StartAlert(bar);
                    }

                    return;
                }

                StartAlert(bar);
                bool flag = _currentSession.TryAddCandle(bar, dateTime);
                if (_lastSessionBar != _currentSession.LastBar && dateTime2 >= dateTime4 && !flag)
                {
                    if (UseCloseAlert && _lastEndAlert != bar && bar == base.CurrentBar - 1)
                    {
                        AddAlert(AlertCloseFile, base.InstrumentInfo!.Instrument, "Session end", Colors.Black, Colors.White);
                        _lastEndAlert = bar;
                    }

                    _lastSessionBar = _currentSession.LastBar;
                }

                if (!flag && (!(dateTime < dateTime3) || !(dateTime2 < dateTime3)) && !(dateTime >= dateTime4))
                {
                    int num2 = StartSession(dateTime3, dateTime4, bar);
                    if (_currentSession.FirstBar != num2)
                    {
                        _currentSession = new Session(dateTime3, dateTime4, num2);
                        _sessions.Insert(0, _currentSession);
                    }
                }
            }
        }

        public List<string> SessionTimeFrameSkip = new List<string>
        {
            "Daily", "Weekly"
        };

        public bool SessionIsSkipped()
        {
            if (SessionTimeFrameSkip.Contains(ChartInfo.TimeFrame))
            {
                return true;
            }
            return false;
        }
        protected override void OnRender(RenderContext context, DrawingLayouts layout)
        {
            lock (_syncRoot)
            {

                if (SessionIsSkipped())
                {
                    return;
                }

                int num = base.LastVisibleBarNumber + 1;
                int num2 = num - base.VisibleBarsCount - 1;
                foreach (Session session in _sessions)
                {
                    if (session.FirstBar <= num)
                    {
                        if (session.LastBar < num2)
                        {
                            break;
                        }

                        int xByBar = base.ChartInfo.GetXByBar(session.FirstBar);
                        int num3 = base.ChartInfo.GetXByBar(session.LastBar + 1);
                        if (num3 > base.ChartArea.Width)
                        {
                            num3 = base.ChartArea.Width;
                        }

                        if (ShowArea)
                        {
                            // BUK: start added box drawing
                            var highestPrice = 0m;
                            var lowestPrice = GetCandle(session.FirstBar).Low;

                            for (var i = session.FirstBar; i <= session.LastBar; i++)
                            {
                                var c = GetCandle(i);
                                highestPrice = c.High > highestPrice ? c.High : highestPrice;
                                lowestPrice = c.Low < lowestPrice ? c.Low : lowestPrice;
                            }

                            var ylprice = ChartInfo.GetYByPrice(lowestPrice);
                            var yhprice = ChartInfo.GetYByPrice(highestPrice);

                            // BUK: end added
                            Rectangle rect = new Rectangle(xByBar, ylprice, num3 - xByBar, yhprice - ylprice);
                            context.FillRectangle(_fillBrush, rect);

                            // BUK: start added label drawing
                            AddText($"{session.GetHashCode()}", SessionName, true, session.FirstBar, highestPrice, SessionBoxColor.Convert(), Colors.Transparent.Convert(), SessionFont, DrawingText.TextAlign.Right);
                            // BUK: end added

                        }
                        else
                        {
                            RenderPen pen = new RenderPen(_areaColor, 2f);
                            context.DrawLine(pen, xByBar, 0, xByBar, base.ChartArea.Height);
                            context.DrawLine(pen, num3, 0, num3, base.ChartArea.Height);
                        }
                    }
                }
            }
        }

        private void StartAlert(int bar)
        {
            if (UseOpenAlert && _lastStartAlert != bar && bar == base.CurrentBar - 1 && bar == _currentSession.FirstBar)
            {
                AddAlert(AlertOpenFile, base.InstrumentInfo!.Instrument, "Session start", Colors.Black, Colors.White);
                _lastStartAlert = bar;
            }
        }

        private int StartSession(DateTime startTime, DateTime endTime, int bar)
        {
            IndicatorCandle candle = GetCandle(bar);
            int timeZone = base.InstrumentInfo!.TimeZone;
            DateTime dateTime = candle.Time.AddHours(timeZone);
            DateTime dateTime2 = candle.LastTime.AddHours(timeZone);
            if (dateTime <= endTime && (dateTime >= startTime || dateTime2 >= startTime))
            {
                return bar;
            }

            for (int i = bar; i < base.CurrentBar; i++)
            {
                IndicatorCandle candle2 = GetCandle(i);
                if (candle2.Time.AddHours(timeZone) <= endTime && candle2.Time.AddHours(timeZone) >= startTime)
                {
                    return i;
                }
            }

            return -1;
        }
    }
    [DisplayName("PVSRA_50EMACLOUD")]
    [LocalizedDescription(typeof(Resources), "PVSRA_50EMACLOUD")]
    public class PVSRA_50EMACLOUD : Indicator
    {
        private readonly SMA _sma = new SMA
        {
            Period = 100
        };

        private readonly EMA _ema = new EMA
        {
            Period = 50
        };

        private readonly RangeDataSeries _band = new RangeDataSeries("BackGround")
        {
            RenderColor = EMACOLORS.EMACloud.Convert(),
            RangeColor = EMACOLORS.EMACloud,
        };

        [OFT.Attributes.Parameter]
        [Display(ResourceType = typeof(Resources), Name = "Period", GroupName = "Common", Order = 20)]
        [Range(1, 10000)]
        public int Period
        {
            get
            {
                return _sma.Period;
            }
            set
            {
                _sma.Period = value;
                RecalculateValues();
            }
        }

        public PVSRA_50EMACLOUD()
        {
            base.Panel = "Chart";
            DataSeries.Add(new ValueDataSeries("Up")
            {
                VisualType = VisualMode.Line
            });
            DataSeries.Add(new ValueDataSeries("Down")
            {
                VisualType = VisualMode.Line
            });
            ((ValueDataSeries)DataSeries[0]).Color = EMACOLORS.EMA50;
            DataSeries.Add(_band);

            this.DrawAbovePrice = false;
            DataSeries[0].DrawAbovePrice = false;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            decimal ema50 = _ema.Calculate(bar, value);
            decimal num = _sma.Calculate(bar, value);
            int num2 = Math.Max(0, bar - Period + 1);
            int num3 = Math.Min(bar + 1, Period);
            decimal num4 = default(decimal);
            for (int i = num2; i < num2 + num3; i++)
            {
                decimal num5 = Math.Abs((decimal)base.SourceDataSeries![i] - num);
                num4 += num5 * num5;
            }

            var v = (decimal)Math.Sqrt((double)(num4 / (decimal)num3)) / 4;

            this[bar] = ema50;
            _band[bar].Upper = ema50 + v;
            _band[bar].Lower = ema50 - v;
            //base.DataSeries[1][bar] = ema50 + v;
            //base.DataSeries[2][bar] = ema50;
            //base.DataSeries[3][bar] = ema50 - v;
            //base.DataSeries[1][bar] = ema50 - v;
        }
    }
}