using RotaryHeart.Lib.SerializableDictionary;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Scriptable Objects/PrefabDatabase")]
public class PrefabDatabase : ScriptableObject
{
    public ImagePrefabDictionary Prefabs;
}

[Serializable]
public class ImagePrefabDictionary : SerializableDictionaryBase<string, GameObject> { }
