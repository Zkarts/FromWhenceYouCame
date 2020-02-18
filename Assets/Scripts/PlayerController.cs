using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string horizontalAxisName = "Horizontal";
    private const string verticalAxisName = "Vertical";

    [SerializeField]
    private float movementScale = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementScale * Input.GetAxis(horizontalAxisName), 0, movementScale * Input.GetAxis(verticalAxisName));
    }
}