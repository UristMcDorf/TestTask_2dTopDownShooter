using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    Collider2D collisionTester = null;

    [SerializeField]
    List<TargetLayout> targetLayouts = null;
    [SerializeField]
    float timeBetweenSpawns = 0f;

    [SerializeField]
    float minx = 0f;
    [SerializeField]
    float maxx = 0f;
    [SerializeField]
    float miny = 0f;
    [SerializeField]
    float maxy = 0f;

    float timeSinceLastSpawn = 0f;

    void Start()
    {
        // I don't have a game controller so might as well put this here.
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= timeBetweenSpawns)
        {
            TargetLayout layoutToSpawn = targetLayouts[Random.Range(0, targetLayouts.Count)];

            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.identity;

            //Couldn't make preliminary collision detection work yet
            //do{
                float x = Random.Range(minx, maxx);
                float y = Random.Range(miny, maxy);
                float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg - 90;

                position = new Vector3(x, y, 0);
                rotation = Quaternion.AngleAxis(angle, Vector3.forward);
/*
                Collider2D test = Instantiate<Collider2D>(collisionTester, position, rotation);
                RaycastHit2D[] results = new RaycastHit2D[0];
                
                // If it doesn't have any collisions
                if(test.Cast(Vector2.up, results, 0.1f) == 0)
                {
                    Destroy(test.gameObject);
                    break;
                }
                Destroy(test.gameObject);
            } while(true);*/

            Instantiate<TargetLayout>(layoutToSpawn, position, rotation);
            
            timeSinceLastSpawn = 0f;
        }
    }
}
