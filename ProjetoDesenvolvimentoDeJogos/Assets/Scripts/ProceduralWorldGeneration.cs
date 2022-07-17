using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProceduralWorldGeneration : MonoBehaviour
{
    public CameraController cameraController;
    public GameObject groundTexture;

    private Vector2 _initialGroundPosition;
    private Vector2 _groundTextureSize;

    // Start is called before the first frame update
    void Start()
    {
        _groundTextureSize = groundTexture.GetComponent<Renderer>().bounds.size;
        _initialGroundPosition = new Vector2(-(cameraController.CameraViewSize.x / 4), -7);
        
        for (int i = 0; i < Math.Ceiling(cameraController.CameraViewSize.x / _groundTextureSize.x) + 1; i++)
        {
            Instantiate(groundTexture, new Vector3(_initialGroundPosition.x + i * (_groundTextureSize.x / 2), _initialGroundPosition.y, 0), Quaternion.identity);
        }
    }

}
