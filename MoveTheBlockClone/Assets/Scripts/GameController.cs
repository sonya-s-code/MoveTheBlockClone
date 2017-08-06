using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static int LevelStepNumber;
    public static Action Action_AddStep;

    [SerializeField]
    private GameObject m_Level;
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

    [SerializeField]
    private GameObject m_WinBorder;
    [SerializeField]
    private GameObject m_Win;

    private List<GameObject> bloks;
    private GameObject winBorder;

    void Start () {
        bloks = new List<GameObject>();
        ShowLevel();
	}

    public void ShowLevel()
    {
        m_Win.SetActive(false);
        List<Block> levelBlocks;
        //levelBlocks = LevelController.GetTestLevel(3);
        //Debug.Log(LevelController.CheckLevel(levelBlocks, LevelController.GetMask(levelBlocks), levelBlocks.FirstOrDefault(t => t.IsMain).Index.Y, 0));
        levelBlocks = LevelController.GenerateLevel(6);

        foreach (var blok in bloks)
        {
            Destroy(blok);
        }
        bloks.Clear();

        foreach (var levelBlock in levelBlocks)
        {
            GameObject instantiateObj;
            if (levelBlock.IsMain)
            {
                instantiateObj = m_MainBlock;
                Destroy(winBorder);
                winBorder = Instantiate(m_WinBorder, new Vector3(2.59f, 2 - levelBlock.Index.Y, -2), m_WinBorder.transform.rotation, m_Level.transform);
                winBorder.GetComponent<WinTrigger>().WinObject = m_Win;
            }
            else
            {
                if (levelBlock.IsBig)
                {
                    if (levelBlock.IsVertical)
                        instantiateObj = m_BigBlockVertical;
                    else
                        instantiateObj = m_BigBlockHorisontal;
                }
                else
                {
                    if (levelBlock.IsVertical)
                        instantiateObj = m_BlockVertical;
                    else
                        instantiateObj = m_BlockHorisontal;
                }
            }

            var obj = Instantiate(instantiateObj, new Vector3(levelBlock.Index.X - 2, 2 - levelBlock.Index.Y, -1), instantiateObj.transform.rotation, m_Blocks.transform);
            var moveBlock = obj.GetComponent<MoveBlock>();
            moveBlock.IsMain = levelBlock.IsMain;
            moveBlock.IsVertical = levelBlock.IsVertical;

            bloks.Add(obj);
        }
    }
}
