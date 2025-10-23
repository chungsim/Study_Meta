using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;

    public float offsetX;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GameObject.Find("MainCamera").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newX = target.position.x + offsetX;
        float newY = target.position.y + offsetY;

        transform.position = new Vector3(newX, newY, -10);
    }
}
