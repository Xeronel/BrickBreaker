using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{
    //Public
    public GUISkin scoreboardSkin;
    public GameObject ballPrefab;
    public float paddleSpeed;
    public int lives;
    public int score;

    //Private
    float paddleBounds;
    GameObject attachdBall;
    GUIText guiLives;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //SpawnBall();
        paddleBounds = (GameObject.Find("Plane").GetComponent<Collider>().bounds.size.x - collider.bounds.size.x) / 2;

        Debug.Log("Level started");
    }

    public void OnLevelWasLoaded(int level)
    {
        SpawnBall();
        
        string levelName = Application.loadedLevelName;
        if (levelName != "GameOver" && levelName != "GameWon")
            paddleBounds = (GameObject.Find("Plane").GetComponent<Collider>().bounds.size.x - collider.bounds.size.x) / 2;

        Debug.Log("Level loaded");
    }

    // Update is called once per frame
    void Update()
    {
        // Left-Right
        transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);


        if (transform.position.x > paddleBounds)
            transform.position = new Vector3(paddleBounds, transform.position.y, transform.position.z);

        if (transform.position.x < -paddleBounds)
            transform.position = new Vector3(-paddleBounds, transform.position.y, transform.position.z);

        // Fire the ball
        if (attachdBall)
        {
            Rigidbody ballRigidbody = attachdBall.rigidbody;
            ballRigidbody.position = transform.position + new Vector3(0, attachdBall.collider.bounds.size.y + 0.1f, 0);

            if (Input.GetButtonDown("Jump"))
            {
                attachdBall.rigidbody.isKinematic = false;
                attachdBall.rigidbody.AddForce(1000f * Input.GetAxis("Horizontal"), 1000f, 0);
                attachdBall = null;
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = scoreboardSkin;
        //Show score
        GUI.Label(new Rect(0, 10, 100, 100), "Score: " + score);
        //Show lives
        GUI.Label(new Rect(Screen.width - 100, 10, 100, 100), "Lives: " + lives);
    }

    void OnCollisionEnter(Collision col)
    {

        Debug.Log("Paddle Collision!");
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == collider)
            {
                // This is the paddle's contact point
                float english = contact.point.x - transform.position.x;
                contact.otherCollider.rigidbody.AddForce((contact.otherCollider.rigidbody.velocity.y * english * 50f), 0, 0);
            }
        }
    }

    public void LoseLife()
    {
        lives--;

        if (lives > 0)
            SpawnBall();
        else
            GameObject.Find("LevelManager").GetComponent<LevelManagerScript>().LoadGameOver();
    }

    public void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.Log("You forgot to link to the ball prefab in the inspector");
            return;
        }

        //Spawn ball
        attachdBall = (GameObject)Instantiate(ballPrefab, transform.position + new Vector3(0f, 0.75f, 0f), Quaternion.identity);
        Debug.Log("Ball spawned");
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void AddPoint(int v)
    {
        score += v;
    }
}
