public class Block{
    public bool IsMain;
    public bool IsVertical;
    public bool IsBig;
    public XYIndex Index;
}

[System.Serializable]
public class XYIndex
{
    public int X;
    public int Y;
}
