using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickupBehaviour : MonoBehaviour
{
    [SerializeField] private int abilityID;

    [SerializeField] private List<Sprite> visualSprites;

    void Awake()
    {
        if (abilityID < 0 || abilityID >= visualSprites.Count)
        {
            return;
        }

        GetComponent<SpriteRenderer>().sprite = visualSprites[abilityID];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.UnlockAbility(abilityID);

            Destroy(this.gameObject);
        }
    }
}
