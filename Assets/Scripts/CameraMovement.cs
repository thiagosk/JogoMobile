using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Memory memory;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (memory.fireRate < 0.15)
            {
                if (memory.cameraSpeed > 8)
                {
                    transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
                }
                else
                {
                    memory.cameraSpeed = memory.cameraSpeed + memory.score/100000;
                    transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
                }
            }
            else
            {
                if (memory.cameraSpeed > 8)
                {
                    transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
                }
                else 
                {
                    memory.cameraSpeed = memory.cameraSpeed + memory.score/1500000;
                    transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
                }
            }
        }
        else
        {
            transform.position += new Vector3(0, memory.cameraSpeed * Time.deltaTime, 0);
        }
    }
}
