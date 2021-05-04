using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeReturn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        CameraFollowNew.inst.offset.x = -5;
        CameraFollowNew.inst.offset.y = 3;
    }
}
