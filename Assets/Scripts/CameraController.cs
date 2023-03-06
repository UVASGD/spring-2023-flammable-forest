using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    public GameObject target1, target2;
    public float minSize, maxSize;
    public float sideBufferProportion;
    public float moveSpeed, zoomSpeed;
    public float aspect;

    // Start is called before the first frame update
    void Start()
    {
        //var instantiation
        cam = GetComponent<Camera>();
        aspect = cam.aspect;

        //move to center
        Vector3 fromT1toT2 = target2.transform.position - target1.transform.position;
        Vector3 centerPos = target1.transform.position + fromT1toT2 / 2;
        transform.position = centerPos + new Vector3(0, 0, -10);

        //set first zoom
        cam.orthographicSize = Mathf.Max(Mathf.Abs(fromT1toT2.x / aspect), Mathf.Abs(fromT1toT2.y)) * sideBufferProportion;

    }

    // Update is called once per frame
    void Update()
    {
        //compute center
        Vector3 fromT1toT2 = target2.transform.position - target1.transform.position;
        Vector3 centerPos = target1.transform.position + fromT1toT2 / 2;
        
        //move to center (faster the further away you are)
        transform.position += moveSpeed * (centerPos - transform.position);
        putCamAtCorrectZ();

        //find desired size
        float desiredSize;
        if (Mathf.Abs(fromT1toT2.x/aspect) < Mathf.Abs(fromT1toT2.y))
        {
            desiredSize = fromT1toT2.y * sideBufferProportion;
        } else
        {
            desiredSize = fromT1toT2.x / aspect * sideBufferProportion;
        }
        desiredSize = Mathf.Abs(desiredSize);
        //check bounds
        if (desiredSize < minSize) desiredSize = minSize;
        if (desiredSize > maxSize) desiredSize = maxSize;
        //increase/decrease the size to the desired size (faster the further away it is)
        cam.orthographicSize += zoomSpeed * (desiredSize - cam.orthographicSize);
    }


    private void putCamAtCorrectZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
