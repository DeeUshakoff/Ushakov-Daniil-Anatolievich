using DeeULib;


namespace Study
{
    public class Vector3D : Vector2D
    {
        public double Z;
        /// <summary>
        /// Create Vector3D using X Y Z coord
        /// </summary>
        /// <param name="x">Axis X value</param>
        /// <param name="y">Axis Y value</param>
        /// <param name="z">Axis Z value</param>
        public Vector3D(double x, double y, double z) : base(x, y)
        {
            this.Z = z;
            
        }

        /// <summary>
        /// Add/Substract input Vector3D to this Vector3D
        /// </summary>
        /// <param name="input">what add</param>
        /// <param name="substract">if true: this - input, else: this + input</param>
        public void Add(Vector3D input, bool substract = false)
        {
            int multiplier = 1;
            if (substract) multiplier = -1;


            X += multiplier * input.X;
            Y += multiplier * input.Y;
            Z += multiplier * input.Z;
        }

        public override int GetHashCode()
        {
            double hash = (X * Y * Z) % 10;
            return hash.ToInt();
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
        public override bool Equals(object? obj)
        {
            var compare = obj as Vector3D;

            if((obj == null && this == null) ||
                (X == compare.X && Y == compare.Y && Z == compare.Z))
                return true;

            return false;
        }

        public new void Print()
        {
            ToString().Print();
        }
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

    }



}
