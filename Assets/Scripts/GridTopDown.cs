using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridTopDown : MonoBehaviour
{
    private const string horizontalAxisName = "Horizontal";
    private const string verticalAxisName = "Vertical";

    public GameObject gridPrefab; // reference to the grid to move on

    [SerializeField]
    private float gridBlockWidth = 5;

    private Vector3 p1;
    private Vector3 p2;
	// set things up here
    private int columns; 
    private int rows; 


	void Awake () {
        int width;
        int height;
		// setup reference to game manager
        //GetComponent.<Collider>().bounds.size
        p1 = gameObject.transform.TransformPoint(0, 0, 0);
        p2 = gameObject.transform.TransformPoint(1, 0, 1);
        width = (int)(p2.x - p1.x);
        height = (int)(p2.y - p1.y);
        Debug.Log(p1+", "+p2);
        Debug.Log(width +" "+ height);
        columns = (int)(width/gridBlockWidth);
        rows = Mathf.Abs((int)(height/gridBlockWidth));
        Debug.Log(columns+" - "+rows);
        generateGrid();
	}


    // Update is called once per frame
    void Update()
    {
        
    }

    void generateGrid(){
        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){
                GameObject obj = Instantiate(gridPrefab, new Vector3(p1.x+gridBlockWidth*i, p1.y, p1.z+gridBlockWidth*i), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x = (int)(p1.x+i*gridBlockWidth);
                obj.GetComponent<GridStat>().y = (int)(p1.y+j*gridBlockWidth);
                obj.GetComponent<GridStat>().GridSize = gridBlockWidth;
                Debug.Log("Node created, "+i+" - "+j);
            }
        }
        Debug.Log("Grid created");
    }

}

/*

public List<Node> GetShortestPathDijkstra()
{
    DijkstraSearch();
    var shortestPath = new List<Node>();
    shortestPath.Add(End);
    BuildShortestPath(shortestPath, End);
    shortestPath.Reverse();
    return shortestPath;
}

private void BuildShortestPath(List<Node> list, Node node)
{
    if (node.NearestToStart == null)
        return;
    list.Add(node.NearestToStart);
    BuildShortestPath(list, node.NearestToStart);
}

private void DijkstraSearch()
{
    Start.MinCostToStart = 0;
    var prioQueue = new List<Node>();
    prioQueue.Add(Start);
    do {
        prioQueue = prioQueue.OrderBy(x => x.MinCostToStart).ToList();
        var node = prioQueue.First();
        prioQueue.Remove(node);
        foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
        {
            var childNode = cnn.ConnectedNode;
            if (childNode.Visited)
                continue;
            if (childNode.MinCostToStart == null ||
                node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
            {
                childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                childNode.NearestToStart = node;
                if (!prioQueue.Contains(childNode))
                    prioQueue.Add(childNode);
            }
        }
        node.Visited = true;
        if (node == End)
            return;
    } while (prioQueue.Any());
}
*/