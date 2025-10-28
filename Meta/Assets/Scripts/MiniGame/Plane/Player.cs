using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;

    public bool isPaused = false;

    float deathCooldown = 0f;
    
    bool isFlap = false;

    public bool godMode = false;

    PlaneGameManager planeGameManager;
    
    void Start()
    {
        planeGameManager = PlaneGameManager.InstancePlaneGame;

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                    if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButtonDown(0))
                    {
                        //planeGameManager.RestartGame();
                    }
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
            
        if (isPaused)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.gravityScale = 0;
            isFlap = false;
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        Debug.Log(velocity.x);

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        _rigidbody.velocity = velocity;
        
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        animator.SetBool("IsDie", true);
        isDead = true;
        deathCooldown = 1f;
        planeGameManager.GameOver();
    }

    public void RestartGame()
    {
        if (deathCooldown <= 0)
        {
            planeGameManager.RestartGame();
        }
    }

    public void ExitGame()
    {
        if (deathCooldown <= 0)
        {
            planeGameManager.ExitGame();
        }
    }
    
    public void PausePlayerToggle()
    {
        if (!isPaused)
        {
            _rigidbody.gravityScale = 0f;
            isPaused = true;
        }

        if (isPaused)
        {
            _rigidbody.gravityScale = 1f;
            isPaused = false;
        }
    }
}
