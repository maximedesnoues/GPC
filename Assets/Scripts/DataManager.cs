using UnityEditor;
using UnityEngine;

public class DataManager
{
    [MenuItem("Blacked Out/Create Item Data")]
    public static void CreateItemsData()
    {
        CreateScriptableObject<ItemsData>("ItemData", "Items");
    }

    [MenuItem("Blacked Out/Create Monster Data")]
    public static void CreateMonster()
    {
        CreateScriptableObject<MonstersData>("MonsterData", "Monsters");
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
