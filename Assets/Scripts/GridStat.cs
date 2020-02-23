using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    public int visited = -1;
    public float x = 0;
    public float z = 0;

    void Start(){
        this.transform.position = new Vector3(x, 0, z);
        //Debug.Log(x+"-"+y);
    }

    void Update(){
        this.transform.position = new Vector3(x, 0, z);
    }
}
