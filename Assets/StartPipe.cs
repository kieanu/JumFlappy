using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPipe : MonoBehaviour
{
    private float speed = 1.6f;
    private bool detection = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (detection)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        Destroy(gameObject, 10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detection = true;
        }
    }
}
