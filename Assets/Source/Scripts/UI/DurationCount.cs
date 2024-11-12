using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DurationCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText; 
    [SerializeField] private TextMeshProUGUI _bestText;
    [SerializeField] private FailWindowDuration _failWindowDuration;
    private float _distance; 
    private float _bestDistance;
    private Coroutine _gameTick;
    
    private const string BestDistanceKey = "BestDistance";
    private const string CurrentDistanceKey = "CurrentDistance";
    
    private void Awake() 
    { 
        _distance = 0f;
        
        if (PlayerPrefs.HasKey(BestDistanceKey))
            
            _bestDistance = PlayerPrefs.GetFloat(BestDistanceKey, 0f);
        else
            PlayerPrefs.SetFloat(BestDistanceKey, 0f); 
        
        UpdateCountText(); 
        UpdateBestText(); 
        
        _gameTick = StartCoroutine(GameTick());
    }
    
    private IEnumerator GameTick() 
    {
        while (true) { 
            _distance += Time.deltaTime * 10; 
            UpdateCountText(); 
            yield return null; 
        } 
    }

    private void UpdateCountText()
    {
        _countText.text = $"{_distance:0000}м";
    }

    private void UpdateBestText()
    {
        _bestText.text = $"Record: {_bestDistance:0000}м";
    }

    public void SaveBestDistance()
    {
        if (_distance > _bestDistance)
        {
            _bestDistance = _distance; 
            PlayerPrefs.SetFloat(BestDistanceKey, _bestDistance);
        } 
        
        PlayerPrefs.SetFloat(CurrentDistanceKey, _distance); 
        PlayerPrefs.Save(); 
    }

    public void Fail() 
    {
        if (_gameTick != null)
        {
            StopCoroutine(_gameTick);
        } 
        SaveBestDistance(); 
        
        _failWindowDuration.SetDuration(PlayerPrefs.GetFloat(CurrentDistanceKey));
        gameObject.SetActive(false);
    }

    public void Continue()
    {
        gameObject.SetActive(true);
        _distance = PlayerPrefs.GetFloat(CurrentDistanceKey, 0f);
        _bestDistance = PlayerPrefs.GetFloat(BestDistanceKey, 0f); 
        UpdateCountText();
        UpdateBestText();
        _gameTick = StartCoroutine(GameTick());
    } 
}
