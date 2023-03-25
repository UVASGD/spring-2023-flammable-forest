using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] GameObject treeCollectionObject;
    Tree[] trees;

    public float firemanScore; //{ get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        trees = treeCollectionObject.GetComponentsInChildren<Tree>();
    }

    // Update is called once per frame
    void Update()
    {
        firemanScore = GetFiremanScore();
    }

    float GetFiremanScore() {
        int firemanScoringTrees = 0;
        foreach (Tree tree in trees){
            if (!tree.burning)
                firemanScoringTrees++;
        }
        return (float) firemanScoringTrees / trees.Length;

    }
}
