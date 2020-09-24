using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Subscrube to events like this
        ServiceLocator.Current.Get<ScoreManager>().OnScoreAdded += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        // This is only called every time there is score added
        scoreText.text = ServiceLocator.Current.Get<ScoreManager>().Score.ToString();
    }

    // Every object that subscribes to an event needs to unsubscribe
    // Easiest way is to call this from OnDestroy
    private void OnDestroy()
    {
        ServiceLocator.Current.Get<ScoreManager>().OnScoreAdded -= UpdateUI;
    }
}
