using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public Transform lightSource; // Position de la source lumineuse
    public LineRenderer lineRenderer; //dessiner le faisceau lumineux
    public float maxLength = 10f; // Longueur maximale du faisceau lumineux

    void Update()
    {
        UpdateTorchLight();
    }

    void UpdateTorchLight()
    {
        lineRenderer.SetPosition(0, lightSource.position);

        // Cast un rayon vers le bas pour détecter les collisions avec les objets
        RaycastHit2D hit = Physics2D.Raycast(lightSource.position, Vector2.down);

        // Calculer la longueur du faisceau lumineux
        float length = maxLength;
        if (hit.collider != null)
        {
            length = hit.distance;
        }

        // Définir le point final du faisceau lumineux en fonction de la longueur calculée
        Vector3 endPosition = lightSource.position + Vector3.down * length;
        lineRenderer.SetPosition(1, endPosition);
    }
}