using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    int initialPopulate = 0;
    [SerializeField]
    Bullet bulletPrefab = null;
    Stack<Bullet> bullets = new Stack<Bullet>();
    void Start()
    {
        for(int i = 0; i < initialPopulate; i++)
        {
            MakeBullet();
        }
    }

    public void TryShoot()
    {
        if(bullets.Count == 0)
        {
            MakeBullet();
        }
        Bullet firedBullet = bullets.Pop();
        firedBullet.Fire();
    }

    void MakeBullet()
    {
        Bullet newBullet = GameObject.Instantiate<Bullet>(bulletPrefab, transform.position, transform.rotation);
        bullets.Push(newBullet);
        newBullet.SetParent(this);
        newBullet.transform.SetParent(transform);
    }
}
