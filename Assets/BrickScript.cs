using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    
    private Vector3 p1;//centerParent
    public int BrickSize;

    
    public GameObject gridPrefab; // reference to the grid to move on
    // Start is called before the first frame update
    void Start()
    {
        p1 = gameObject.transform.TransformPoint(0, 0, 0);

        GameObject obj = Instantiate(gridPrefab, new Vector3(p1.x+(BrickSize), p1.y, p1.z+(BrickSize)), Quaternion.identity);
        obj.transform.SetParent(gameObject.transform);
        obj.GetComponent<GridStat>().x = (p1.x-(BrickSize/2));
        obj.GetComponent<GridStat>().z = (p1.y-(BrickSize));

        GameObject obj2 = Instantiate(gridPrefab, new Vector3(p1.x+(BrickSize*1), p1.y, 20+(BrickSize*1)), Quaternion.identity);
        obj2.transform.SetParent(gameObject.transform);
        obj2.GetComponent<GridStat>().x = (p1.x-(BrickSize*1/2));
        obj2.GetComponent<GridStat>().z = (p1.y-(BrickSize*1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
