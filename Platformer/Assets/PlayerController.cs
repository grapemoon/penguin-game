using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private bool isGrounded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
	    Debug.Log("Jump!");
        }

        float direction = Input.GetAxis("Horizontal");
        Move(direction);
       

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("JumpTrigger");
        }
    }

    private void Move(float direction)
    {
	Debug.Log("Move!");
        float speed = movementSpeed * direction;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        animator.SetFloat("MovementSpeed", Mathf.Abs(speed));
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
