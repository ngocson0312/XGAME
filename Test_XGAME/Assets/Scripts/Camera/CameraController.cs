using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public bool useOfSetValue;
    public float rotateSpeed;
    public Transform pivot;
    public float MaxAngle;
    public float MinAngle;
    public bool invertY;
    
    void Start()
    {
        if (!useOfSetValue)
        {
            offset = target.transform.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }


    void LateUpdate()
    {
        // lấy vị trí của x,y của chuột và xoay mục tiêu 

        float horizontal = Input.GetAxis("Mouse X");
        target. transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;




        if (invertY)
        {
            pivot.transform.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.transform.Rotate(-vertical, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > MaxAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + MinAngle)
        {
            pivot.rotation = Quaternion.Euler(360 + MinAngle, 0, 0);
        }

        //di chuyển máy ảnh dựa trên góc quay hien tại và góc độ lệch ban đầu (offset)
        float Yangle = target.transform.eulerAngles.y;
        float Xangle = pivot.transform.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(Xangle, Yangle, 0);

        transform.position = target.transform.position - (rotation * offset);

        //fix cam xuong dat
        if (transform.position.y < target.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target.transform);


    }

}
