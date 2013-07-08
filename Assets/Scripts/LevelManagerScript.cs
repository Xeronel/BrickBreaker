using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour
{
    public string[] Levels;
    public string winLevel;
    public string loseLevel;

    GUIElement PlayButton;
    int currentLevel = 0;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (Levels == null)
            Debug.LogError("Levels cannot be null");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (Application.loadedLevelName == "MainMenu")
        {
            int btnWidth = 100;
            int btnHeight = 30;

            Vector2 pos = new Vector2((Screen.width / 2) - (btnWidth / 2), (Screen.height / 2) - (btnHeight / 2));

            if (GUI.Button(new Rect(pos.x, pos.y, btnWidth, btnHeight), "Play"))
                Application.LoadLevel(Levels[0]);

            if (GUI.Button(new Rect(pos.x, pos.y + btnHeight, btnWidth, btnHeight), "Quit"))
                Application.Quit();
        }
    }

    public void NextLevel()
    {
        currentLevel++;

        if (currentLevel < Levels.Length)
            Application.LoadLevel(Levels[currentLevel]);
        else
            LoadWinLevel();

    }

    public void LoadWinLevel()
    {
        GameObject.Find("Paddle").GetComponent<PaddleScript>().Die();
        Application.LoadLevel(winLevel);
    }

    public void LoadGameOver()
    {
        GameObject.Find("Paddle").GetComponent<PaddleScript>().Die();
        Application.LoadLevel(loseLevel);
    }
}
