using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLayout : MonoBehaviour
{
    [SerializeField]
    float lifetime = 0f;

    void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
