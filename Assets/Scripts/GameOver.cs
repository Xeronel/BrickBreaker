using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Paddle").GetComponent<PaddleScript>().Die();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
