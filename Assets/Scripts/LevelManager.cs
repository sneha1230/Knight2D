using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadLevelTimer;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("GoToMenuScene", autoLoadLevelTimer);
        }

    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
