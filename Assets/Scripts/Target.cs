using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    public void Hit()
    {
        Debug.Log(string.Format("{0} hit!", name));
        ScoreController.Instance.UpdateScore(score);
        Destroy(gameObject);
    }
}
