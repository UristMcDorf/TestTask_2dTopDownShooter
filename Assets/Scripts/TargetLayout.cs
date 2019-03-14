using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLayout : MonoBehaviour
{
    [SerializeField]
    float lifetime = 0f;

    float currentLifetime = 0f;

    List<SpriteRenderer> spriteRenderers = null;

    void Start()
    {
        currentLifetime = lifetime;
        spriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;

        if(currentLifetime < 0)
        {
            Destroy(gameObject);
        }

        Color tmpColor = Color.white;
        foreach(SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if(spriteRenderer != null)
            {
                tmpColor = spriteRenderer.color;
                tmpColor.a = currentLifetime / lifetime;
                spriteRenderer.color = tmpColor;
            }
        }
    }
}
