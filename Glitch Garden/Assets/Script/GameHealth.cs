using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHealth : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject fullheart;
    [SerializeField] GameObject halfheart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer[] hearts = GetComponentsInChildren<SpriteRenderer>();
        hearts[count].sprite = halfheart.GetComponent<SpriteRenderer>().sprite;
        count++;
        if (count >= hearts.Length)
        {
            FindObjectOfType<LevelController>().LoadLevelLost();
        }
    }




}
