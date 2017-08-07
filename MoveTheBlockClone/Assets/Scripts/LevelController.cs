using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private const int Infinity = 9999;
    private const int SearchDepth  = 5;

    private static List<StepInfo> StepInfo = new List<StepInfo>();
    public static Block MainBlock;

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
        List<Block> blocks = new List<Block>(); ;
        int step = 0;

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
                        X = i, Y = j,
                        IsBig = false,
                        IsVertical = true,
                    });

                if (j < levelHeight - 2)
                    allBlockVariants.Add(new Block
                    {
                        X = i, Y = j,
                        IsBig = true,
                        IsVertical = true,
                    });
            }
        }

        while (step < minStep && mainBlockVariants.Count != 0)
        {
            step = 0;
            blocks.Clear();

            var mainBlock = mainBlockVariants[UnityEngine.Random.Range(0, mainBlockVariants.Count)];
            mainBlockVariants.Remove(mainBlock);
            MainBlock = mainBlock;

            blocks.Add(mainBlock);
            var mask = GetMask(blocks, levelWidth, levelHeight);

            List<Block> blockVariants = cloneBlocks(allBlockVariants);
            blockVariants.Where(t => !CheckGoodBlock(mask, t)).ToList().ForEach(t => blockVariants.Remove(t));

            var stepBlockVariants = cloneBlocks(blockVariants);
            while (step < minStep && stepBlockVariants.Count != 0)
            {
                var randomBlock = stepBlockVariants[UnityEngine.Random.Range(0, stepBlockVariants.Count)];
                blocks.Add(randomBlock);
                mask = GetMask(blocks, levelWidth, levelHeight);
                var newStep = GetLevelDecisionStep(levelWidth, levelHeight, blocks, 0, -1);
                if (newStep > step && newStep < Infinity)
                {
                    step = newStep;
                    blockVariants.Where(t => !CheckGoodBlock(mask, t)).ToList().ForEach(t => blockVariants.Remove(t));
                    stepBlockVariants = cloneBlocks(blockVariants);
                }
                else
                {
                    blocks.Remove(randomBlock);
                    stepBlockVariants.Remove(randomBlock);
                }
            }
        }
        //if (step < minStep)
        //    return new List<Block>();
        return blocks;
    }


    public static int GetLevelDecisionStep(int levelWidth, int levelHeight, List<Block> blocks, int step, int lastBlock)
    {
        if (step > SearchDepth)
            return Infinity;

        var levelMask = GetMask(blocks, levelWidth, levelHeight);

        if (CheckGoodLevel(levelMask))
            return step;

        if (IsCheckedStep(levelMask, step))
            return Infinity;

        int minDecision = Infinity;
        step++;
        int blockNumber = 0;
        foreach (var block in blocks)
        {
            if(blockNumber != lastBlock)
                if (!block.IsVertical)
                {
                    for (int i = block.X - 1; i >= 0; i--)
                    {
                        if (levelMask[i, block.Y] == 0)
                        {
                            var newBlocks = cloneBlocks(blocks);
                            newBlocks[blockNumber].X = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, newBlocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                           break;
                    }
                    var last = levelWidth - (block.IsBig ? 2 : 1);
                    for (int i = block.X + 1; i < last; i++)
                    {
                        if (levelMask[i + (block.IsBig ? 2 : 1), block.Y] == 0)
                        {
                            var newBlocks = cloneBlocks(blocks);
                            newBlocks[blockNumber].X = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, newBlocks, step, blockNumber);
                            if (newDecision < minDecision)
                                    minDecision = newDecision;
                        }
                        else
                            break;
                    }
                }
                else
                {
                    for (int i = block.Y - 1; i >= 0; i--)
                    {
                        if (levelMask[block.X, i] == 0)
                        {
                            var newBlocks = cloneBlocks(blocks);
                            newBlocks[blockNumber].Y = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, newBlocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                           break;
                    }
                    var last = levelHeight - (block.IsBig ? 2 : 1);
                    for (int i = block.Y + 1; i < last; i++)
                    {
                        if (levelMask[block.X, i + (block.IsBig ? 2 : 1)] == 0)
                        {
                            var newBlocks = cloneBlocks(blocks);
                            newBlocks[blockNumber].Y = i;
                            int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, newBlocks, step, blockNumber);
                            if (newDecision < minDecision)
                                minDecision = newDecision;
                        }
                        else
                            break;
                    }
                }
            blockNumber++;
        }
        if (step == 0)
            StepInfo.Clear();
        return minDecision;
    }

    private static bool IsCheckedStep(int[,] levelMask, int step)
    {
        for (int k = StepInfo.Count - 1; k >-1 ; k--)
        {
            bool needBreak = false;
            for (int i = 0; i < levelMask.GetLength(0); i++)
            {
                for (int j = 0; j < levelMask.GetLength(1); j++)
                {
                    if (levelMask[i, j] != StepInfo[k].LevelMask[i, j])
                    {
                        needBreak = true;
                        break;
                    }
                }
                if (needBreak)
                    break;
            }
            if (needBreak)
                continue;

            if (StepInfo[k].Step <= step)
                return true;
            else
                StepInfo[k].Step = step;
            return false;                
        }
        StepInfo.Add(new StepInfo() { LevelMask = levelMask, Step = step });
        return false;
    }


    public static int[,] GetMask(List<Block> blocks, int levelWidth, int levelHeight)
    {
        int[,] levelMask = new int[levelWidth, levelHeight];
        int blockValue = 1;
        foreach (var block in blocks)
        {
            for (int i = 0; i < (block.IsBig ? 3 : 2); i++)
            {
                if (!block.IsVertical)
                    levelMask[block.X + i, block.Y] = blockValue;
                else
                    levelMask[block.X, block.Y + i] = blockValue;
            }
            blockValue++;
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

    public static bool CheckGoodLevel(int[,] levelMask)
    {
        for (int i = MainBlock.X + 2; i < levelMask.GetLength(0); i++)
        {
            if (levelMask[i, MainBlock.Y] != 0)
                return false;
        }
        return true;
    }

    public static bool CheckGoodBlock(int[,] levelMask, Block block)
    {
        if (block.IsVertical)
        {
            if (levelMask[block.X, block.Y] == 0 && levelMask[block.X, block.Y + 1] == 0 && (!block.IsBig || levelMask[block.X, block.Y + 2] == 0))
            {
                return true;
            }
            return false;
        }
        else
        {
            if (levelMask[block.X, block.Y] == 0 && levelMask[block.X + 1, block.Y] == 0 && (!block.IsBig || levelMask[block.X + 2, block.Y] == 0))
            {
                return true;
            }
            return false;
        }
    }

    private static List<Block> cloneBlocks(List<Block> blocks)
    {
        return blocks.Select(t => new Block()
        {
            IsMain = t.IsMain,
            IsVertical = t.IsVertical,
            IsBig = t.IsBig,
            X = t.X,
            Y = t.Y
        }).ToList();
    }
}

public class StepInfo
{
    public int Step;
    public int[,] LevelMask;
}