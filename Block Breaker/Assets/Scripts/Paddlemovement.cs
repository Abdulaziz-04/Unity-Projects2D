using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlemovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float minX =1f;
    [SerializeField] float maxX =15f;
    [SerializeField] float widthUnits= 16f;
    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * widthUnits;
        Vector2 paddlePos = new Vector2(mousePos, 1f);
        paddlePos.x=  Mathf.Clamp(mousePos,minX, maxX);
        transform.position = paddlePos;
    }
}
