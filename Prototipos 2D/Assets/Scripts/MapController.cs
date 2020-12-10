using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public Texture2D[] mapas = new Texture2D[1];

    public GameObject wall;
    public GameObject door;
    public GameObject spine;

    /**
    [SerializeField]
    private Color32[] colorsMap;
    [SerializeField]
    private GameObject[] objsMap;
    */

    public GameObject walls;

    private void Awake()
    {
        //wall = GameObject.Find("Wall");
        //door = GameObject.Find("Door");
        mapBuilder(mapas[0]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void mapBuilder(Texture2D mapa)
    {
        Color32[] pix = mapa.GetPixels32();

        int worldX = mapa.width;
        int worldY = mapa.height;

        Vector3[] spawnPositions = new Vector3[pix.Length];
        Vector3 startingSpawnPosition = new Vector3(-Mathf.Round(worldX/ 2), -Mathf.Round(worldY / 2), 0);
        Vector3 currentSpawnPos = startingSpawnPosition;

        int counter = 0;

        for(int y = 0; y < worldY; y++)
        {
            for(int x = 0; x < worldX; x++)
            {
                spawnPositions[counter] = currentSpawnPos;
                counter++;
                currentSpawnPos.x += wall.GetComponent<SpriteRenderer>().bounds.extents.x * 2;
            }

            currentSpawnPos.x = startingSpawnPosition.x;
            currentSpawnPos.y += wall.GetComponent<SpriteRenderer>().bounds.extents.y * 2;
        }

        counter = 0;

        foreach(Vector3 pos in spawnPositions)
        {
            Color32 c = pix[counter];

            if (c.Equals(new Color32(0, 0, 0, 255)))
            {
                var wallInst = Instantiate(wall, pos, Quaternion.identity);
               // wallInst.transform.parent = walls.transform;
            } else if (c.Equals(new Color32(255, 255, 255, 255))) 
            { //white
                var doorInst = Instantiate(door, pos, Quaternion.identity);
            } else if (c.Equals(new Color32( 0, 0, 255, 255)))
            {
                var spineInst = Instantiate(spine, pos, Quaternion.identity);
            }
           

            counter++;
        }

        /**
        foreach (Vector3 pos in spawnPositions)
        {
            Color32 c = pix[counter];

            for(int i = 0; i < objsMap.Length; i++)
            {
                if (c.Equals(colorsMap[i]))
                {
                    var objInst = Instantiate(objsMap[i], pos, Quaternion.identity);
                    objInst.transform.parent = objs.transform;
                }
            }
        }*/
    }

    private void mapBuilder()
    {
        int height = 6, width = 10;
        float size = 1.62f;
        float xStart = -8.1f, yStart = 4.17f;
        float xFinal = (width * size) + xStart;
        float yFinalLine1 = -((height - 1) * size) + yStart;
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
