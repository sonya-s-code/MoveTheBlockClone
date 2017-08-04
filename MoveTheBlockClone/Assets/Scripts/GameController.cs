using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static int LevelStepNumber;
    public static Action Action_AddStep;

    [SerializeField]
    private GameObject m_Blocks;
    [SerializeField]
    private GameObject m_MainBlock;
    [SerializeField]
    private GameObject m_BlockHorisontal;
    [SerializeField]
    private GameObject m_BigBlockHorisontal;
    [SerializeField]
    private GameObject m_BlockVertical;
    [SerializeField]
    private GameObject m_BigBlockVertical;

    void Start () {
        var levelBlocks = LevelController.GenerateLevel();
        Debug.Log(LevelController.CheckLevel(levelBlocks, LevelController.GetMask(levelBlocks)));
        foreach (var levelBlock in levelBlocks)
        {
            GameObject instantiateObj;
            if (levelBlock.IsMain)
                instantiateObj = m_MainBlock;
            else
            {
                switch (levelBlock.BlockSize)
                {
                    case BlockSize.Size3:
                        if(levelBlock.IsVertical)
                            instantiateObj = m_BigBlockVertical;
                        else
                            instantiateObj = m_BigBlockHorisontal;
                        break;
                    default:
                        if (levelBlock.IsVertical)
                            instantiateObj = m_BlockVertical;
                        else
                            instantiateObj = m_BlockHorisontal;
                        break;
                }
            }

            var obj = Instantiate(instantiateObj, new Vector3(levelBlock.Index.X - 2, 2 - levelBlock.Index.Y, -1), instantiateObj.transform.rotation, m_Blocks.transform);

            var moveBlock = obj.GetComponent<MoveBlock>();
            moveBlock.isMain = levelBlock.IsMain;
            moveBlock.isVertical = levelBlock.IsVertical;
        }
	}
}
