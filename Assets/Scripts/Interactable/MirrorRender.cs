using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRender : MonoBehaviour
{
    public Camera mirrorCamera;
    public RenderTexture tex;

    private void Awake()
    {
        mirrorCamera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mirrorCamera.targetTexture = tex;   
    }
}
