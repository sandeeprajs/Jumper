using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : Singleton<GameOverManager>
{
    #region Varibles
    [SerializeField]
    private GameObject gameOverPanel;

    private Animator gameOverPanelAnimation;

    private Button reloadButton, MainMenuButton;

    private Text finalScore;
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Utilities
    void IntiliazeVaribles ()
    {
        gameOverPanel = GameObject.Find("Game Over Panel");

        gameOverPanelAnimation = GameObject.Find("Game Over Panel").GetComponent<Animator>();

        reloadButton = GameObject.Find("Reload Button").GetComponent<Button>();
        MainMenuButton = GameObject.Find("Main Menu").GetComponent<Button>();

        reloadButton.onClick.AddListener( ()=>IntiliazeVaribles() );
    }

    void ReloadGame ()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    void MainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
    #endregion
}
