using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private static int f_GenerateLevelStep = 0; 
    private static int f_GetLevelDecisionStep = 0;

    private const int Infinity = 9999;
    private static int SearchDepth;

    private static List<StepInfo> StepInfo = new List<StepInfo>();
    public static Block MainBlock;
    private static List<Block> availableBlockVariants;

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
                X = 0, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 2, Y = 1
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 2, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 1, Y = 3
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 3, Y = 4
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
                X = 2, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 2, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 3, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 1, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 1, Y = 4
            }
            ,
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 3, Y = 4
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
                X = 0, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 2, Y = 1
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 1
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 2, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 0, Y = 4
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 2, Y = 4
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
                X = 0, Y = 1
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 1, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 3, Y = 0
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 0, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 1, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 2, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 3, Y = 2
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                IsBig = false,
                X = 1, Y = 4
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                IsBig = false,
                X = 4, Y = 3
            },
        });
        #endregion
        return (levels[levelNumber > levels.Count - 1 ? levels.Count - 1 : levelNumber]);
    }

    public static List<Block> GenerateLevel(int minStep, int levelWidth, int levelHeight)
    {
        SearchDepth = minStep;
        f_GenerateLevelStep = 0;
        f_GetLevelDecisionStep = 0;

        List<Block> mainBlockVariants = new List<Block>();
        for (int i = 0; i < levelWidth - 2; i++)
        {
            for (int j = 1; j < levelHeight - 1; j++)
            {
                mainBlockVariants.Add(new Block()
                {
                    IsMain = true,
                    IsVertical = false,
                    IsBig = false,
                    X = i,
                    Y = j
                });

            }
        }

        List<Block> allBlockVariants = new List<Block>();
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                if (i < levelWidth - 1)
                    allBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = false,
                        IsVertical = false,
                    });

                if (i < levelWidth - 2)
                    allBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = true,
                        IsVertical = false,
                    });

                if (j < levelHeight - 1)
                    allBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = false,
                        IsVertical = true,
                    });

                if (j < levelHeight - 2)
                    allBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = true,
                        IsVertical = true,
                    });
            }
        }

        var step = 0;
        List<Block> blocks;
        while (step < minStep && mainBlockVariants.Count != 0)
        {
            step = 0;
            blocks = new List<Block>();

            var mainBlock = mainBlockVariants[UnityEngine.Random.Range(0, mainBlockVariants.Count)];
            mainBlockVariants.Remove(mainBlock);
            MainBlock = mainBlock;

            blocks.Add(mainBlock);
            var mask = GetMask(blocks, levelWidth, levelHeight);

            availableBlockVariants = cloneBlocks(allBlockVariants);
            //availableBlockVariants = CreateCopy(allBlockVariants);
            availableBlockVariants.Where(t => !CheckGoodBlock(mask, t)).ToList().ForEach(t => availableBlockVariants.Remove(t));
            availableBlockVariants.Where(t => t.Y == mainBlock.Y && !t.IsVertical).ToList().ForEach(t => availableBlockVariants.Remove(t));
            blocks = GenerateLevelStep(0, minStep, levelWidth, levelHeight, blocks);
            if (blocks != null)
            {
                Debug.Log(f_GenerateLevelStep);
                Debug.Log(f_GetLevelDecisionStep);
                return blocks;
            }
        }
        return null;
    }

    public static List<Block> GenerateLevelStep(int step, int minStep, int levelWidth, int levelHeight, List<Block> blocks)
    {
        f_GenerateLevelStep++;

        var mask = GetMask(blocks, levelWidth, levelHeight);

        List<Block> removedBlocks = new List<Block>();
        availableBlockVariants.Where(t => !CheckGoodBlock(mask, t)).ToList().ForEach(t => 
        {
            removedBlocks.Add(t);
            availableBlockVariants.Remove(t);
        });

        while (step < minStep && availableBlockVariants.Count != 0)
        {
            var randomBlock = availableBlockVariants[UnityEngine.Random.Range(0, availableBlockVariants.Count)];
            blocks.Add(randomBlock);

            StepInfo.Clear();
            var newStep = GetLevelDecisionStep(levelWidth, levelHeight, blocks, 0, -1);
            if (newStep >= minStep && newStep < Infinity)
            {
                availableBlockVariants.AddRange(removedBlocks);
                return blocks;
            }
            if (newStep > step && newStep < Infinity)
            {
                step = newStep;
                if (GenerateLevelStep(step, minStep, levelWidth, levelHeight, blocks) != null)
                {
                    availableBlockVariants.AddRange(removedBlocks);
                    return blocks;
                }
            }
            blocks.Remove(randomBlock);
            removedBlocks.Add(randomBlock);
            availableBlockVariants.Remove(randomBlock);
        }
        availableBlockVariants.AddRange(removedBlocks);
        return null;
    }


    public static int GetLevelDecisionStep(int levelWidth, int levelHeight, List<Block> blocks, int step, int lastBlock)
    {
        f_GetLevelDecisionStep++;

        var levelMask = GetMask(blocks, levelWidth, levelHeight);

        if (CheckGoodLevel(levelMask))
            return step;

        if (IsCheckedStep(blocks, step))
            return Infinity;

        if (step == SearchDepth)
            return Infinity;

        int minDecision = Infinity;
        step++;
        int blockNumber = 0;
        foreach (var block in blocks)
        {
            if (blockNumber != lastBlock)
            {
                if (!block.IsVertical)
                {
                    var x = blocks[blockNumber].X;
                    for (int i = block.X - 1; i >= 0; i--)
                    {
                        if (levelMask[i, block.Y] == false)
                        {
                            blocks[blockNumber].X = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);

                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                            break;
                    }
                    blocks[blockNumber].X = x;
                    var last = levelWidth - (block.IsBig ? 2 : 1);
                    for (int i = block.X + 1; i < last; i++)
                    {
                        if (levelMask[i + (block.IsBig ? 2 : 1), block.Y] == false)
                        {
                            blocks[blockNumber].X = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                            break;
                    }
                    blocks[blockNumber].X = x;
                }
                else
                {
                    var y = blocks[blockNumber].Y;
                    for (int i = block.Y - 1; i >= 0; i--)
                    {
                        if (levelMask[block.X, i] == false)
                        {
                            blocks[blockNumber].Y = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                            break;
                    }
                    blocks[blockNumber].Y = y;
                    var last = levelHeight - (block.IsBig ? 2 : 1);
                    for (int i = block.Y + 1; i < last; i++)
                    {
                        if (levelMask[block.X, i + (block.IsBig ? 2 : 1)] == false)
                        {
                            blocks[blockNumber].Y = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                            break;
                    }
                    blocks[blockNumber].Y = y;
                }
            }
            blockNumber++;
        }
        return minDecision;
    }


    private static bool IsCheckedStep(List<Block> blocks, int step)
    {
        for (int k = StepInfo.Count - 1; k > -1; k--)
        {
            bool needBreak = false;
            for (int i = 0; i < blocks.Count; i++)
            {
                if((blocks[i].IsVertical && StepInfo[k].BlockPositions[i] != blocks[i].Y) ||
                    (!blocks[i].IsVertical && StepInfo[k].BlockPositions[i] != blocks[i].X))
                { 
                    needBreak = true;
                    break;
                }
            }
            if (needBreak)
                continue;

            if (StepInfo[k].Step <= step)
                return true;
            else
                StepInfo[k].Step = step;
            return false;                
        }

        byte[] blockPositions = new byte[blocks.Count*2];
        for (int i = 0; i < blocks.Count; i ++)
        {
            if(blocks[i].IsVertical)
                blockPositions[i] = (byte)blocks[i].Y;
            else
                blockPositions[i] = (byte)blocks[i].X;
        }
        StepInfo.Add(new StepInfo() { BlockPositions = blockPositions, Step = step });
        return false;
    }

    public static bool[,] GetMask(List<Block> blocks, int levelWidth, int levelHeight)
    {
        bool[,] levelMask = new bool[levelWidth, levelHeight];
        foreach (var block in blocks)
        {
            levelMask[block.X, block.Y] = true;
            if (!block.IsVertical)
            {
                levelMask[block.X + 1, block.Y] = true;
                if(block.IsBig)
                    levelMask[block.X + 2, block.Y] = true;
            }
            else
            {
                levelMask[block.X, block.Y + 1] = true;
                if (block.IsBig)
                    levelMask[block.X, block.Y + 2] = true;
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

    public static bool CheckGoodLevel(bool[,] levelMask)
    {
        for (int i = MainBlock.X + 2; i < levelMask.GetLength(0); i++)
        {
            if (levelMask[i, MainBlock.Y] != false)
                return false;
        }
        return true;
    }

    public static bool CheckGoodBlock(bool[,] levelMask, Block block)
    {
        if (block.IsVertical)
        {
            if (levelMask[block.X, block.Y] == false && levelMask[block.X, block.Y + 1] == false && (!block.IsBig || levelMask[block.X, block.Y + 2] == false))
            {
                return true;
            }
            return false;
        }
        else
        {
            if (levelMask[block.X, block.Y] == false && levelMask[block.X + 1, block.Y] == false && (!block.IsBig || levelMask[block.X + 2, block.Y] == false))
            {
                return true;
            }
            return false;
        }
    }

    private static List<Block> cloneBlocks(List<Block> blocks)
    {
        return blocks.Select(t => new Block(t.IsMain, t.IsVertical, t.IsBig, t.X, t.Y)).ToList();
    }
}

public class StepInfo
{
    public int Step;
    public byte[] BlockPositions;
}