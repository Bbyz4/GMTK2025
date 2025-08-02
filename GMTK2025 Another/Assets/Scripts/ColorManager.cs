using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public List<Color> switchableBlockColors;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More that 1 GameManager instance!");
        }

        Instance = this;
    }
}
