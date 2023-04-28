using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tiles;
    public Tile switchTile;
    public Tile lightTile;
    //public Tile lightestTile;
    [SerializeField] private GameObject player;
    //public Sprite player;
    void Start(){
    }
    // Update is called once per frame
    void Update()
    {
        //Color colour = Color.red;//new Color(255.0f, 95.0f, 31.0f);
        if(Input.GetKey("space")){
            Vector3Int position = Vector3Int.FloorToInt(player.transform.position);
            position = Vector3Int.Scale(position, new Vector3Int(2, 2, 2));

            for(int y = -3; y <= 3; y++){
                for(int x = -3; x <= 3; x++){
                    Vector3Int nPos = position + new Vector3Int(x, y, 0);
                    float distance = Vector3Int.Distance(position, nPos);
                    if(distance <= 3){
                        tiles.SetTile(nPos, lightTile);
                    }
                    /*if(distance <= 2){
                        tiles.SetTile(nPos, lightTile);
                    }*/
                    if(distance <= 1){
                        tiles.SetTile(nPos, switchTile);
                    }
                }
            }
            //tiles.SetTile(position, switchTile);
        }
    }

}
