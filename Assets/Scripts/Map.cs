using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tiles;
    public Tile switchTile;
    //public Sprite player;
    void Start(){
        
    }
    /*private Tile[,] tiles;
    public int width = 20;
    public int height = 10;
    public double tileWidth = 1.0;
    public double tileHeight = 1.0;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new Tile[width, height];
        for(int col = 0; col<tiles.GetLength(0); col++){
            for(int row = 0; row<tiles.GetLength(1); row++){
                double startX = 0.0-(width/2)*tileWidth+tileWidth/2;
                double startY = 0.0+(height/2)*tileHeight-tileHeight/2;
                double tileX = startX+col*tileWidth;
                double tileY = startY-row*tileHeight;
                tiles[col, row] = new Tile(tileX, tileY);
            }
        }
        https://answers.unity.com/questions/1546818/how-can-i-change-a-tile-color-in-unity-by-using-c.html
    }*/

    // Update is called once per frame
    void Update()
    {
        //Color colour = Color.red;//new Color(255.0f, 95.0f, 31.0f);
        Vector3Int position = new Vector3Int(0,0,0);//player.transform.position;
        //tiles.SetTileFlags(position, TileFlags.None);

        tiles.SetTile(position, switchTile);
        //tiles.SetColor(position, colour);
    }
}
