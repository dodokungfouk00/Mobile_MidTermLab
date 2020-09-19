using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public NumberControl[] _listNumbers;
    Image m_sprite;
    // Use this for initialization
    void Start()
    {
        _listNumbers = GetComponentsInChildren<NumberControl>();
    }
    public void UpdateScore(int Score)
    {
        for (int i = 0; i < _listNumbers.Length; i++)
        {
            _listNumbers[i].UpdateNumber(Score);
        }
    }

}
