public class Block{
    public Block(bool isMain, bool isVertical, bool isBig, int x, int y)
    {
        IsMain = isMain;
        IsVertical = isVertical;
        IsBig = isBig;
        X = x;
        Y = y;
    }

    public Block()
    {
    }

    public bool IsMain;
    public bool IsVertical;
    public bool IsBig;
    public int X;
    public int Y;
}
