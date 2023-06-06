using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPlayerDestroy : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bird.soundToggle = false;
            gameManager.GameOver();
        }
    }
}
