using LiveChartsCore.Defaults;
using Xunit.Abstractions;

namespace CalculatorModelTest;

using CalculatorModel.Models;

public class CalculatorModelTests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

    [Fact]
    public void Create_Model_Then_Call_Calculate_Test()
    {
        var model = new CalcCore();
        var result = model.Calculate("1+1");
        var expected = "2.000000";
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Create_Model_Then_Call_GetGraph_Test()
    {
        var model = new CalcCore();
        var leftBound = -1.0;
        var result = model.GetGraph("1+1", -1, 1);
        var x = -1.0;
        var h = (2.0 / 1000.0);
        var expected = new List<ObservablePoint>();
        for (var i = 0; i < 1001; i++)
        {
            expected.Add(new ObservablePoint(x, h));
            x += h;
        }

        for (var i = 0; i < result.Count(); i++)
        {
            Assert.True(Math.Abs(expected[i].X.Value - result[i].X.Value) < 0.001);
        }
    }
}