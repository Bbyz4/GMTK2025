using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColliderScaler : MonoBehaviour
{
    [SerializeField] private Vector2 margins;

    void Awake()
    {
        ResizeCollider();
    }

    private void ResizeCollider()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        box.size = sp.size - margins;
    }

}
