using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) { 
        CameraFollowNew.inst.offset.x = -9.38f;
        CameraFollowNew.inst.offset.y = 5.45f;

    }
}
