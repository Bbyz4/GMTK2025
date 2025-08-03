using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    private bool isExitAllowed;

    void Awake()
    {
        isExitAllowed = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isExitAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isExitAllowed = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isExitAllowed)
        {
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            GameManager.Instance.CompleteLevel();
        }
    }
}
