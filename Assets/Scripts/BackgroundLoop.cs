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
        memory.backgroundSpeed = memory.backgroundSpeed - memory.score/10000000;
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, memory.backgroundSpeed * Time.deltaTime);
    }
}
