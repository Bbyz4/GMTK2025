using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private int toggledGroupID;
    [SerializeField] private bool setActive;

    [SerializeField] private List<Sprite> visualSprites;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (visualSprites.Count >= 2)
        {
            sr.sprite = visualSprites[setActive ? 1 : 0];
        }
    }

    void Start()
    {
        if (ColorManager.Instance.switchableBlockColors.Count > toggledGroupID)
        {
            sr.color = ColorManager.Instance.switchableBlockColors[toggledGroupID];
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] togglableBlocks = GameObject.FindGameObjectsWithTag("TogglableBlock");

            foreach (GameObject go in togglableBlocks)
            {
                TogglableBlockBehaviour tbb = go.GetComponent<TogglableBlockBehaviour>();

                if (tbb.GetToggledGroupID() == toggledGroupID)
                {
                    tbb.Switch(setActive);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
