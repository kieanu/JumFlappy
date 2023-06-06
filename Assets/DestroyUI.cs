using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUI : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.localPosition.x == 200)
            gameObject.SetActive(false);
    }
}
