using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Points : MonoBehaviour
{
    public List<GameObject> treeList;
    public List<GameObject> deadTrees;
    public int ffPoints;
    public int arsPoints;
    // Start is called before the first frame update
    void Start()
    {
        GameObject trees = GameObject.Find("Trees");
        treeList = new List<GameObject>();
        for(int i = 0; i < trees.transform.childCount; i++)
        {
            treeList.Add(trees.transform.GetChild(i).gameObject);
        }
        
        arsPoints= 0;   
    }

// Update is called once per frame
void Update()
    {
        ffPoints = treeList.Count * 100;
        arsPoints = deadTrees.Count * 100;
        foreach (GameObject tree in treeList)
        {
            if (tree.GetComponentInChildren<Fuel>().burnedOut)
            {
                treeList.Remove(tree);
                deadTrees.Add(tree);
            }
        }
    }
}
