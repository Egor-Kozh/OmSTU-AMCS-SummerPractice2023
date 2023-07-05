namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer = new double[0];
        double x1;
        double x2;
        double eps = Math.Pow(10, -9);

        if (Double.IsPositiveInfinity(a) || Double.IsNegativeInfinity(a) || Math.Abs(a) < eps || Double.IsNaN(a))
        {
            throw new System.ArgumentException();
        }
        if (Double.IsPositiveInfinity(b) || Double.IsNegativeInfinity(b) || Double.IsNaN(b))
        {
            throw new System.ArgumentException();
        }
        if (Double.IsPositiveInfinity(c) || Double.IsNegativeInfinity(c) || Double.IsNaN(c))
        {
            throw new System.ArgumentException();
        }

        double D = (b * b) - (4.0 * a * c);
        
        if (D > -eps && D < eps)
        {
            answer = new double[1];

            x1 = c/(-b / 2);;

            answer[0] = x1;                  
        }
        if (D >= eps)
        {
            if(b > 1)
            {
                answer = new double[2];

                x1 = -(b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                x2 = c / x1;

                answer[0] = x1;
                answer[1] = x2;
            }
            if(b == 0)
            {
                answer = new double[2];

                x1 = Math.Sqrt(-c/a);
                x2 = -Math.Sqrt(-c/a);

                answer[0] = x1;
                answer[1] = x2;
            }
        }

        return answer;
    }
}


