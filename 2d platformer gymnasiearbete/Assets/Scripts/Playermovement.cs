using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {
    public float movementspeed;
    public Rigidbody2D rb;
    private bool _isGrounded = true;
    public float feetRadius = 0.5F;
    public float jumpforce = 20F;
    public LayerMask groundLayers;
    public Transform feet;
    float mx;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal") * movementspeed;

        if (Input.GetButtonDown("Jump") && _isGrounded){
            Jump();
        }
        else if (!_isGrounded && rb.velocity.y == 0){
            _isGrounded = true;
        }
    }
    private void FixedUpdate(){
        Vector2 movement = new Vector2(mx, rb.velocity.y);

        rb.velocity = movement;
    }
    void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpforce);

        rb.velocity = movement;
        _isGrounded = false;
    }
    public bool IsGrounded(){
        //Vector2 playerposition = gameObject.transform.position; 
        Collider2D groundcheck = Physics2D.OverlapCircle(feet.position, feetRadius, groundLayers);

        if (groundcheck != null)
        {
            return true;
        }
        return false;
    }
}
