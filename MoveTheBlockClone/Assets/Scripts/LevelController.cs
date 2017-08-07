using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField]
    private int m_Width;
    [SerializeField]
    private int m_Height;
    [SerializeField]
    private int m_RandomStepFrom;
    [SerializeField]
    private int m_RandomStepTo;
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

    private List<GameObject> blocks;
    private GameObject winBorder;

    private void Awake()
    {
        blocks = new List<GameObject>();
    }

    public void ShowLevel()
    {
        int minStep = Random.Range(m_RandomStepFrom, m_RandomStepTo);
        GameController.Action_ShowLevel.Invoke(minStep);
        gameObject.SetActive(true);

        List<Block> levelBlocks;
        levelBlocks = LevelGenerator.GenerateLevel(minStep, m_Width, m_Height);

        foreach (var block in blocks)
            Destroy(block);
        blocks.Clear();

        foreach (var levelBlock in levelBlocks)
        {
            GameObject instantiateObj;
            if (levelBlock.IsMain)
            {
                instantiateObj = m_MainBlock;
                Destroy(winBorder);
                winBorder = Instantiate(m_WinBorder, new Vector3(m_Width / 2f + 0.09f, m_Width / 2f - 0.5f - levelBlock.Y, -2), m_WinBorder.transform.rotation, transform);
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

            var obj = Instantiate(instantiateObj, new Vector3(levelBlock.X - m_Width / 2f + 0.5f , m_Height / 2f - 0.5f - levelBlock.Y, -1), instantiateObj.transform.rotation, m_Blocks.transform);
            var moveBlock = obj.GetComponent<MoveBlock>();
            moveBlock.IsMain = levelBlock.IsMain;
            moveBlock.IsVertical = levelBlock.IsVertical;
            moveBlock.IndexPosition = new XYIndex() { X = levelBlock.X, Y = levelBlock.Y };

            blocks.Add(obj);
        }
    }
}
