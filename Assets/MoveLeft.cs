using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 1.6f + 0.05f*(Score.score/5);
        if(speed >= 2.2f)
        {
            speed = 2.2f;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
