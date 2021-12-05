using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounDary : MonoBehaviour
{
    public static float LeftSide =-4.4f;
    public static float RightSide =4.4f;
    public float InternalLeft;
    public float InternalRight;
    void Update()
    {
        InternalLeft = LeftSide;
        InternalRight = RightSide;
    }
}
