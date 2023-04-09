using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tiles;
    public Tile switchTile;
    private Sprite player;
    //public Sprite player;
    void Start(){
        //originTile = Instantiate(tiles.GetTile(new Vector3Int(0,0,0)));
        //original = Instantiate(tiles);
    }
    // Update is called once per frame
    void Update()
    {
        //Color colour = Color.red;//new Color(255.0f, 95.0f, 31.0f);
        
        Vector3Int position = Vector3Int.FloorToInt(GameObject.Find("Player").transform.position);
        //tiles.SetTileFlags(position, TileFlags.None);

        tiles.SetTile(position, switchTile);
        //tiles.SetColor(position, colour);
    }

}
