using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCameraPlane : MonoBehaviour
{
    public Transform target;

    public float offsetX;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("MainCamera").transform;
        }
    }

    void Update()
    {
        float newX = target.position.x + offsetX;
        //float newY = target.position.y + offsetY;

        transform.position = new Vector3(newX, transform.position.y, -10);
    }
}

