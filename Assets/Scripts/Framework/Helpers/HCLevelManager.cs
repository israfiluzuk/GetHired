using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCLevelManager : GenericSingleton<HCLevelManager>
{
    [SerializeField] private GameObject[] _levelPrefabs;
    [SerializeField] private int _levelIndex = 0;
    [SerializeField] private bool _forceLevel = false;

    private int _globalLevelIndex = 0;
    private GameObject _currentLevel;

    public void Init()
    {
        //PlayerPrefs.DeleteAll();
        _globalLevelIndex = PlayerPrefs.GetInt("HCLevel");
        if (_forceLevel)
        {
            return;
        }
        _levelIndex = _globalLevelIndex;
        if (_levelIndex >= _levelPrefabs.Length)
        {
            _levelIndex = GameUtility.RandomIntExcept(_levelPrefabs.Length, _levelIndex);
        }
    }
    public void GenerateCurrentLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
        }
        _currentLevel = Instantiate(_levelPrefabs[_levelIndex]);
    }

    public GameObject GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void LevelUp()
    {
        _globalLevelIndex++;
        PlayerPrefs.SetInt("HCLevel", _globalLevelIndex);
        _levelIndex = _globalLevelIndex;
        if (_levelIndex >= _levelPrefabs.Length)
        {
            _levelIndex = GameUtility.RandomIntExcept(_levelPrefabs.Length, _levelIndex);
        }
        
    }
    public int GetGlobalLevelIndex()
    {
        return _globalLevelIndex;
    }
}
