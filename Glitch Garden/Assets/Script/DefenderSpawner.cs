using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject defender;
    [SerializeField] AudioClip dropSFX;
    private void OnMouseDown()
    {
        SpawnDefender(GetPos());
    }
    public void SetDefender(GameObject selected)
    {
        defender = selected;
    }
    private Vector2 GetPos()
    {
        // taking input from mouse coords
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //rounding off the coords and return 
        Vector2 worldPos = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
        return worldPos;
    }
    private void SpawnDefender(Vector2 pos)
    {
        //spawn on clicked position 
        var available=FindObjectOfType<Resource>().UseSun(defender.GetComponent<Defender>().GetCost());
        if (available)
        {
            GameObject newDefender = Instantiate(defender, pos, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(dropSFX, Camera.main.transform.position, 0.5f);
        }

    }

}
