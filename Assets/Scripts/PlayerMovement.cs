using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    Animator myAnimator;
    UnityEngine.Vector2 moveInput;
    Rigidbody2D rb;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<UnityEngine.Vector2>();
    }

    void Run()
    {
        UnityEngine.Vector2 playerVelocity = new UnityEngine.Vector2(moveInput.x * runSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
    }
    void FlipSprite()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new UnityEngine.Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);

        }

        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

}
