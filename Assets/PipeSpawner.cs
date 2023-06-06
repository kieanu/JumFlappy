using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    private float maxTime = 3f;
    private float timer = 0;
    public GameObject pipe;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 2.9f;
        //문제지점    
        /*
        GameObject newPipe = Instantiate(pipe);

        Random.InitState(System.DateTime.Now.Millisecond);
        height = 0.25f * Random.Range(-23.0f, -3.0f) * Time.deltaTime * 60;

        newPipe.transform.position = transform.position + new Vector3(0, height, 0);
        Destroy(newPipe, 8);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0, RandomHeight(), 0);
            Destroy(newPipe, 8);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    float RandomHeight()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        //-8.75f~ 0.25f 까지 
        return 0.25f * Random.Range(-17.0f, 0.0f) * Time.deltaTime * 60;
    }

}
