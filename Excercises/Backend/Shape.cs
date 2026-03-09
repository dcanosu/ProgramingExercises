using System.Runtime.CompilerServices;

namespace Backend;

public abstract class Shape
{
    public abstract int Size { get; set; }

    public abstract void Draw(bool mode = false);

    public abstract void Initialize();

    protected int ValidateSize(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), $"The Size {size} must be a positive integer.");
        }
        return size;
    }
}