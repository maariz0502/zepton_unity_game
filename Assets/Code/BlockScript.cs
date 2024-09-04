using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;


public class BlockScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject extendPaddle;
    private bool actBuff;
    public GameObject Paddle;
    PaddleScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = Paddle.GetComponent<PaddleScript>();
        actBuff = script.activeBuff;
        sprite = GetComponent<SpriteRenderer>();
        int randColor = Random.Range(0, 5);
        Color[] colors = { Color.red, Color.blue, Color.green, Color.magenta, Color.yellow };
        sprite.color = colors[randColor];
    }

    // Update is called once per frame
    void Update()
    {
        actBuff = script.activeBuff;
    }

    public void DropItem(float x, float y) {
        int randomNum = Random.Range(6,7); // 1-11
        if (randomNum > 5) {
            //drop an item
            switch (randomNum)
            {
                case 6:
                    if (!actBuff)
                        Instantiate(extendPaddle, new Vector3(x, y, 0), Quaternion.identity);
                    break;
                case 7:
                    if (!actBuff)
                        Instantiate(extendPaddle, new Vector3(x, y, 0), Quaternion.identity);
                    break;
            }
            Debug.Log(randomNum);
        }
    }
}
