using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isAudio == true && audioSource.isPlaying == false)
            audioSource.Play();
        if (GameManager.isAudio == false && audioSource.isPlaying == true)
            audioSource.Stop();
    }
}
