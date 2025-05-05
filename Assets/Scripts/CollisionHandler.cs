using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    GameSceneManager gameSceneManager;
    void Awake()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameSceneManager.ReloadLevel();
        Instantiate(destoryedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
