using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera playerCamera;

    [SerializeField] private bool isRidding;
    [SerializeField] private float riddingSpeed;

    protected override void Start()
    {
        base.Start();
        playerCamera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isRidding)
            {
                OffRide();
                PlayerCustomManager.Instance.SetRide(0);
            }
            else
            {
                GetRide(0.5f);
                PlayerCustomManager.Instance.SetRide(1);
            }
        }
    }

    protected override void Movement(Vector2 direction)
    {
        if (isRidding)
        {
            direction = direction * 5;
            _rigidbody.velocity = direction * (riddingSpeed + 1f);
        }
        else
        {
            base.Movement(direction);
        }
    }

    public void GetRide(float speed)
    {
        isRidding = true;
        riddingSpeed = speed;
    }
    
    public void OffRide()
    {
        isRidding = false;
        riddingSpeed = 0f;
    }
}
