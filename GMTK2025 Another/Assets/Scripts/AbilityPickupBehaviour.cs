using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickupBehaviour : MonoBehaviour
{
    [SerializeField] private int abilityID;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.UnlockAbility(abilityID);

            Destroy(this.gameObject);
        }
    }
}
