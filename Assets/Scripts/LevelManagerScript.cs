using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour
{
    public string[] Levels;
    public string winLevel;
    public string loseLevel;

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

}
