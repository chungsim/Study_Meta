using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weapomPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 konokback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private bool isRight = true;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(movementDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    protected virtual void Movement(Vector2 direction)
    {
        direction = direction * 5;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += konokback;
        }

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        if (direction.x > 0)
        {
            characterRenderer.flipX = false;
            rotateCustomChilds();
        }
        else if (direction.x < 0)
        {
            characterRenderer.flipX = true;
            rotateCustomChilds();
        }


        if (weapomPivot != null)
        {
            //weapomPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        konokback = -(other.position - transform.position).normalized * power;
    }

    private void rotateCustomChilds()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        if(allChildren.Length > 0 && characterRenderer.flipX == isRight)
        {
            foreach(Transform child in allChildren)
            {
                if (child.gameObject.CompareTag("Custom"))
                {
                    Vector3 revPos = new Vector3(child.localPosition.x * -1f, child.localPosition.y, child.localPosition.z);
                    child.localPosition = revPos;
                    child.GetComponent<SpriteRenderer>().flipX = !child.GetComponent<SpriteRenderer>().flipX;
                    child.rotation = Quaternion.Euler(0, 0, -child.eulerAngles.z);
                    isRight = !isRight;
                }
            }
        } 
    }

}
