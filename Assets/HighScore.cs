using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private UnityEngine.UI.Text TextUI;
    private float R;
    private float G;
    private float B;
    private bool neon;

    // Start is called before the first frame update
    void Start()
    {
       TextUI = GetComponent<UnityEngine.UI.Text>();
        neon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (neon)
        {
            G += 0.01f;
            if (G > 0.99f)
            {
                B += 0.01f;
                if (B > 0.99f)
                {
                    R += 0.01f;
                    if (R > 0.99f)
                    {
                        neon = false;
                    }
                }
            }
        }
        else
        {
            G -= 0.01f;
            if (G < 0.01f)
            {
                B -= 0.01f;
                if (B < 0.01f)
                {
                    R -= 0.01f;
                    if (R < 0.01f)
                    {
                        neon = true;
                    }
                }
            }
        }



        if (gameOverCanvas.activeSelf)
        {
            TextUI.text = "BEST : " + PlayerPrefs.GetInt("score").ToString();
            TextUI.color = new Vector4(R,G,B, 1.0f);
        }


        
        
    }
}
