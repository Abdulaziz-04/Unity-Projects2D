using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed=0.2f;
    Material spacebg;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        //get the material i.e. spacbg
        spacebg = GetComponent<Renderer>().material;
        //set the new vector value and keep on adding on updates
        offset = new Vector2(0, scrollSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        spacebg.mainTextureOffset += offset * Time.deltaTime;
        
    }
}
