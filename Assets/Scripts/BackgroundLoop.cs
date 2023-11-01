using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    public Renderer backgroundRenderer;

    public Memory memory;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (memory.fireRate <0.15)
            {
                if (memory.cameraSpeed > 8)
                {
                    backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
                }
                else
                {
                    memory.backgroundSpeed = memory.backgroundSpeed + memory.score/100000;
                    backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (memory.cameraSpeed > 8)
                {
                    backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
                }
                else
                {
                    memory.backgroundSpeed = memory.backgroundSpeed + memory.score/1500000;
                    backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
        }
    }
}
