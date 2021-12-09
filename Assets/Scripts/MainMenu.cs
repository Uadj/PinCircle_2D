using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransformMove menuPanel;
    private Vector3 inactivePosition = Vector3.left * 1080;
    private Vector3 activePosition = Vector3.zero;
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private TextMeshProUGUI textLevelInMenu;
    [SerializeField]
    private TextMeshProUGUI textLevelInGame;
    private void Awake()
    {
        int index = PlayerPrefs.GetInt("StageLevel");
        textLevelInMenu.text = $"LEVEL {(index + 1)}";

    }
    public void ButtonClickEventStart()
    {
       //Debug.Log("Game Start");
        menuPanel.MoveTo(AfterStartEvent, inactivePosition);

    }
    private void AfterStartEvent()
    {
        //bug.Log("Game Start");
        stageController.IsGameStart = true;
    }
    public void ButtonClickEventReset()
    {
        //bug.Log("Reset");
        PlayerPrefs.SetInt("StageLevel", 0);
        SceneManager.LoadScene(0);
    }
    public void StageExit()
    {
        int index = PlayerPrefs.GetInt("StageLevel");
        textLevelInMenu.text = $"LEVEL {(index + 1)}";
        menuPanel.MoveTo(AfterStageExitEvent, activePosition);
        
    }
    private void AfterStageExitEvent()
    {
        int index = PlayerPrefs.GetInt("StageLevel");
        if (index == SceneManager.sceneCountInBuildSettings) // ¿£µù
        {
            PlayerPrefs.SetInt("StageLevel", 0);
            SceneManager.LoadScene(0);
            return;
        }
        SceneManager.LoadScene(index );
    }
    public void ButtonClickEventExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
