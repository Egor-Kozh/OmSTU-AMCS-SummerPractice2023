using TechTalk.SpecFlow;
using SquareEquationLib;

namespace BDD.Test;

[Binding]
class UnitTest1
{
    double A, B, C;
    int precision = 9;
    double[] actual = new double[]{};

    [Given (@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентами(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    [When(@"вычисляются корни квадратного уравнения")]
    public void ВычисляютсяКорниКвадратногоУравнения()
    {
        try
        {
            actual = SquareEquation.Solve(A, B, C);
        }
        catch {}
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
         public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double one, double two)
         {
            double[] expected = {one, two};
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(expected[i], actual[i], precision);
            }
         }


    [Then(@"квадратное уравнение имеет один корень 1 кратности два")]
    public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва()
    {
        Assert.Equal(1, actual[0], precision);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void ТоМножествоКорнейКвадратногоУравненияПустое()
    {
        Assert.Empty(actual);
    }

    [Given(@"Квадратное уравнение с коэффициентами \(1e-7, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьОпределено(double b, double c)
    {
        A = 1e-7;
        B = b;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьОпределено(double b, double c)
    {
        A = double.NaN;
        B = b;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьОпределено(double a, double c)
    {
        A = a;
        B = double.NaN;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьОпределено(double a, double b)
    {
        A = a;
        B = b;
        C = double.NaN;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьПоложительнойБесконечностью(double b, double c)
    {
        A = double.PositiveInfinity;
        B = b;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьПоложительнойБесконечностью(double a, double c)
    {
        A = a;
        B = double.PositiveInfinity;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьПоложительнойБесконечностью(double a, double b)
    {
        A = a;
        B = b;
        C = double.PositiveInfinity;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьОтрицательнойБесконечностью(double b, double c)
    {
        A = double.NegativeInfinity;
        B = b;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьОтрицательнойБесконечностью(double a, double c)
    {
        A = a;
        B = double.NegativeInfinity;
        C = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьОтрицательнойБесконечностью(double a, double b)
    {
        A = a;
        B = b;
        C = double.NegativeInfinity;
    }

    [Then(@"выбрасывается исключение ArgumentException")]
    public void SolvingTheProblem4()
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(A, B, C));
    }
}