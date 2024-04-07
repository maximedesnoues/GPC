using UnityEngine;

public class Items : MonoBehaviour
{
    public ItemsData itemsData;

    private void Start()
    {
        // Si itemsData n'est pas vide, on va charger les items basé sur les infos qu'on a
        if (itemsData != null)
        {
            LoadItems(itemsData);
        }
    }

    private void LoadItems(ItemsData _data)
    {
        // Supprime tous les child de l'empty s'il y en a 
        foreach (Transform child in transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        // Charge et configure le visuel des items
        GameObject visual = Instantiate(itemsData.itemGO);
        visual.transform.SetParent(transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.rotation = Quaternion.identity;
    }
}