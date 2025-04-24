using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreBoard;
    void Awake()
    {
        scoreBoard = FindFirstObjectByType<Scoreboard>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            DestroyEnemy();
        }
    }
    void DestroyEnemy()
    {
        scoreBoard.IncreaseScore(scoreValue);
        Instantiate(destoryedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
