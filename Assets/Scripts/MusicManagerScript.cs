using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManagerScript : MonoBehaviour
{
    public AudioClip[] songs;
    int currentSong = 0;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying == false)
        {
            currentSong = currentSong % songs.Length;
            audio.clip = songs[currentSong];
            audio.volume = 0.2f;
            audio.Play();
            currentSong++;
        }
    }
}