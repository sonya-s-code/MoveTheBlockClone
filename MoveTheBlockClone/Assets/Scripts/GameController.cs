using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    private GameObject[] m_Levels;
    [SerializeField]
    private Text m_MinStep;
    [SerializeField]
    private Text m_Step;

    public static int StepNumber;
    public static Action Action_AddStep;
    public static Action<int> Action_ShowLevel;
    public static Action Action_Win;

    [SerializeField]
    private GameObject m_Win;

    void Start () {
        Action_Win += Win;
        Action_ShowLevel += ShowLevel;
        Action_AddStep += AddStep;
    }

    private void Win()
    {
        m_Win.SetActive(true);
    }

    private void ShowLevel(int minStep)
    {
        StepNumber = 0;
        m_Step.text = StepNumber.ToString();
        m_MinStep.text = minStep.ToString();
        m_Win.SetActive(false);
        foreach (var level in m_Levels)
        {
            level.SetActive(false);
        }
    }

    private void AddStep()
    {
        StepNumber++;
        m_Step.text = StepNumber.ToString();
    }

    private void OnDestroy()
    {
        Action_Win -= Win;
        Action_ShowLevel -= ShowLevel;
        Action_AddStep -= AddStep;
    }
}
