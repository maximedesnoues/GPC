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
        // Cr�er une instance du ScriptableObject
        T newObject = ScriptableObject.CreateInstance<T>();

        // Cr�e le ScriptableObject en suivant le chemin sp�cifi�
        string path = $"Assets/Scripts/ScriptableObjects/{folderName}";
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath($"{path}/{fileName}.asset");
        AssetDatabase.CreateAsset(newObject, assetPathAndName);
        AssetDatabase.SaveAssets();

        // S�lectionne le nouvel objet cr�� dans le projet
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newObject;
    }
}
