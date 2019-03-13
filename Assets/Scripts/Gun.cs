using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float currentSpread = 0f;
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
        if(currentSpread > 0)
        {
            currentSpread = Mathf.Max(minSpread, currentSpread - Time.deltaTime * aimRate);
        }
    }

    // TODO: Visualise
    public void Aim()
    {
        currentSpread = startSpread;
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
            firedBullet.Fire(currentSpread);
        }
        cooldown = cooldownAfterShot;
        currentSpread = 0f;
    }

    void MakeBullet()
    {
        Bullet newBullet = GameObject.Instantiate<Bullet>(bulletPrefab, transform.position, transform.rotation);
        bullets.Push(newBullet);
        newBullet.SetParent(this);
        newBullet.transform.SetParent(transform);
    }
}
