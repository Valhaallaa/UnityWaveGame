using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelSelect : MonoBehaviour
{
    // sime menu script containing functions for the play button as well as restting the playerprefs back to what they were orignally
    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void ResetStats()
    {
        PlayerPrefs.SetInt("PlayerHealth", 4);
        PlayerPrefs.SetInt("PlayerDamage", 1);
        PlayerPrefs.SetInt("PlayerScore", 0);
    }

    public void QuitApp() {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerHealth", 4);
        PlayerPrefs.SetInt("PlayerDamage", 1);
        PlayerPrefs.SetInt("PlayerScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
