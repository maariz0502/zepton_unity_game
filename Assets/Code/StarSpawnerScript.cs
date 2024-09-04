using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;
public class StarSpawnerScript : MonoBehaviour
{
    public GameObject star;
    public float interval = 2f;
    public float timer = 0;
    private float x_min = -8.5f;
    private int x_max = 9;

    // Start is called before the first frame update
    void Start()
    {   
        // Spawn between 5-8 stars
        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            float x = Random.Range(-8.5f, 9);   // stars should be 
            float y = transform.position.y;
            spawnStar(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > interval)
        {
            for (int i = 0; i < Random.Range(5, 8); i++)
            {
                float x = Random.Range(x_min, x_max);
                float y = transform.position.y + Random.Range(-0.5f, 0.5f);
                spawnStar(x, y);
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void spawnStar(float x, float y) {
        Instantiate(star, new Vector3(x, y, transform.position.z), Quaternion.identity);
    }
}
