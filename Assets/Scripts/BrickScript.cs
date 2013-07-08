using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour
{
    static int numBricks = 0;
    public int pointValue = 1;
    public int hitPoints = 1;

    Color[] colors = new Color[1];

    // Use this for initialization
    void Start()
    {
        numBricks++;
        Debug.Log(numBricks);
        colors[0] = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        hitPoints--;

        if (hitPoints > 0)
            renderer.material.color = colors[hitPoints - 1];

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
            numBricks--;
        }

        if (numBricks == 0)
        {
            GameObject.Find("LevelManager").GetComponent<LevelManagerScript>().NextLevel();
        }
    }
}
    