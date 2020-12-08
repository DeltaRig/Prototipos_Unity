using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private GameObject wall;
    private GameObject door;

    private void Awake()
    {
        wall = GameObject.Find("Wall");
        door = GameObject.Find("Door");
    }

    // Start is called before the first frame update
    void Start()
    {
        mapBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void mapBuilder()
    {
        int height = 6, width = 10;
        float size = 1.62f;
        float xStart = -8.1f, yStart = 4.17f;
        float xFinal = (width * size) + xStart;
        float yFinalLine1 = -((height-1) * size) + yStart;
        float yFinalLine2 = -(height * size) + yStart;
        for (int y = 0; y <= height; y++)
        {
            
            Instantiate(wall, new Vector3(xStart, -(y * size) + yStart, 0), Quaternion.identity); // coluna da direita
            Instantiate(wall, new Vector3(xFinal, -(y * size) + yStart, 0), Quaternion.identity); // coluna da direita
        }
        for (int x = 1; x <= width; x++)
        {
            if (x == 5)
                Instantiate(door, new Vector3((x * size) + xStart, yStart, 0), Quaternion.identity); // porta
            else
                Instantiate(wall, new Vector3((x * size) + xStart, yStart, 0), Quaternion.identity); // linha de cima


            Instantiate(wall, new Vector3((x * size) + xStart, yFinalLine1, 0), Quaternion.identity); // linha de baixo
            Instantiate(wall, new Vector3((x * size) + xStart, yFinalLine2, 0), Quaternion.identity); // linha de baixo
        }
    }

}
