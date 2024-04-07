using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{
    public ItemsData itemsData;

    // Lorsque le joueur rentre en collision avec la potion
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            // On recupere la vie du joueur et on regen sa vie par rapport a la potion 
            GameManager.Instance.life += itemsData.regenPts;
            // On limite la vie du joueur a 100
            GameManager.Instance.life = Mathf.Clamp(GameManager.Instance.life, 0, 100);
            Destroy(gameObject);
        }
    }
}
