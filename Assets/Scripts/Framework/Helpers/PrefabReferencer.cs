using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabReferencer : LocalSingleton<PrefabReferencer>
{
    [SerializeField] private PrefabGroup[] _prefabGroups;

    public GameObject GetRandomPrefab(string groupName)
    {
        for (int i = 0; i < _prefabGroups.Length; i++)
        {
            if(_prefabGroups[i].prefabGroupName.Equals(groupName))
            {
                return _prefabGroups[i].GetRandomPrefab();
            }
        }
        return null;
    }

    public GameObject GetPrefabByIndex(string groupName, int index)
    {
        for (int i = 0; i < _prefabGroups.Length; i++)
        {
            if (_prefabGroups[i].prefabGroupName.Equals(groupName))
            {
                return _prefabGroups[i].GetPrefabByIndex(index);
            }
        }
        Debug.LogWarning("no group found");
        return null;
    }
}

[System.Serializable]
public class PrefabGroup
{
    public string prefabGroupName;
    public GameObject[] prefabs;

    public GameObject GetRandomPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    public GameObject GetPrefabByIndex(int index)
    {
        if(index >= 0 && index < prefabs.Length)
        {
            return prefabs[index];
        }
        return null;
    }
}