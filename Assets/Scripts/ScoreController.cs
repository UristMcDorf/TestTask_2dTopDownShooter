using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    static ScoreController _instance = null;
    public static ScoreController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ScoreController>();
            }
            return _instance;
        }
    }

    [SerializeField]
    Text text = null;

    int score = 0;

    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore(int change = 0)
    {
        score += change;

        text.text = score.ToString();
    }
}
