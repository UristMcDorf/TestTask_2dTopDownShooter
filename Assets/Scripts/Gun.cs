using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If I added more weird gun types I'd probably split this off into multiple components.

public class Gun : MonoBehaviour
{
    [SerializeField]
    Sprite _displaySprite = null;
    public Sprite DisplaySprite
    {
        get
        {
            return _displaySprite;
        }
    }

    [SerializeField]
    int initialPopulate = 0;

    [SerializeField]
    Bullet bulletPrefab = null;

    [SerializeField]
    int bulletsPerShot = 0;

    [SerializeField]
    float startSpread = 0f;

    // Per sec
    [SerializeField]
    float aimRate = 0f;

    [SerializeField]
    float minSpread = 0f;

    [SerializeField]
    float cooldownAfterShot = 0f;

    float _currentSpread = 0f;
    public float CurrentSpread
    {
        get
        {
            return _currentSpread;
        }
    }

    float cooldown = 0f;

    Stack<Bullet> bullets = new Stack<Bullet>();

    void Start()
    {
        for(int i = 0; i < initialPopulate; i++)
        {
            MakeBullet();
        }
    }

    void Update()
    {
        if(cooldown > 0)
        {
            cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        }
        if(_currentSpread > 0)
        {
            _currentSpread = Mathf.Max(minSpread, _currentSpread - Time.deltaTime * aimRate);
        }
    }

    // TODO: Visualise
    public void Aim()
    {
        _currentSpread = startSpread;
    }

    public void Shoot()
    {
        if(cooldown > 0)
        {
            return;
        }
        while(bullets.Count < bulletsPerShot)
        {
            MakeBullet();
        }

        for(int i = 0; i < bulletsPerShot; i++)
        {
            Bullet firedBullet = bullets.Pop();
            firedBullet.Fire(_currentSpread);
        }
        cooldown = cooldownAfterShot;
        _currentSpread = 0f;
    }

    void MakeBullet()
    {
        Bullet newBullet = GameObject.Instantiate<Bullet>(bulletPrefab, transform.position, transform.rotation);
        bullets.Push(newBullet);
        newBullet.SetParent(this);
        newBullet.transform.SetParent(transform);
    }
}
