using System;
using System.Globalization;
using ReactiveUI;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;

using CalculatorModel.Models;

namespace SmartCalcDesktopGui.ViewModels;

public class CalculatorViewModel: ViewModelBase
{
    private static CalcCore _calc = new CalcCore();

    private string _expression = "";
    private string _answer = "";
    private double _xmin = 0.0;
    private double _xmax = 1.0;
    private double _xval = 0.0;
    
    public CartesianChart MyChart { get; set; }
    
    private static readonly SKColor s_gray = new(195, 195, 195);
    private static readonly SKColor s_gray1 = new(160, 160, 160);
    private static readonly SKColor s_gray2 = new(90, 90, 90);
    private static readonly SKColor s_dark3 = new(60, 60, 60);

    public Axis[] XAxes { get; set; } =
    {
        new Axis()
        {
            TextSize = 18,
            Padding = new Padding(5, 15, 5, 5),
            LabelsPaint = new SolidColorPaint(s_gray),
            SeparatorsPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1,
                PathEffect = new DashEffect(new float[] { 3, 3 })
            },
            SubseparatorsPaint = new SolidColorPaint
            {
                Color = s_gray2,
                StrokeThickness = 0.5f
            },
            SubseparatorsCount = 9,
            ZeroPaint = new SolidColorPaint
            {
                Color = s_gray1,
                StrokeThickness = 2
            },
            TicksPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1.5f
            },
            SubticksPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1
            }
        }
    };
    
    public Axis[] YAxes { get; set; } =
    {
        new Axis
        {
            TextSize = 18,
            Padding = new Padding(5, 0, 15, 0),
            LabelsPaint = new SolidColorPaint(s_gray),
            SeparatorsPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1,
                PathEffect = new DashEffect(new float[] { 3, 3 })
            },
            SubseparatorsPaint = new SolidColorPaint
            {
                Color = s_gray2,
                StrokeThickness = 0.5f
            },
            SubseparatorsCount = 9,
            ZeroPaint = new SolidColorPaint
            {
                Color = s_gray1,
                StrokeThickness = 2
            },
            TicksPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1.5f
            },
            SubticksPaint = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1
            }
        }
    };

    public DrawMarginFrame Frame { get; set; } =
        new()
        {
            Fill = new SolidColorPaint(s_dark3),
            Stroke = new SolidColorPaint
            {
                Color = s_gray,
                StrokeThickness = 1
            }
        };
    
    public ISeries[] Series { get; set; } 
        = new ISeries[]
        {
            new LineSeries<ObservablePoint>
            {
                Values = _calc.GetGraph("0", -10, 10),
                Fill = null,
                GeometrySize = 0,
                Stroke = new SolidColorPaint(new SKColor(33,150,243), 4),
            }
        };
    
    public string Expression
    {
        get => _expression;
        set => this.RaiseAndSetIfChanged(ref _expression, value);
    }
    
    public string Answer
    {
        get => _answer;
        set => this.RaiseAndSetIfChanged(ref _answer, value);
    }

    public double Xmin
    {
        get => _xmin;
        set
        {
            this.RaiseAndSetIfChanged(ref _xmin, value);
            XAxes[0].MinLimit = Xmin;
            this.OnDrawButtonClickCommand();
        }
    }

    public double Xmax
    {
        get => _xmax;
        set
        {
            this.RaiseAndSetIfChanged(ref _xmax, value);
            XAxes[0].MaxLimit = Xmax;
            this.OnDrawButtonClickCommand();
        }
    }

    public double XVal
    {
        get => _xval;
        set => this.RaiseAndSetIfChanged(ref _xval, value);
    }

    public void OnDrawButtonClickCommand()
    {
        try
        {
            Series[0].Values = _calc.GetGraph(Expression, Xmin, Xmax);
        }
        catch (Exception e)
        {
            Answer = e.Message;
        }
    }

    public void OnEqualButtonClickCommand()
    {
        Answer = _calc.Calculate(Expression.Replace("x", XVal.ToString(CultureInfo.InvariantCulture)));
    }
}