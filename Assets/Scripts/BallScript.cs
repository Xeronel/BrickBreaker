using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public int maxSpeed;
    public AudioClip[] blipAudio;

    int maxMagnitude;

    // Use this for initialization
    void Start()
    {
        if (maxSpeed == 0)
            Debug.LogError("You forgot to set maxSpeed!");

        maxMagnitude = maxSpeed * maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        AudioSource.PlayClipAtPoint(blipAudio[Random.Range(0, blipAudio.Length)], transform.position, 0.5f);

        rigidbody.AddForce(rigidbody.velocity.normalized.x * 100f, rigidbody.velocity.y, 0, ForceMode.Force);
        rigidbody.AddForce(rigidbody.velocity.x, rigidbody.velocity.normalized.y * 100f, 0, ForceMode.Force);
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.sqrMagnitude > maxMagnitude)
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;

        //Add a check to make sure the ball is within the level bounds
        //if it is not move it back within the bounds
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject paddleObject = GameObject.Find("Paddle");
        PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
        paddleScript.LoseLife();
    }
}
