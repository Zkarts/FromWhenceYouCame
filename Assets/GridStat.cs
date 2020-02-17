using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;

    public float GridSize;

    void Start(){
        this.transform.position = new Vector3(x, y, 0);
        Debug.Log(x+"-"+y);
    }

    void Update(){
    }
}
