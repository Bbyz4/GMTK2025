using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 game manager!");
        }

        Instance = this;
    }

    public void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
