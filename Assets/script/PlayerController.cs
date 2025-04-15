using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 10f;

    private bool isFacingRight = true;
    Animator anim;
    
    void Start()
    {
    anim = GetComponent<Animator>(); 
    }

    void Update()
{
    float horizontal = 0.0f;
    if (Keyboard.current.aKey.isPressed) {
        horizontal = -1.0f;
        anim.SetBool("jalan",true);
    } else if (Keyboard.current.dKey.isPressed) {
        horizontal = 1.0f;
        anim.SetBool("jalan",true);
    }else{
        anim.SetBool("jalan",false);
    }

    
    float vertical = 0.0f;
    if (Keyboard.current.spaceKey.isPressed) {
        vertical = 2.0f;
        anim.SetBool("jalan",false);
    }

    Vector2 position = transform.position;
    position.x += horizontal * movementSpeed * Time.deltaTime;
    position.y += vertical * movementSpeed * Time.deltaTime;

    transform.position = position;

    if (horizontal < 0 && isFacingRight) 
    {
        Flip();
    }
    else if (horizontal > 0 && !isFacingRight) 
    {
        Flip();
    }
}


    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0,180,0);
    }
}
