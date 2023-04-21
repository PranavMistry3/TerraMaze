using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneManager : MonoBehaviour
{

    public TMP_Text tmScore;
    public TMP_Text tmHighScore;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmName;
    public GameObject player;
    public GameObject endGameButton;
    public GameObject quitButton;

    public GameObject checkpointCanvas;
    public GameObject gameOverCanvas;

    private int currentTime;
    private int currentScore;
    private int highScore;
    public AudioClip clickSound;
    public AudioClip explosionSound;
    public AudioClip chimeSound;
    public AudioSource gameMusic;
    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public AudioClip musicClip3;

    public AudioClip checkpointSound;
    private int TIME_INCREMENT = 30;
    private int SCORE_INCREMENT = 30;
    // SettingsSceneManager sm = new SettingsSceneManager();


    public void GoHome()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        HomePageManager.startFromSnow = false;
        Debug.Log("Game Finished");
        SceneManager.LoadScene("HomeScene");
    }

    public void Quit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        currentScore = 0;
        HomePageManager.startFromSnow = false;
        Debug.Log("Quit pressed");
        SceneManager.LoadScene("HomeScene");
    }

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("CheckPointHit", 0);

        if (HomePageManager.startFromSnow == true)
        {
            player.transform.position = new Vector3((float)201.3175, (float)5.91801, (float)507.6552);
        }
        Debug.Log("Game Begins");
        // gameMusic.clip = musicClip2;
       // Debug.Log("SA" + sm.musicNum);
        if (SettingsSceneManager.musicNum == 1)
        {
            gameMusic.clip = musicClip1;
        }
        else if (SettingsSceneManager.musicNum == 2)
        {
            gameMusic.clip = musicClip2;
        }
        else if (SettingsSceneManager.musicNum == 3)
        {
            gameMusic.clip = musicClip3;
        }
        gameMusic.Play(0);

        currentTime = 10;

        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;

        if (PlayerPrefs.HasKey("UserName"))
            tmName.text = PlayerPrefs.GetString("UserName");

        tmHighScore.text = "High Score: " + highScore;

        StartCoroutine("LoseTime");
    }

    private void UpdateLabels()
    {
        tmScore.text = "Score: " + currentScore;
        tmTimeLeft.text = "Time: " + currentTime;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
            currentScore++;

            if (currentTime % 6 == 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(explosionSound);
            }

            if (currentScore % 10 == 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(chimeSound);
            }

            if (player.transform.position.x <= 64 && player.transform.position.z <= 93)
                break;

            if (PlayerPrefs.HasKey("CheckPointHit"))
            {
                if(PlayerPrefs.GetInt("CheckPointHit") == 1)
                {
                    checkpointCanvas.SetActive(true);
                    GameObject.Find("CheckPointCanvas").GetComponent<PanelFader>().FadeOut();
                    currentTime += TIME_INCREMENT;
                    currentScore += SCORE_INCREMENT;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(checkpointSound);
                    PlayerPrefs.SetInt("CheckPointHit", 0);

                    
                }

            }


            if (currentTime <= 0)
                break;
        }

        quitButton.SetActive(false);
        endGameButton.SetActive(true);
        GameOver();
    }

    private void GameOver()
    {
        if (highScore > currentScore || highScore == 0)
            PlayerPrefs.SetInt("HighScore", currentScore);
        gameOverCanvas.SetActive(true);

        if(currentTime <= 0)
            player.GetComponent<Animator>().SetTrigger("dyingtrigger");

        GameObject.Find("GameOverCanvas").GetComponent<PanelFader>().FadeIn();
        if (PlayerPrefs.GetInt("CheckPointHit") == 1)
        {
            PlayerPrefs.SetInt("CheckPointHit", 0);
        }
        Debug.Log("Game OVer");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabels();
    }
}
