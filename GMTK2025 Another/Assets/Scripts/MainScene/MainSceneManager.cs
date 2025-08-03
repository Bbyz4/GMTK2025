using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetMouseButtonDown(0) || !EventSystem.current.IsPointerOverGameObject())
            {
                if (!Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
