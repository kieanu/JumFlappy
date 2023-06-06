using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{

    //public string SceneToLoad;

    // Update is called once per frame
    private int ClickCount = 0;
    void Update()
    {
        /* press to start 
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
//            if (SceneManager.GetActiveScene().name == "Start")
//                Application.Quit();
//            SceneManager.LoadScene("Start");
            Application.Quit();

        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }
}
