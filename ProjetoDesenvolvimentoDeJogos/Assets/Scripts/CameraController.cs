using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offset;
    public Vector2 CameraViewSize => new Vector2(_camera.aspect * 4f * _camera.orthographicSize, 4f * _camera.orthographicSize); // heigh, width

    private Camera _camera;
    private Transform playerTransform;
    
    void Awake()
    {
        _camera = GetComponent<Camera>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){

    }

    //called after update and fixedUpdate
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        //temp.x += offset;

        transform.position = temp;
    }

    
}
