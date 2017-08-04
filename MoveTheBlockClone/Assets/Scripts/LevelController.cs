using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public static List<Block> GenerateLevel()
    {
        return new List<Block>()
        {
            new Block()
            {
                IsMain = true,
                IsVertical = false,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 0, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 4, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 2, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 2, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 4, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 1, Y = 3 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                BlockSize = BlockSize.Size3,
                Index = new XYIndex(){ X = 2, Y = 4 }
            }
        };
    }

    public static bool CheckLevel(List<Block> blocks, int[,] levelMask)
    {
        for (int m = 0; m < blocks.Count; m++)
        {
            blocks.Add(blocks[0]);
            blocks.RemoveAt(0);

            int blockCounter = 0;
            foreach (var block in blocks)
            {
                int[,] newLevelMask2 = CloneMask(levelMask);
                blockCounter++;
                if (!block.IsVertical)
                {
                    for (int i = block.Index.X - 1; i >= 0; i--)
                    {
                        if (newLevelMask2[i, block.Index.Y] == 0)
                        {
                            //int[,] newLevelMask2 = CloneMask(newLevelMask1);
                            newLevelMask2[i, block.Index.Y] = newLevelMask2[i + 1, block.Index.Y];
                            newLevelMask2[i + (block.BlockSize == BlockSize.Size2 ? 2 : 3), block.Index.Y] = 0;
                            ShowMask(newLevelMask2);
                            if (CheckGodLevel(newLevelMask2))
                                return true;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                if (CheckLevel(newBloks, newLevelMask2))
                                    return true;

                            }
                        }
                        else
                            i = 0;
                    }
                    for (int i = block.Index.X + (block.BlockSize == BlockSize.Size2 ? 2 : 3); i < 5; i++)
                    {
                        if (newLevelMask2[i, block.Index.Y] == 0)
                        {
                            //int[,] newLevelMask2 = CloneMask(newLevelMask1);
                            newLevelMask2[i, block.Index.Y] = newLevelMask2[i - 1, block.Index.Y];
                            newLevelMask2[i - (block.BlockSize == BlockSize.Size2 ? 2 : 3), block.Index.Y] = 0;
                            ShowMask(newLevelMask2);
                            if (CheckGodLevel(newLevelMask2))
                                return true;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                if (CheckLevel(newBloks, newLevelMask2))
                                    return true;

                            }
                        }
                        else
                            i = 4;
                    }
                }
                else
                {
                    for (int i = block.Index.Y - 1; i >= 0; i--)
                    {
                        if (newLevelMask2[block.Index.X, i] == 0)
                        {
                            //int[,] newLevelMask2 = CloneMask(newLevelMask1);
                            newLevelMask2[block.Index.X, i] = newLevelMask2[block.Index.X, i + 1];
                            newLevelMask2[block.Index.X, i + (block.BlockSize == BlockSize.Size2 ? 2 : 3)] = 0;
                            ShowMask(newLevelMask2);
                            if (CheckGodLevel(newLevelMask2))
                                return true;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                if (CheckLevel(newBloks, newLevelMask2))
                                    return true;

                            }
                        }
                        else
                            i = 0;
                    }
                    for (int i = block.Index.Y + (block.BlockSize == BlockSize.Size2 ? 2 : 3); i < 5; i++)
                    {
                        if (newLevelMask2[block.Index.X, i] == 0)
                        {
                            //int[,] newLevelMask2 = CloneMask(newLevelMask1);
                            newLevelMask2[block.Index.X, i] = newLevelMask2[block.Index.X, i - 1];
                            newLevelMask2[block.Index.X, i - (block.BlockSize == BlockSize.Size2 ? 2 : 3)] = 0;
                            ShowMask(newLevelMask2);
                            if (CheckGodLevel(newLevelMask2))
                                return true;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                if (CheckLevel(newBloks, newLevelMask2))
                                    return true;
                            }
                        }
                        else
                            i = 4;
                    }
                }
            }
        }
        //ShowMask(levelMask);
        //CheckGodLevel(levelMask);
        return false;
    }


    public static int[,] GetMask(List<Block> blocks)
    {
        int[,] levelMask = new int[5, 5];
        foreach (var block in blocks)
        {
            for (int i = 0; i < (block.BlockSize == BlockSize.Size2 ? 2 : 3); i++)
            {
                if (!block.IsVertical)
                    levelMask[block.Index.X + i, block.Index.Y] = block.IsMain ? 2 : 1;
                else
                    levelMask[block.Index.X, block.Index.Y + i] = 1;
            }
        }
        return levelMask;
    }

    public static void ShowMask(int[,] levelMask)
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    string a = "";
        //    for (int j = 0; j < 5; j++)
        //    {
        //        a += levelMask[j, i];
        //    }
        //    Debug.Log(a);
        //}
        //Debug.Log("------------------");
    }

    public static bool CheckGodLevel(int[,] levelMask)
    {
        if (levelMask[3, 2] == 2 && levelMask[4, 2] == 0 ||
           levelMask[2, 2] == 2 && levelMask[3, 2] == 0 && levelMask[4, 2] == 0 ||
           levelMask[1, 2] == 2 && levelMask[2, 2] == 0 && levelMask[3, 2] == 0 && levelMask[4, 2] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int[,] CloneMask(int[,] levelMask)
    {
        int[,] a = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                a[i, j] = levelMask[i, j];
            }
        }
        return a;
    }
}
