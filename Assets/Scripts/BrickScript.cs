using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour
{
    public int Life = 1;
    public int pointValue = 1;

    Color[] colors = new Color[1];

    // Use this for initialization
    void Start()
    {
        colors[0] = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {

        Life--;
        if (Life > 0)
            renderer.material.color = colors[Life - 1];

        if (Life <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
        }

    }
}
