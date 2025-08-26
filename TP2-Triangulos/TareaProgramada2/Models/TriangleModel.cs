using System.ComponentModel.DataAnnotations;

public class TriangleModel
{
    [Range(0.01, double.MaxValue, ErrorMessage = "El lado 'a' debe ser mayor que 0.")]
    public double A { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El lado 'b' debe ser mayor que 0.")]
    public double B { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El lado 'c' debe ser mayor que 0.")]
    public double C { get; set; }

    public bool IsValid()
    {
        return (A + B > C) && (A + C > B) && (B + C > A);
    }
    public double Perimeter() => A + B + C;
    public double SemiPerimeter() => Perimeter() / 2;
    public double Area()
    {
        double s = SemiPerimeter();
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }
    public string TriangleType()
    {
        if (A == B && B == C) return "Equilátero";
        if (A == B || A == C || B == C) return "Isósceles";
        return "Escaleno";
    }
    public (double, double, double) CalculateAngles()
    {
        double alpha = Math.Acos((Math.Pow(B, 2) + Math.Pow(C, 2) - Math.Pow(A, 2)) / (2 * B * C)) * (180 / Math.PI);
        double beta = Math.Acos((Math.Pow(A, 2) + Math.Pow(C, 2) - Math.Pow(B, 2)) / (2 * A * C)) * (180 / Math.PI);
        double gamma = 180 - (alpha + beta);
        return (alpha, beta, gamma);
    }
}