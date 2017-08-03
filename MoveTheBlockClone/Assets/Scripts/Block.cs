public class Block{
    public bool IsMain;
    public bool IsVertical;
    public BlockSize BlockSize;
    public XYIndex Index;
}

[System.Serializable]
public class XYIndex
{
    public int X;
    public int Y;
}

public enum BlockSize
{
    Size2,
    Size3
}

