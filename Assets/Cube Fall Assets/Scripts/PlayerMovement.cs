using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 2f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        float h = Input.GetAxisRaw("Horizontal");
        if(h  > 0)
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        else if(h < 0)
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
