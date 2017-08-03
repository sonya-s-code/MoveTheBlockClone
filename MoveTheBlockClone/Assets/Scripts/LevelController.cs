using System;
using System.Collections;
using System.Collections.Generic;
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
                Index = new XYIndex(){ X = 1, Y = 2 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                BlockSize = BlockSize.Size2,
                Index = new XYIndex(){ X = 0, Y = 0 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = true,
                BlockSize = BlockSize.Size3,
                Index = new XYIndex(){ X = 4, Y = 1 }
            },
            new Block()
            {
                IsMain = false,
                IsVertical = false,
                BlockSize = BlockSize.Size3,
                Index = new XYIndex(){ X = 0, Y = 4 }
            }
        };
    }
}
