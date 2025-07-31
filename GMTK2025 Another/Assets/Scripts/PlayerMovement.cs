/*
    Basic 2D movement script. Includes:
        - Moving sideways and jumping
        - Gliding
        - Multiple airjumps
        - Dashing sideways
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    //Serialized parameters

    [Header("BASIC PARAMETERS")]
    [SerializeField] private float speed = 13f;
    [SerializeField] private float groundJumpForce = 15f;
    [SerializeField] private float defaultGravityScale = 5f;
    [SerializeField] private LayerMask groundLayer;

    [Header("AIR JUMPING")]
    [SerializeField] private bool canAirJump = true;
    [SerializeField] private int airJumpAmount = 1;
    [SerializeField] private float airJumpForce = 12f;

    [Header("GLIDING")]
    [SerializeField] private bool canGlide = true;
    [SerializeField] private float glidingSpeed = -2f;

    [Header("DASHING")]
    [SerializeField] private bool canDash = true;
    [SerializeField] private float dashingSpeed = 35f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dahsingCooldown = 0.5f;
    [SerializeField] private int airDashAmount = 1;


    //Useful parameters for other cooperating scripts
    private float horizontalInput;
    private bool isHorizontalKeyPressed;
    private int airJumps = 0;
    private int airDahses = 0;
    [HideInInspector] public bool facingRight = true;

    [HideInInspector] public bool isDashing = false;
    private Vector2 currentDashVector;
    private float currentDashTime;
    private float currentDashCooldown;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    //Check if the player is holding on with a grappling hook
    //Check if the player is dashing
    //If none of those 2 are true, respond to the player's input
    void Update()
    {
        if (isDashing)
        {
            rb.velocity = currentDashVector;

            currentDashTime += Time.deltaTime;

            if (currentDashTime >= dashingTime)
            {
                EndDash();
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space) && canDash && airDahses < airDashAmount && currentDashCooldown <= 0)
            {
                InitiateDash();
            }

            if (Input.GetKeyDown(KeyCode.W) && (IsGrounded() || canAirJump && (airJumps < airJumpAmount)))
            {
                Jump();
            }
            else if (IsGrounded())
            {
                airJumps = 0;
                airDahses = 0;
            }

            if (canGlide && !IsGrounded() && Input.GetKey(KeyCode.W) && rb.velocity.y <= glidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, glidingSpeed);
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = defaultGravityScale;
            }

            horizontalInput = Input.GetAxis("Horizontal");

            isHorizontalKeyPressed = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);

            horizontalInput = InputResponsivityFunction(horizontalInput, isHorizontalKeyPressed);

            if (horizontalInput != 0)
            {
                if (horizontalInput > 0)
                {
                    facingRight = true;
                }
                else
                {
                    facingRight = false;
                }
            }

            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (currentDashCooldown > 0)
            {
                currentDashCooldown -= Time.deltaTime;
            }
        }
    }

    //This function takes a number between -1 and 1 and return a number between -1 and 1
    private float InputResponsivityFunction(float inputValue, bool isHorizontalKeyPressed)
    {
        return Mathf.Sign(inputValue) * Mathf.Pow(Mathf.Abs(inputValue), (isHorizontalKeyPressed ? 1f / 3f : 3f));
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private void Jump()
    {
        if (!IsGrounded())
        {
            airJumps++;
            rb.velocity = new Vector2(rb.velocity.x, airJumpForce);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, groundJumpForce);
        }
    }

    private void InitiateDash()
    {
        /* Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 dashDirection = mousePos - transform.position;
        dashDirection = dashDirection.normalized * dashingSpeed; 

        currentDashVector = dashDirection;  */

        currentDashVector = new Vector2(dashingSpeed * (facingRight ? 1f : -1f), 0f);

        currentDashTime = 0;
        rb.gravityScale = 0;
        isDashing = true;
    }

    private void EndDash()
    {
        rb.gravityScale = defaultGravityScale;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        currentDashCooldown = dahsingCooldown;
        airDahses++;
        isDashing = false;
    }

    public void SetAbilities(bool[] unlocks)
    {
        if (unlocks.Length < 3)
        {
            return;
        }

        this.canAirJump = unlocks[0];
        this.canGlide = unlocks[1];
        this.canDash = unlocks[2];
    }
}