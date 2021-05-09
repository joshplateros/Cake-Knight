using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    bool onPlay = false;
    private void OnCollisionEnter(Collision collision) { 
        CameraFollowNew.inst.offset.x = -9.38f;
        CameraFollowNew.inst.offset.y = 5.45f;
        if (onPlay == false) {
            FindObjectOfType<AudioMgr>().PlayMob("Boss Growl");
            FindObjectOfType<AudioMgr>().StopBGM("Level3 BG Music");
            FindObjectOfType<AudioMgr>().PlayBGM("Final Boss Music");
            onPlay = true;
        }
        
    }
}
