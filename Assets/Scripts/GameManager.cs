using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;

    // On creee une variable publique Instance pour pouvoir acceder a la variable privee _Instance
    public static GameManager Instance
    {
        get
        {
            return _Instance;
        }
    }

    // On creee le patern singleton
    // Permettant d'acceder a un script a partir d'un autre script
    private void Awake()
    {
        // Si l'instance n'a pas ete attribue
        if (_Instance == null)
        {
            _Instance = this;   // La variable _Instance = la classe GameManager
        }
        // Sinon
        else
        {
            Destroy(this);      // On la detruit si y'en a trop (car un singleton doit etre unique)
        }
    }


    [Header("Caracteristiques du joueur")]
    public int life;                        
    public int coins;

}
