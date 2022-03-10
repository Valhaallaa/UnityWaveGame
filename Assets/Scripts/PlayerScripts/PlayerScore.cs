using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI PlayerScoreValue;
    // this script keeps track of the player score for use within the UI and as well as updating the PlayerPrefs

    public int IncScore = 0;

    private int TotalScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        IncScore = PlayerPrefs.GetInt("PlayerScore");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScoreValue.text  = " " + IncScore.ToString("F0");
        
        PlayerPrefs.SetInt("PlayerScore", IncScore);
    }
}
