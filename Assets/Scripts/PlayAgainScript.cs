using UnityEngine;
using System.Collections;

public class PlayAgainScript : MonoBehaviour
{
    GUIText guiGameOver;

    // Use this for initialization
    void Start()
    {
        guiGameOver = GameObject.Find("txtGameOver").GetComponent<GUIText>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

    }
}
