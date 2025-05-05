using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject); // Destroy this instance if another one already exists
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
        }
    }
}
