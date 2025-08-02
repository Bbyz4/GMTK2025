using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableBlockBehaviour : MonoBehaviour
{
    [SerializeField] private int toggledGroupID;
    [SerializeField] private bool isActiveFromStart;

    [SerializeField] private Sprite activeBlockSprite;
    [SerializeField] private Sprite inactiveBlockSprite;

    private SpriteRenderer sr;

    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();

        box.enabled = isActiveFromStart;

        sr = GetComponent<SpriteRenderer>();

        ChangeSprite(isActiveFromStart);    
    }

    void Start()
    {
        if (ColorManager.Instance.switchableBlockColors.Count > toggledGroupID)
        {
            sr.color = ColorManager.Instance.switchableBlockColors[toggledGroupID];
        }
    }

    public int GetToggledGroupID()
    {
        return toggledGroupID;
    }

    public void Switch(bool shouldBeActive)
    {
        box.enabled = shouldBeActive;

        ChangeSprite(shouldBeActive);
    }

    private void ChangeSprite(bool shouldBeActive)
    {
        sr.sprite = shouldBeActive ? activeBlockSprite : inactiveBlockSprite;
    }
}
