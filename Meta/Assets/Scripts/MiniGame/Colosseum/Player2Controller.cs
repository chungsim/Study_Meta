using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : BaseController
{
    private Camera playerCamera;

    protected override void Start()
    {
        base.Start();
        playerCamera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1;

        float vertical = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1;
        if (Input.GetKey(KeyCode.DownArrow)) vertical = -1;
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = playerCamera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
