using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f , boundY = 6f;
    public bool isbreakable, isSpike, movingPlatformLeft , movingPlatformRight , isPlatform;
    private Animator anim;

    void Awake()
    {
        if (isbreakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Move();
    }

    void Move(){
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            if(isSpike)
            {
                other.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isbreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if(isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(movingPlatformLeft)
            {
                other.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if(movingPlatformRight)
            {
                other.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }

}
