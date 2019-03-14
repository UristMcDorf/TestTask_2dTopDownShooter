using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    bool isHit = false;

    public void Hit()
    {
        // Prevent possible multihits
        if(isHit)
        {
            return;
        }
        isHit = true;
        ScoreController.Instance.UpdateScore(score);
        Destroy(gameObject);
    }
}
