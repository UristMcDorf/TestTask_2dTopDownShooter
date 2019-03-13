using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Removing when I handle gun switching; test purposes for now
    [SerializeField]
    Gun currentGun = null;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        currentGun.TryShoot();
    }
}
