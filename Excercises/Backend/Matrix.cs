namespace Backend;

public class Matrix : Shape
{
    private int _size;
    private int[,] _data = new int[0, 0];

    public Matrix(int size)
    {
        Size = size;
        Initialize();
    }

    public override int Size
    {
        get => _size;
        set => _size = ValidateSize(value);
    }

    public override void Initialize()
    {
        _data = new int[_size, _size];

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                _data[i, j] = i + j;
            }
        }
    }

    public override void Draw(bool onlyLower = false)
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (onlyLower && j > i)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write(_data[i, j].ToString().PadLeft(4));
                }
            }
            Console.WriteLine();
        }
    }
}