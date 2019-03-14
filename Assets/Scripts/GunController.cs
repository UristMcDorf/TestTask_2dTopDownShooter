﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField]
    Image currentGunDisplay = null;
    [SerializeField]
    SpriteRenderer sightsLeft = null;
    [SerializeField]
    GameObject sightsLeftPivot = null;
    [SerializeField]
    SpriteRenderer sightsRight = null;
    [SerializeField]
    GameObject sightsRightPivot = null;

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

        UpdateSightsPosition();
    }

    void Aim()
    {
        currentGun.Aim();

        sightsLeft.enabled = true;
        sightsRight.enabled = true;
    }

    void Shoot()
    {
        currentGun.Shoot();

        sightsLeft.enabled = false;
        sightsRight.enabled = false;
    }

    // Should probably make some checks so it doesn't update constantly but eh.
    void UpdateSightsPosition()
    {
        if(currentGun != null)
        {
            sightsLeftPivot.transform.localRotation = Quaternion.AngleAxis(- (currentGun.CurrentSpread / 2), Vector3.forward);
            sightsRightPivot.transform.localRotation = Quaternion.AngleAxis(currentGun.CurrentSpread / 2, Vector3.forward);
        }
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
