using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer = null;
    [SerializeField]
    Collider2D collider = null;
    [SerializeField]
    float initialSpeed = 0f;
    bool isFired = false;
    Gun parent = null;

    void Update()
    {
        if(isFired)
        {
            transform.Translate(Vector3.up * Time.deltaTime * initialSpeed);
        }
    }

    public void Fire()
    {
        spriteRenderer.enabled = true;
        collider.enabled = true;
        isFired = true;
        transform.SetParent(null);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Target target = other.gameObject.GetComponent<Target>();

        if(target != null)
        {
            ReturnToParent();
            target.Hit();
            return;
        }
    }

    void ReturnToParent()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;
        isFired = false;
        transform.SetParent(parent.transform);
    }

    public void SetParent(Gun gun)
    {
        parent = gun;
    }
}
