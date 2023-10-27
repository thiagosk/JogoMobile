using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Memory memory;

    // Update is called once per frame
    void Update()
    {
        memory.cameraSpeed = memory.cameraSpeed - memory.score/10000000;
        transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
    }
}
