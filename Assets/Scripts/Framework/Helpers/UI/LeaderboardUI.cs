using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private int _instanceCount = 3;
    [SerializeField] private GameObject _instancePrefab;

    private LeaderboardInstanceUI[] _instances;

    private void Awake()
    {
        _instances = new LeaderboardInstanceUI[_instanceCount];
        for (int i = 0; i < _instanceCount; i++)
        {
            _instances[i] = Instantiate(_instancePrefab, transform).GetComponent<LeaderboardInstanceUI>();
        }
    }

    public void SetSiblingIndex(int siblingIndex)
    {
        _instances[siblingIndex].SetSiblingIndex(siblingIndex);
    }

    public void SetUnique(int index, bool unique)
    {
        _instances[index].SetUnique(unique);
    }
    
    public void SetIcon(int index, Sprite sprite)
    {
        _instances[index].SetIcon(sprite);
    }

    public void SetPoints(int index, int points)
    {
        _instances[index].SetPoints(points);
    }

    public int GetInstanceCount()
    {
        return _instanceCount;
    }


}
