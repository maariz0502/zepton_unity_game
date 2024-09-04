using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float deadZone = -10;
    // Start is called before the first frame update
    void Start()
    {
        float randNum = Random.Range(0.6f, 1);
        Vector3 newScale = new Vector3(randNum, randNum, 1);
        transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
