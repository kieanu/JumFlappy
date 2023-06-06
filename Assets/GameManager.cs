using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;
    public GameObject panelCanvas;
    public GameObject other;

    private int highScore = 0;

    static public bool isAudio = false;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
    }


    // Update is called once per frame
    public void GameOver()
    {
        highScore = Score.score;
        if (PlayerPrefs.GetInt("score") < highScore)
        {
            PlayerPrefs.SetInt("score", highScore);
            PlayerPrefs.Save();
        }

        gameOverCanvas.SetActive(true);
        isAudio = false;
        Time.timeScale = 0;

        // 광고
        other.GetComponent<AdMobManager>().ShowInterstitialAd();
    }
    public void detect()
    {
        panelCanvas.SetActive(false);
        Time.timeScale = 1;
        isAudio = true;
        scoreCanvas.SetActive(true);
        Destroy(panelCanvas);
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
