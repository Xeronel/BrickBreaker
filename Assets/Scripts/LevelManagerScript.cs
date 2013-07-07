using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour
{
    public string[] Levels;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (Levels == null)
            Debug.Log("Levels cannot be null");

    }

    // Update is called once per frame
    void Update()
    {

    }

}
