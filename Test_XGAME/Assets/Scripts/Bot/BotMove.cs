using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed;
    public GameObject bot;
    

    private void Start()
    {
        spawn(true);
    }
    private void Update()
    {
        
        spawn(true);
    }
    public void spawn(bool move)
    {
        bot.transform.Translate(Vector3.right * Time.deltaTime * speed * -1);

        /*
        if (bot.transform.position.x > -4.4f)
        {
            bot.transform.Translate(Vector3.right * Time.deltaTime * speed * -1);
            Debug.Log("1");

        }

        if (bot.transform.position.x < 4f)
        {
            bot.transform.Translate(Vector3.right * Time.deltaTime * speed);
            Debug.Log("2");
        }
        */

    }
}
