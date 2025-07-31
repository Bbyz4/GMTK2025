using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableBlockBehaviour : MonoBehaviour
{
    [SerializeField] private int toggledGroupID;
    [SerializeField] private bool isActiveFromStart;

    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();

        box.enabled = isActiveFromStart;
    }

    public int GetToggledGroupID()
    {
        return toggledGroupID;
    }

    public void Switch(bool shouldBeActive)
    {
        box.enabled = shouldBeActive;
    }
}
