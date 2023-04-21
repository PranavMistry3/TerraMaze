using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsSceneManager : MonoBehaviour
{

    public TMP_InputField inputName;
    public AudioClip clickSound;
    public static int musicNum;
    public GameObject MusicPanel;
    public void ResetHighScore()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void EnableMusicPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        MusicPanel.gameObject.SetActive(true);
    }

    public void DisableMusicPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        MusicPanel.gameObject.SetActive(false);
    }

        public void GoHome()
    {
        Debug.Log("SBCD" + musicNum);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetString("UserName", inputName.text);
        SceneManager.LoadScene("HomeScene");
        
    }

    public void ChangeMusic1()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        musicNum = 1;
        Debug.Log("SB" + musicNum);
    }

    public void ChangeMusic2()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        musicNum = 2;
        Debug.Log("SC" + musicNum);
    }

    public void ChangeMusic3()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        musicNum = 3;
        Debug.Log("SD" + musicNum);
    }



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
            inputName.text = PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
