 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomePageManager : MonoBehaviour
{

    public TMP_Text tmName;
    public GameObject AboutPanel;
    public static bool startFromSnow;

    public AudioClip clickSound;

    public void EnableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutPanel.gameObject.SetActive(true);
    }

    public void DisableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutPanel.gameObject.SetActive(false);
    }

    public void GoToGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        startFromSnow = false;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToSnow()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        startFromSnow = true;
        Debug.Log("Starting from snow" + startFromSnow);
        SceneManager.LoadScene("GameScene");
    }

    public void GoToSettings()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene("SettingsScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
            tmName.text = "Welcome " + PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
