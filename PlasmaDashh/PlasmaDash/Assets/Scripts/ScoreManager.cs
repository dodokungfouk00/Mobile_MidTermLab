using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score,HighScore;
    private void Awake()
    {
        instance=this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore()
    {
        score++;
        UpdateHighScore();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.instance.AddScore();
        Destroy(other.gameObject);
    }
    public void UpdateHighScore()
    {
        if(score>HighScore)
        {
            HighScore=score;
        }
    }
    public void ResetScore()
    {
        score=0;
    }
    
}
