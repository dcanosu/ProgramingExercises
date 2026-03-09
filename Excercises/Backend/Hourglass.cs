namespace Backend;

public class Hourglass : Shape
{
    private int _size;
    private int[,] _data = new int[0, 0];

    public Hourglass(int size)
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
                _data[i, j] = (i * 2) + j;
            }
        }
    }

    public override void Draw(bool onlyHourglass = true)
    {
        int x = _size / 2;

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (onlyHourglass)
                {
                    bool isUpper = i <= j && i + j < _size;
                    bool isLower = i >= j && i + j >= _size - 1;

                    if (isUpper || isLower)
                    {
                        Console.Write(_data[i, j].ToString().PadLeft(4));
                    }
                    else
                    {
                        Console.Write("    ");
                    }
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