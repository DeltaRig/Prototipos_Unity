using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ProceduralWorldGeneration : MonoBehaviour
{
    public CameraController cameraController;
    public GameObject groundTexture;
    public GameObject spineTexture;
    public GameObject goldTexture;
    public GameObject potionTexture;


    private Vector2 _initialGroundPosition;
    private Vector2 _groundTextureSize;
    private float _groundTextureHalfSize => _groundTextureSize.x / 2;

    // Start is called before the first frame update
    void Start()
    {
        _groundTextureSize = groundTexture.GetComponent<Renderer>().bounds.size;
        _initialGroundPosition = new Vector2(-(cameraController.CameraViewSize.x / 4), -7);
        
        int blockHeight = 0;
        float offsetY = 0;

        for (int i = 0; i < Math.Ceiling(cameraController.CameraViewSize.x / _groundTextureSize.x) + 1000; i++)
        {
            Instantiate(groundTexture, new Vector3(_initialGroundPosition.x + i * _groundTextureHalfSize, _initialGroundPosition.y, 0), Quaternion.identity);

            if (i < 30)
                continue;

            int elevationChangeChance = Random.Range(0, 1000);
            if (elevationChangeChance < 250)
            {
                blockHeight++;
                offsetY += _groundTextureHalfSize;

                Instantiate(groundTexture, new Vector3(_initialGroundPosition.x + i * _groundTextureHalfSize, _initialGroundPosition.y + offsetY, 0), Quaternion.identity);
            }
            else if (blockHeight > 0 && elevationChangeChance < 500)
            {
                blockHeight--;
                offsetY -= _groundTextureHalfSize;

                Instantiate(groundTexture, new Vector3(_initialGroundPosition.x + i * _groundTextureHalfSize, _initialGroundPosition.y + offsetY, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(groundTexture, new Vector3(_initialGroundPosition.x + i * _groundTextureHalfSize, _initialGroundPosition.y + offsetY, 0), Quaternion.identity);
            }

            bool spawnedSpine = false;

            if (Random.Range(0, 1000) < 50)
            {
                Spawn(spineTexture, i, offsetY, false);
                spawnedSpine = true;
            }

            if (Random.Range(0, 1000) < 150)
            {
                Spawn(goldTexture, i, offsetY + (Random.Range(0, 1000) < 350 ? _groundTextureHalfSize : 0), spawnedSpine);
            }
            else if (Random.Range(0, 1000) < 10)
            {
                Spawn(potionTexture, i, offsetY, spawnedSpine);
            }
        }

        void Spawn(GameObject obj, int blockIndex, float offsetY, bool spawnedSpine)
        {
            Instantiate(obj,
                new Vector3(_initialGroundPosition.x + blockIndex * _groundTextureHalfSize, _initialGroundPosition.y + _groundTextureHalfSize + (spawnedSpine ? _groundTextureHalfSize : 0) + offsetY, 0),
                Quaternion.identity);
        }
    }
}
