namespace Pac.Tool.Art3D._OBJ;

public class Vertex(float x, float y, float z)
{
    public float X { get; } = x;
    public float Y { get; } = y;
    public float Z { get; } = z;
    
    public override string ToString()
    {
        return $"v {X} {Y} {Z}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is Vertex v)
        {
            return this == v;
        }
        return false;
    }

    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            hash = hash * 23 + Z.GetHashCode();
            return hash;
        }
    }

    public static Vertex operator +(Vertex a, Vertex b)
    {
        return new Vertex(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
    
    public static Vertex operator -(Vertex a, Vertex b)
    {
        return new Vertex(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
    
    public static Vertex operator *(Vertex a, Vertex b)
    {
        return new Vertex(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }
    
    public static Vertex operator /(Vertex a, Vertex b)
    {
        return new Vertex(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }
    
    public static Vertex operator +(Vertex a, float b)
    {
        return new Vertex(a.X + b, a.Y + b, a.Z + b);
    }
    
    public static Vertex operator -(Vertex a, float b)
    {
        return new Vertex(a.X - b, a.Y - b, a.Z - b);
    }
    
    public static Vertex operator *(Vertex a, float b)
    {
        return new Vertex(a.X * b, a.Y * b, a.Z * b);
    }
    
    public static Vertex operator /(Vertex a, float b)
    {
        return new Vertex(a.X / b, a.Y / b, a.Z / b);
    }
    
    public static Vertex operator +(float a, Vertex b)
    {
        return new Vertex(a + b.X, a + b.Y, a + b.Z);
    }
    
    public static Vertex operator -(float a, Vertex b)
    {
        return new Vertex(a - b.X, a - b.Y, a - b.Z);
    }
    
    public static Vertex operator *(float a, Vertex b)
    {
        return new Vertex(a * b.X, a * b.Y, a * b.Z);
    }
    
    public static Vertex operator /(float a, Vertex b)
    {
        return new Vertex(a / b.X, a / b.Y, a / b.Z);
    }
    
    public static Vertex operator -(Vertex a)
    {
        return new Vertex(-a.X, -a.Y, -a.Z);
    }

    public static bool operator ==(Vertex a, Vertex b)
    {
        return System.Math.Abs(a.X - b.X) < 0.0001 && System.Math.Abs(a.Y - b.Y) < 0.0001 && System.Math.Abs(a.Z - b.Z) < 0.0001;
    }

    public static bool operator !=(Vertex a, Vertex b)
    {
        return !(a == b);
    }
}