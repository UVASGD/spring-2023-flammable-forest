using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tiles;
    public Tile switchTile;
    public Tile lightTile;
    public int xOffset;
    public int yOffset; 
    public string keyType;
    [SerializeField] private GameObject player;
    private Vector3Int prevPosition;
    bool pressed = false;
    void Start(){
    }
    // Update is called once per frame
    void Update()
    {
        Vector3Int position = Vector3Int.FloorToInt(player.transform.position);
        position = Vector3Int.Scale(position, new Vector3Int(2, 2, 2));
        position = position + new Vector3Int(-xOffset, -yOffset, 0);
        if(Input.GetKey(keyType)){

            for(int y = -3; y <= 3; y++){
                for(int x = -3; x <= 3; x++){
                    if(prevPosition != null){
                        Vector3Int nPos = prevPosition + new Vector3Int(x, y, 0);
                        float distance = Vector3Int.Distance(prevPosition, nPos);
                        if(distance <= 1){
                            tiles.SetTile(nPos, lightTile);
                        }
                    }
                }
            }

            for(int y = -3; y <= 3; y++){
                for(int x = -3; x <= 3; x++){
                    Vector3Int nPos = position + new Vector3Int(x, y, 0);
                    float distance = Vector3Int.Distance(position, nPos);
                    if(distance <= 3){
                        tiles.SetTile(nPos, lightTile);
                    }
                    if(distance <= 1){
                        tiles.SetTile(nPos, switchTile);
                    }
                }
            }

            prevPosition = position;
            //tiles.SetTile(position, switchTile);
            pressed = true;
        }
        else if(pressed == true){
            pressed = true;

            for(int y = -3; y <= 3; y++){
                for(int x = -3; x <= 3; x++){
                    if(prevPosition != null){
                        Vector3Int nPos = prevPosition + new Vector3Int(x, y, 0);
                        float distance = Vector3Int.Distance(prevPosition, nPos);
                        if(distance <= 1){
                            tiles.SetTile(nPos, lightTile);
                        }
                    }
                }
            }
        }
    }

}
