using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnimation : MonoBehaviour
{
    public Animator Firstanim;
    public Animator Secondanim;
    public Animator Thirdanim;
    private float Animspeed = 100f;
    // Start is called before the first frame update

    private void Skip()
    {
        Firstanim.speed = Animspeed;
        Secondanim.speed = Animspeed;
        Thirdanim.speed = Animspeed;
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        Skip();
    }
    void Update()
    {
        
    }
}
