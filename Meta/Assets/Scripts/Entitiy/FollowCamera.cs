using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{

    public Transform target;

    [SerializeField] private Tilemap tileMap;

    public float offsetX;
    public float offsetY;

    private Vector2 minPosition;
    private Vector2 maxPosition;

    private Vector3 tilemapOffset = new Vector3(0.5f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("MainCamera").transform;
        }
        
        if(tileMap != null)
        {
            Bounds bounds = tileMap.localBounds;

            minPosition = bounds.min - tilemapOffset - new Vector3(0f, 1f, 0f);
            maxPosition = bounds.max - tilemapOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float newX = target.position.x + offsetX;
        //float newY = target.position.y + offsetY;

        Vector3 desiredPosition = target.position + new Vector3(offsetX, offsetY, 0f);

        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        float clampX = Mathf.Clamp(desiredPosition.x, minPosition.x + camWidth, maxPosition.x - camWidth);
        float clampY = Mathf.Clamp(desiredPosition.y, minPosition.y + camHeight, maxPosition.y - camHeight);

        Vector3 clamped = new Vector3(clampX, clampY, desiredPosition.z);
        transform.position = new Vector3(clampX, clampY, -10);
    }
}
