using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    private float defaultPlayerScale;
    private PlayerMovement thisMovement;

    void Awake()
    {
        defaultPlayerScale = transform.localScale.x;
        thisMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        transform.localScale = new Vector3(thisMovement.facingRight ? defaultPlayerScale : -defaultPlayerScale, transform.localScale.y, transform.localScale.z);  
    }
}
