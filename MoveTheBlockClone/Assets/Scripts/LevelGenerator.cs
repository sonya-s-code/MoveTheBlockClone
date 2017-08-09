using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private static int function_GenerateLevelStep_CallNumber = 0; 
    private static int function_GetLevelDecisionStep_CallNumber = 0;

    private const int Infinity = 9999;
    private static int searchDepth;

    private static List<StepInfo> stepInfo = new List<StepInfo>();
    private static Block mainBlock;
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
        searchDepth = minStep;
        function_GenerateLevelStep_CallNumber = 0;
        function_GetLevelDecisionStep_CallNumber = 0;

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

        availableBlockVariants = new List<Block>();
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                if (i < levelWidth - 1)
                    availableBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = false,
                        IsVertical = false,
                    });

                if (i < levelWidth - 2)
                    availableBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = true,
                        IsVertical = false,
                    });

                if (j < levelHeight - 1)
                    availableBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = false,
                        IsVertical = true,
                    });

                if (j < levelHeight - 2)
                    availableBlockVariants.Add(new Block
                    {
                        X = i,
                        Y = j,
                        IsBig = true,
                        IsVertical = true,
                    });
            }
        }

        List<Block> blocks;
        while (mainBlockVariants.Count != 0)
        {
            blocks = new List<Block>();

            mainBlock = mainBlockVariants[UnityEngine.Random.Range(0, mainBlockVariants.Count)];
            mainBlockVariants.Remove(mainBlock);

            blocks.Add(mainBlock);
            blocks = GenerateLevelStep(0, minStep, levelWidth, levelHeight, blocks);
            if (blocks != null)
            {
                Debug.Log(function_GenerateLevelStep_CallNumber);
                Debug.Log(function_GetLevelDecisionStep_CallNumber);
                return blocks;
            }
        }
        Debug.Log(function_GenerateLevelStep_CallNumber);
        Debug.Log(function_GetLevelDecisionStep_CallNumber);
        return null;
    }

    public static List<Block> GenerateLevelStep(int step, int minStep, int levelWidth, int levelHeight, List<Block> blocks)
    {
        function_GenerateLevelStep_CallNumber++;

        var levelMask = getLevelMask(blocks, levelWidth, levelHeight);

        List<Block> removedBlocks = new List<Block>();
        availableBlockVariants.Where(t => !checkGoodBlock(levelMask, t)).ToList().ForEach(t => 
        {
            removedBlocks.Add(t);
            availableBlockVariants.Remove(t);
        });

        while (availableBlockVariants.Count != 0)
        {
            var randomBlock = availableBlockVariants[UnityEngine.Random.Range(0, availableBlockVariants.Count)];
            blocks.Add(randomBlock);

            stepInfo.Clear();
            var newStep = GetLevelDecisionStep(levelWidth, levelHeight, blocks, 0, -1);
            if (newStep >= minStep && newStep < Infinity)
            {
                return blocks;
            }
            if (newStep > step && newStep < Infinity)
            {
                if (GenerateLevelStep(newStep, minStep, levelWidth, levelHeight, blocks) != null)
                {
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


    public static int GetLevelDecisionStep(int levelWidth, int levelHeight, List<Block> blocks, int step, int prevStepBlockNumber)
    {
        function_GetLevelDecisionStep_CallNumber++;

        var levelMask = getLevelMask(blocks, levelWidth, levelHeight);

        if (checkGoodLevel(levelMask))
            return step;

        if (step == searchDepth)
            return Infinity;

        step++;
        int minDecision = Infinity;
        int blockNumber = 0;
        foreach (var block in blocks)
        {
            if (blockNumber != prevStepBlockNumber)
            {
                if (!block.IsVertical)
                {
                    var x = block.X;
                    for (int i = block.X - 1; i >= 0; i--)
                    {
                        if (levelMask[i, block.Y] == false)
                        {
                            block.X = i;
                            if (checkIsNewStep(blocks, step))
                            {
                                int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            break;
                    }
                    block.X = x;
                    var last = levelWidth - (block.IsBig ? 2 : 1);
                    for (int i = block.X + 1; i < last; i++)
                    {
                        if (levelMask[i + (block.IsBig ? 2 : 1), block.Y] == false)
                        {
                            block.X = i;
                            if (checkIsNewStep(blocks, step))
                            {
                                int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            break;
                    }
                    block.X = x;
                }
                else
                {
                    var y = block.Y;
                    for (int i = block.Y - 1; i >= 0; i--)
                    {
                        if (levelMask[block.X, i] == false)
                        {
                            block.Y = i;
                            if (checkIsNewStep(blocks, step))
                            {
                                int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            break;
                    }
                    block.Y = y;
                    var last = levelHeight - (block.IsBig ? 2 : 1);
                    for (int i = block.Y + 1; i < last; i++)
                    {
                        if (levelMask[block.X, i + (block.IsBig ? 2 : 1)] == false)
                        {
                            block.Y = i;
                            if (checkIsNewStep(blocks, step))
                            {
                                int newDecision = GetLevelDecisionStep(levelWidth, levelHeight, blocks, step, blockNumber);
                                if (newDecision < minDecision)
                                    minDecision = newDecision;
                            }
                        }
                        else
                            break;
                    }
                    block.Y = y;
                }
            }
            blockNumber++;
        }
        return minDecision;
    }

    private static bool checkIsNewStep(List<Block> blocks, int step)
    {
        for (int k = stepInfo.Count - 1; k > -1; k--)
        {
            bool needBreak = false;
            for (int i = 0; i < blocks.Count; i++)
            {
                if((blocks[i].IsVertical && stepInfo[k].BlockPositions[i] != blocks[i].Y) ||
                    (!blocks[i].IsVertical && stepInfo[k].BlockPositions[i] != blocks[i].X))
                { 
                    needBreak = true;
                    break;
                }
            }
            if (needBreak)
                continue;

            if (stepInfo[k].Step <= step)
                return false;
            else
                stepInfo[k].Step = step;
            return true;                
        }

        byte[] blockPositions = new byte[blocks.Count*2];
        for (int i = 0; i < blocks.Count; i ++)
        {
            if(blocks[i].IsVertical)
                blockPositions[i] = (byte)blocks[i].Y;
            else
                blockPositions[i] = (byte)blocks[i].X;
        }
        stepInfo.Add(new StepInfo() { BlockPositions = blockPositions, Step = step });
        return true;
    }

    private static bool[,] getLevelMask(List<Block> blocks, int levelWidth, int levelHeight)
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

    private static void showMask(int[,] levelMask)
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

    private static bool checkGoodLevel(bool[,] levelMask)
    {
        for (int i = mainBlock.X + 2; i < levelMask.GetLength(0); i++)
        {
            if (levelMask[i, mainBlock.Y] != false)
                return false;
        }
        return true;
    }

    private static bool checkGoodBlock(bool[,] levelMask, Block block)
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