using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}
