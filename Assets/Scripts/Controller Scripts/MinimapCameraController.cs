using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = PlayerManager.instance.player.transform.position + new Vector3(250.89f, 40f, 4f);
    }
}
