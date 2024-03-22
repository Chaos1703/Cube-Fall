using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f , maxX = 2.6f , minY = -5.6f;
    private bool outOfBounds;
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
            temp.x = maxX;
        else if (temp.x < minX)
            temp.x = minX;
        if (temp.y <= minY)
        {
            if(!outOfBounds)
            {
                outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.GameOverSound();
            GameManager.instance.RestartGame();
        }
    }

}
