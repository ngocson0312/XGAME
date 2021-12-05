using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed ;
    private void Update()
    {
        transform.position += Vector3.back * speed *Time.deltaTime;
    }
}
