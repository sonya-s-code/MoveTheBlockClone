using System;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private GameObject[] m_Levels;

    public static int LevelStepNumber;
    public static Action Action_AddStep;
    public static Action Action_ShowLevel;
    public static Action Action_Win;

    [SerializeField]
    private GameObject m_Win;

    void Start () {
        //bloks = new List<GameObject>();
        ////ShowLevel();
        //List<Block> levelBlocks;
        //levelBlocks = LevelController.GetTestLevel(4);
        //LevelController.MainBlock = levelBlocks.FirstOrDefault(t => t.IsMain);
        //Debug.Log(LevelController.GetLevelDecisionStep(5, 5, levelBlocks, 0, -1));
        //ShowLevel(levelBlocks);
        Action_Win += Win;
        Action_ShowLevel += ShowLevel;
    }

    private void Win()
    {
        m_Win.SetActive(true);
    }

    private void ShowLevel()
    {
        foreach (var level in m_Levels)
        {
            level.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Action_Win -= Win;
    }
}
