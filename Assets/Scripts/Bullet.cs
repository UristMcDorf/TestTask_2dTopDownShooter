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
    [SerializeField]
    float initialSpeedRandom = 0f;
    float speed = 0f;

    bool isFired = false;
    Gun parent = null;

    void Update()
    {
        if(isFired)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    public void Fire(float currentSpread)
    {
        spriteRenderer.enabled = true;
        collider.enabled = true;
        isFired = true;

        transform.SetParent(null);
        transform.Rotate(0, 0, (Random.value - 0.5f) * currentSpread);

        speed = initialSpeed + Random.value * initialSpeedRandom;
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

        if(other.tag == "Obstacle")
        {
            ReturnToParent();
        }
    }

    void ReturnToParent()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;
        isFired = false;
        transform.SetParent(parent.transform);
        transform.rotation = Quaternion.identity;
    }

    public void SetParent(Gun gun)
    {
        parent = gun;
    }
}
