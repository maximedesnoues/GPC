using UnityEditor;
using UnityEngine;

public class CustomMenuItems
{
    [MenuItem("Blacked Out/Create Items Data")]
    public static void CreateItemsData()
    {
        CreateScriptableObject<ItemsData>("ItemsData", "Items");
    }

    [MenuItem("Blacked Out/Create Monster")]
    public static void CreateMonster()
    {
        CreateScriptableObject<Monster>("Monster", "Monster");
    }

    private static void CreateScriptableObject<T>(string fileName, string folderName) where T : ScriptableObject
    {
        // Créer une instance du ScriptableObject
        T newObject = ScriptableObject.CreateInstance<T>();

        // Crée le ScriptableObject en suivant le chemin spécifié
        string path = $"Assets/Scripts/ScriptableObjects/{folderName}";
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath($"{path}/{fileName}.asset");
        AssetDatabase.CreateAsset(newObject, assetPathAndName);
        AssetDatabase.SaveAssets();

        // Sélectionne le nouvel objet créé dans le projet
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newObject;
    }
}

public class ItemsData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int regenPts;
    public GameObject itemGO;
}

public class Monster : ScriptableObject
{
    public string monsterName;
    public int health;
    public int damage;
    public GameObject monsterPrefab;
}
