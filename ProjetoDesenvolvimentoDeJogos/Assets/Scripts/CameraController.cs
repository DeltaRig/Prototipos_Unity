using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offset = 10f;
    public Vector2 CameraViewSize => new Vector2(_camera.aspect * 4f * _camera.orthographicSize, 4f * _camera.orthographicSize); // height, width

    private Camera _camera;
    private Transform _playerTransform;
    
    void Awake()
    {
        _camera = GetComponent<Camera>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    //called after update and fixedUpdate
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        var position = _playerTransform.position;

        temp.x = position.x + offset;
        temp.y = position.y + 4;

        transform.position = temp;
    }
}
