using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoCSharpe2emeSemaine
{
    class Program
    {
        static void Main(string[] args)
        {
            double perim;
            double surf;

            Console.WriteLine("Quel est votre forme : Cercle = ce / Rectangle = r / Carre = c :");
            String Saisie = Console.ReadLine();

            if (Saisie == "r")
            {
                Console.WriteLine("Votre Longueur : ");
                double Long = double.Parse(Console.ReadLine());
                Console.WriteLine("Votre Largeur : ");
                double Larg = double.Parse(Console.ReadLine());

                Rectangle rec = new Rectangle(Long, Larg);
                perim = rec.Perimetre();
                surf = rec.Surface();
                Afficher();
            }

            else if (Saisie == "c")
            {
                Console.WriteLine("Votre Coté : ");
                double cot = double.Parse(Console.ReadLine());

                Carre car = new Carre(cot);
                perim = car.Perimetre();
                surf = car.Surface();
                Afficher();
            }

            else if (Saisie == "ce")
            {
                Console.WriteLine("Votre rayon : ");
                double ray = double.Parse(Console.ReadLine());

                Cercle cerc = new Cercle(ray);
                perim = cerc.Perimetre();

                surf = cerc.Surface();
                Afficher();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Mauvaise saisie");
            }

            void Afficher()
            {
                Console.Write("Le ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("périmètre");
                Console.ResetColor();
                Console.Write(" est de : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(perim, 2));
                Console.ResetColor();
                Console.Write(" et la ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("surface");
                Console.ResetColor();
                Console.Write(" de : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Math.Round(surf, 2));
            }

            Console.ReadKey();
        }
    }

    public interface IGeometrie
    {
        double Surface();
        double Perimetre();
    }

    public class Point
    {
        private int X;
        private int Y;

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int x { get; set; }
        public int y { get; set; }

        public override string ToString()
        {
            return "(" + this.X.ToString() + "," + this.Y + ")";
        }

        public Point symetrique()
        {
            return new Point(-1 * this.X, -1 * this.Y);
        }

        public bool Coincide(Point p)
        {
            return (this.X == p.X) && (this.Y == p.Y);
        }
    }

    public abstract class FormGeo : IGeometrie
    {
        private Point p;

        public Point P { get; set; }

        public FormGeo()
        {
        }

        public FormGeo(Point p)
        {
            this.p = p;
        }

        public abstract double Surface();
        public abstract double Perimetre();
    }

    public class Cercle : FormGeo
    {
        private static Point p;
        private double Rayon;

        public Cercle()
        {
        }

        public Cercle(double rayon)
        {
            this.Rayon = rayon;
        }

        public Cercle(double rayon, Point point) : base(p)
        {
            this.Rayon = rayon;
        }

        public double rayon { get; set; }

        public override double Perimetre()
        {
            return 2 * Math.PI * Rayon;
        }

        public override double Surface()
        {
            return Math.PI * Rayon * Rayon;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cercle de centre : ");
            sb.AppendLine(base.P.ToString());
            sb.AppendFormat("Rayon : {0}\n", this.rayon);
            sb.Append("Surface : ");
            sb.AppendLine(this.Surface().ToString());
            sb.Append("Perimetre : ");
            sb.AppendLine(this.Perimetre().ToString());
            return sb.ToString();
        }
    }

    public class Rectangle : FormGeo
    {
        protected double largeur;
        protected double longueur;

        public Rectangle(Point p, double longueur, double largeur) : base(p)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        public Rectangle(double longueur, double largeur)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        public override double Perimetre()
        {
            return (largeur + longueur) * 2;
        }

        public override double Surface()
        {
            return (largeur * longueur);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Rectanfle de coin sup gauche : ");
            sb.AppendLine(base.P.ToString());
            sb.AppendFormat("Longueur : {0}\n", this.longueur);
            sb.AppendFormat("Largeur : {0}\n", this.largeur);
            sb.Append("Surface : ");
            sb.AppendLine(this.Surface().ToString());
            sb.Append("Perimetre : ");
            sb.AppendLine(this.Perimetre().ToString());
            return sb.ToString();
        }
    }


    public class Carre : Rectangle
    {
        private double Cote;

        public Carre(Point p, double cote) : base(p, cote, cote)
        {
        }

        public Carre(double cote) : base(cote, cote)
        {
            Cote = cote;
        }

        public double cote
        {
            get
            {
                return Cote;
            }
            set
            {
                Cote = value;
            }
        }

        public override double Perimetre()
        {
            longueur = Cote;
            largeur = Cote;
            return base.Perimetre();
        }

        public override double Surface()
        {
            longueur = Cote;
            largeur = Cote;
            return base.Surface();
        }
    }
}
