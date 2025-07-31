using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float FollowSpeed;
    [SerializeField] private GameObject target;
    [SerializeField] private float height;


    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + height, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    public void ChangeTarget(GameObject newTarget)
    {
        target = newTarget;

        //Snap
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + height, -10f);
    }
}