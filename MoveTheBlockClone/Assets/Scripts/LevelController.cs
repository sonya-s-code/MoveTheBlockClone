using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public static List<Block> GetTestLevel(int levelNumber)
    {
        var levels = new List<List<Block>>();
        #region level1
        levels.Add(new List<Block>()
        {
            new Block()
            {
                IsMain = true,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 0, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 3 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 3, Y = 4 }
            }
        });
        #endregion

        #region level2
        levels.Add(new List<Block>()
        {
            new Block()
            {
                IsMain = true,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 3, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 4 }
            }
            ,
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 3, Y = 4 }
            }
        });
        #endregion

        #region level3
        levels.Add(new List<Block>()
        {
            new Block()
            {
                IsMain = true,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 0, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 0, Y = 4 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 4 }
            },
        });
        #endregion

        #region level4
        levels.Add(new List<Block>()
        {
            new Block()
            {
                IsMain = true,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 0, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 3, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 0, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 2, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 3, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                Index = new XYIndex(){ X = 1, Y = 4 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                Index = new XYIndex(){ X = 4, Y = 3 }
            },
        });
        #endregion
        return (levels[levelNumber > levels.Count - 1 ? levels.Count - 1 : levelNumber]);
    }

    public static List<Block> GenerateLevel(int minStep)
    {
        List<Block> blocks = new List<Block>(); ;
        int step = 0;

        List<Block> mainBlockVariants = new List<Block>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                mainBlockVariants.Add(new Block()
                {
                    IsMain = true,
                    IsVertical = false,
                    IsBig = false,
                    Index = new XYIndex() { X = i, Y = j }
                });

            }
        }

        while (step < minStep && mainBlockVariants.Count != 0)
        {
            step = 0;
            blocks.Clear();

            var mainBlock = mainBlockVariants[UnityEngine.Random.Range(0, mainBlockVariants.Count)];
            mainBlockVariants.Remove(mainBlock);

            blocks.Add(mainBlock);
            var mask = GetMask(blocks);

            List<Block> blockVariants = new List<Block>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i < 4)
                        blockVariants.Add(new Block
                        {
                            Index = new XYIndex { X = i, Y = j },
                            IsBig = false,
                            IsVertical = false,
                        });

                    if (i < 3)
                        blockVariants.Add(new Block
                        {
                            Index = new XYIndex { X = i, Y = j },
                            IsBig = true,
                            IsVertical = false,
                        });

                    if (j < 4)
                        blockVariants.Add(new Block
                        {
                            Index = new XYIndex { X = i, Y = j },
                            IsBig = false,
                            IsVertical = true,
                        });

                    if (j < 3)
                        blockVariants.Add(new Block
                        {
                            Index = new XYIndex { X = i, Y = j },
                            IsBig = true,
                            IsVertical = true,
                        });
                }
            }
            blockVariants.Where(t => !CheckGodBlock(mask, t)).ToList().ForEach(t => blockVariants.Remove(t));

            var newBlockVariants = blockVariants.Select(t => new Block()
            {
                IsBig = t.IsBig,
                Index = new XYIndex() { X = t.Index.X, Y = t.Index.Y },
                IsMain = t.IsMain,
                IsVertical = t.IsVertical,
            }).ToList();

            while (step < 7 && newBlockVariants.Count != 0)
            {
                var randomBlock = newBlockVariants[UnityEngine.Random.Range(0, newBlockVariants.Count)];
                blocks.Add(randomBlock);
                mask = GetMask(blocks);
                var newStep = CheckLevel(blocks, mask, mainBlock.Index.Y, 0);
                if (newStep > step && newStep < 9999)
                {
                    step = newStep;
                    blockVariants.Where(t => !CheckGodBlock(mask, t)).ToList().ForEach(t => blockVariants.Remove(t));

                    newBlockVariants = blockVariants.Select(t => new Block()
                    {
                        IsBig = t.IsBig,
                        Index = new XYIndex() { X = t.Index.X, Y = t.Index.Y },
                        IsMain = t.IsMain,
                        IsVertical = t.IsVertical,
                    }).ToList();
                }
                else
                {
                    blocks.Remove(randomBlock);
                    newBlockVariants.Remove(randomBlock);
                }
            }
        }
        if (step < minStep)
            return new List<Block>();
        return blocks;
    }


    public static int CheckLevel(List<Block> blocks, int[,] levelMask, int mainBlockLine, int step)
    {
        if (CheckGodLevel(levelMask, mainBlockLine))
            return step;
        int minDecision = 9999;
        step++;

        for (int m = 0; m < blocks.Count; m++)
        {
            blocks.Add(blocks[0]);
            blocks.RemoveAt(0);

            int blockCounter = 0;
            foreach (var block in blocks)
            {
                int[,] newLevelMask = CloneMask(levelMask);
                blockCounter++;
                if (!block.IsVertical)
                {
                    for (int i = block.Index.X - 1; i >= 0; i--)
                    {
                        if (newLevelMask[i, block.Index.Y] == 0)
                        {
                            newLevelMask[i, block.Index.Y] = newLevelMask[i + 1, block.Index.Y];
                            newLevelMask[i + (block.IsBig ? 3 : 2), block.Index.Y] = 0;
                            //ShowMask(newLevelMask);
                            if (CheckGodLevel(newLevelMask, mainBlockLine))
                                return step;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                int newDecision = CheckLevel(newBloks, newLevelMask, mainBlockLine, step);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            i = 0;
                    }
                    for (int i = block.Index.X + (block.IsBig ? 3 : 2); i < 5; i++)
                    {
                        if (newLevelMask[i, block.Index.Y] == 0)
                        {
                            newLevelMask[i, block.Index.Y] = newLevelMask[i - 1, block.Index.Y];
                            newLevelMask[i - (block.IsBig ? 3 : 2), block.Index.Y] = 0;
                            //ShowMask(newLevelMask);
                            if (CheckGodLevel(newLevelMask, mainBlockLine))
                                return step;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                int newDecision = CheckLevel(newBloks, newLevelMask, mainBlockLine, step);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;

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
                        if (newLevelMask[block.Index.X, i] == 0)
                        {
                            newLevelMask[block.Index.X, i] = newLevelMask[block.Index.X, i + 1];
                            newLevelMask[block.Index.X, i + (block.IsBig ? 3 : 2)] = 0;
                            //ShowMask(newLevelMask);
                            if (CheckGodLevel(newLevelMask, mainBlockLine))
                                return step;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                int newDecision = CheckLevel(newBloks, newLevelMask, mainBlockLine, step);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            i = 0;
                    }
                    for (int i = block.Index.Y + (block.IsBig ? 3 : 2); i < 5; i++)
                    {
                        if (newLevelMask[block.Index.X, i] == 0)
                        {
                            newLevelMask[block.Index.X, i] = newLevelMask[block.Index.X, i - 1];
                            newLevelMask[block.Index.X, i - (block.IsBig ? 3 : 2)] = 0;
                            //ShowMask(newLevelMask);
                            if (CheckGodLevel(newLevelMask, mainBlockLine))
                                return step;
                            else
                            {
                                List<Block> newBloks = blocks.Where((t, k) => k >= blockCounter).ToList();
                                int newDecision = CheckLevel(newBloks, newLevelMask, mainBlockLine, step);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            i = 4;
                    }
                }
            }
        }
        return minDecision;
    }


    public static int[,] GetMask(List<Block> blocks)
    {
        int[,] levelMask = new int[5, 5];
        foreach (var block in blocks)
        {
            for (int i = 0; i < (block.IsBig ? 3 : 2); i++)
            {
                if (!block.IsVertical)
                    levelMask[block.Index.X + i, block.Index.Y] = block.IsMain ? 2 : 1;
                else
                    levelMask[block.Index.X, block.Index.Y + i] = 1;
            }
        }
        return levelMask;
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

    public static void ShowMask(int[,] levelMask)
    {
        for (int i = 0; i < 5; i++)
        {
            string a = "";
            for (int j = 0; j < 5; j++)
            {
                a += levelMask[j, i];
            }
            Debug.Log(a);
        }
        Debug.Log("------------------");
    }

    public static bool CheckGodLevel(int[,] levelMask, int mainBlockLine)
    {
        if (levelMask[3, mainBlockLine] == 2 && levelMask[4, mainBlockLine] == 0 ||
           levelMask[2, mainBlockLine] == 2 && levelMask[3, mainBlockLine] == 0 && levelMask[4, mainBlockLine] == 0 ||
           levelMask[1, mainBlockLine] == 2 && levelMask[2, mainBlockLine] == 0 && levelMask[3, mainBlockLine] == 0 && levelMask[4, mainBlockLine] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckGodBlock(int[,] levelMask, Block block)
    {
        if (block.IsVertical)
        {
            if (levelMask[block.Index.X, block.Index.Y] == 0 && levelMask[block.Index.X, block.Index.Y + 1] == 0 && (!block.IsBig || levelMask[block.Index.X, block.Index.Y + 2] == 0))
            {
                return true;
            }
            return false;
        }
        else
        {
            if (levelMask[block.Index.X, block.Index.Y] == 0 && levelMask[block.Index.X + 1, block.Index.Y] == 0 && (!block.IsBig || levelMask[block.Index.X + 2, block.Index.Y] == 0))
            {
                return true;
            }
            return false;
        }
    }
}
