using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField]
    Image currentGunDisplay = null;
    Gun currentGun = null;
    List<Gun> guns = null;

    void Start()
    {
        guns = new List<Gun>(GetComponentsInChildren<Gun>());
        UpdateGun(0);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Aim();
        }
        // Yeah that does mean you can switch while holding LMB; dunno why you would; I'll fix it later
        if(Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
        // Could use GetButtonDown but not worth the effort IMO
        if(Input.GetKeyDown("1"))
        {
            UpdateGun(0);
        }
        if(Input.GetKeyDown("2"))
        {
            UpdateGun(1);
        }
    }

    void Aim()
    {
        currentGun.Aim();
    }

    void Shoot()
    {
        currentGun.Shoot();
    }

    void UpdateGun(int newGun)
    {
        if(currentGun != guns[newGun])
        {
            currentGun = guns[newGun];
            currentGunDisplay.sprite = currentGun.DisplaySprite;
        }
    }
}
