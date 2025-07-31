using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private int toggledGroupID;
    [SerializeField] private bool setActive;

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
