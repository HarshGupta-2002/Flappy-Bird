using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoretext;
    private int score;
    void Start()
    {
        score= 0;
    }

    // Update is called once per frame
    public void AddScore() {
        score+=1;
        scoretext.text = score.ToString();
    }
}
