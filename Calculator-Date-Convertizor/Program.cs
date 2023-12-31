using Microsoft.VisualBasic;
using System;
namespace Calculator_Date_Convertizor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine("\t\tPROGRAM PENTRU PROIECT SAE");
            Console.WriteLine();

            Console.WriteLine("\tIntroducerea datelor de proiectare");
            Console.WriteLine();
            Console.Write("\tPutere nominala:\t\tPn = ");
            double Pn = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tViteza de sincronism:\t\tNs = ");
            double Ns = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tViteza nominala:\t\tNn = ");
            double Nn = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tCurent nominal:\t\t\tIn = ");
            double In = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tRandamentul:\t\t\tη = ");
            double eta = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tFactor de putere:\t\tcos φ = ");
            double cos_phi = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tCoeficient de suprasarcina:\tλ = ");
            double lambda = Convert.ToDouble(Console.ReadLine());
            Console.Write("\tFrecventa nominla:\t\tf = ");
            double f = Convert.ToDouble(Console.ReadLine());
            double pi = 3.14;
            Console.Write("\tTensiune nominala:\t\tU = ");
            double U = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("\tDeterminarea elementelor");
            Console.WriteLine();
            double gn = (Ns - Nn) / Ns;
            Console.WriteLine("\tAlunecare nominala:\t\tgn = " + Math.Round(gn, 2, MidpointRounding.AwayFromZero) + "; " + Math.Round(gn, 2, MidpointRounding.AwayFromZero) * 100 + " %");
            double Omega_s = (2 * pi * Ns) / 60;
            Console.WriteLine("\tPulsatie de sincronism:\t\tΩs = " + Math.Round(Omega_s, 2, MidpointRounding.AwayFromZero) + " rad/s");
            double Omega_n = (2 * pi * Nn) / 60;
            Console.WriteLine("\tPulsatie nominala a rotorului:\tΩn = " + Math.Round(Omega_n, 2, MidpointRounding.AwayFromZero) + " rad/s");
            double Pa = Pn / eta;
            Console.WriteLine("\tPutere absorbita:\t\tPa = " + Math.Round(Pa, 2, MidpointRounding.AwayFromZero) + " W");
            double Cn = Pn / Omega_n;
            Console.WriteLine("\tCuplu nominal:\t\t\tCn = " + Math.Round(Cn, 2, MidpointRounding.AwayFromZero) + " Nm");
            double Pt = Cn * Omega_s;
            Console.WriteLine("\tPutere transmisa la rotor:\tPt = " + Math.Round(Pt, 2, MidpointRounding.AwayFromZero) + " W");
            double Pf = Pa - Pt;
            Console.WriteLine("\tPierderile in fier:\t\tPf = " + Math.Round(Pf, 2, MidpointRounding.AwayFromZero) + " W");
            double Cm = Cn * lambda;
            Console.WriteLine("\tCuplu maxim:\t\t\tCm = " + Math.Round(Cm, 2, MidpointRounding.AwayFromZero) + " Nm");
            double Xr = (3 * U * U) / (2 * Omega_s * Cm);
            Console.WriteLine("\t\t\t\t\tXr = " + Math.Round(Xr, 2, MidpointRounding.AwayFromZero) + " Ω");
            Console.WriteLine();

            Console.WriteLine("\tRezolvarea ecuatiei de gradul II");
            Console.WriteLine();
            Console.WriteLine("\tPt * R\xB2 - 3 * U\xB2 * R + Pt * Xr\xB2 = 0, unde R = ?");
            double a = Pt;
            Console.WriteLine("\t\ta = Pt = " + Math.Round(a, 2, MidpointRounding.AwayFromZero));
            double b = -3 * U * U;
            Console.WriteLine("\t\tb = - 3 * U² = " + Math.Round(b, 2, MidpointRounding.AwayFromZero));
            double c = Pt * Xr * Xr;
            Console.WriteLine("\t\tc = Pt * Xr² = " + Math.Round(c, 2, MidpointRounding.AwayFromZero));
            double delta = b * b - 4 * a * c;
            Console.WriteLine("\t\tΔ = " + Math.Round(delta, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("\t\t\u221AΔ = " + Math.Round(Math.Sqrt(delta), 2, MidpointRounding.AwayFromZero));
            double R1 = (3 * U * U + Math.Sqrt(delta)) / (2 * Pt);
            Console.WriteLine("\t\tR1 = " + Math.Round(R1, 2, MidpointRounding.AwayFromZero) + " Ω =>");
            double R2 = (3 * U * U - Math.Sqrt(delta)) / (2 * Pt);
            Console.WriteLine("\t\tR2 = " + Math.Round(R2, 2, MidpointRounding.AwayFromZero) + " Ω =>");
            Console.WriteLine();

            Console.WriteLine("\tDeterminarea curentului din infasurarea rotorului");
            Console.WriteLine();
            double Ir1 = U / Math.Sqrt(Xr * Xr + R1 * R1);
            Console.WriteLine("\t\t=> Ir1 = " + Math.Round(Ir1, 2, MidpointRounding.AwayFromZero) + " A");
            double Ir2 = U / Math.Sqrt(Xr * Xr + R2 * R2);
            Console.WriteLine("\t\t=> Ir2 = " + Math.Round(Ir2, 2, MidpointRounding.AwayFromZero) + " A");
            double Ir = 0, R = 0;
            if (Ir1 <= In)
            {
                Ir = Ir1;
                R = R1;
            }
            else if (Ir2 <= In)
            {
                Ir = Ir2;
                R = R2;
            }
            Console.WriteLine("\t\tdeci: Ir = " + Math.Round(Ir, 2, MidpointRounding.AwayFromZero) + " A (Ir <= In = " + In + " A) =>");
            Console.WriteLine("\t\t=> R = " + Math.Round(R, 2, MidpointRounding.AwayFromZero) + " Ω =>");
            double Rr = R * gn;
            Console.WriteLine("\t\t=> Rr = " + Math.Round(Rr, 2, MidpointRounding.AwayFromZero) + " Ω");
            Console.WriteLine();

            Console.WriteLine("\tDeterminarea parametrilor motorului asincron trifazat");
            Console.WriteLine();
            double Qr = 3 * Xr * Ir * Ir;
            Console.WriteLine("\tPutere reactiva consumata pe Xr:      Qr = " + Math.Round(Qr, 2, MidpointRounding.AwayFromZero) + " VAR");
            double tan_phi = Math.Sqrt(1 - cos_phi * cos_phi) / cos_phi;
            Console.WriteLine("\t\t\t\t\t      tan φ = " + Math.Round(tan_phi, 2, MidpointRounding.AwayFromZero));
            double Qa = Pa * tan_phi;
            Console.WriteLine("\tPutere reactiva totala:\t\t      Qa = " + Math.Round(Qa, 2, MidpointRounding.AwayFromZero) + " VAR");
            double Qmiu = Qa - Qr;
            Console.WriteLine("\tPutere reactiva consumata pe Xμ:      Qμ = " + Math.Round(Qmiu, 2, MidpointRounding.AwayFromZero) + " VAR");
            double Imiu = Math.Sqrt(Pf * Pf + Qmiu * Qmiu) / (3 * U);
            Console.WriteLine("\tCurent de magnetizare:\t\t      Iμ = " + Math.Round(Imiu, 2, MidpointRounding.AwayFromZero) + " A");
            double Xmiu = Qmiu / (3 * Imiu * Imiu);
            Console.WriteLine("\tReactanta de magnetixare:\t      Xμ = " + Math.Round(Xmiu, 2, MidpointRounding.AwayFromZero) + " Ω");
            double Rmiu = Pf / (3 * Imiu * Imiu);
            Console.WriteLine("\tRezistenta de magnetizare:\t      Rμ = " + Math.Round(Rmiu, 2, MidpointRounding.AwayFromZero) + " Ω");
            double Lmiu = Xmiu / (2 * pi * f);
            Console.WriteLine("\tInductivitate de magnetizare:\t      Lμ = " + Math.Round(Lmiu, 2, MidpointRounding.AwayFromZero) + " Hz");
            double Lr = Xr / (2 * pi * f);
            Console.WriteLine("\tInductivitatea infasurarii rotorului: Lr = " + Math.Round(Lr, 2, MidpointRounding.AwayFromZero) + " Hz");
            Console.ReadLine();
        }
    }
}