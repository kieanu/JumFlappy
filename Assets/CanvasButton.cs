using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton : MonoBehaviour
{
    public void Play()
    {
        if (GetComponentInParent<CanvasGroup>().alpha == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
