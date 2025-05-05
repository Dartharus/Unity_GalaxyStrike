using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelCoroutine(delay));
    }
    IEnumerator ReloadLevelCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
