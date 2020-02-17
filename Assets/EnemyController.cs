using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const string horizontalAxisName = "Horizontal";
    private const string verticalAxisName = "Vertical";

    [SerializeField]
    private float movementScale = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(movementScale * Input.GetAxis(horizontalAxisName), 0, movementScale * Input.GetAxis(verticalAxisName));
        FindOpponent ();
        
        ///GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void FindOpponent () {
        //GameObject.FindGameObjectWithTag("Player").transform.position;
        var myPosition = transform.position;
        var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector3.MoveTowards(myPosition, PlayerPosition, movementScale);
                // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, PlayerPosition) < 0.001f)
        {
            // Swap the position of the cylinder.
            PlayerPosition *= -1.0f;
        }


    }


    
}