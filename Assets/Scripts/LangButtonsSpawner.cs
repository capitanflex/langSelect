using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LangButtonsSpawner : MonoBehaviour
{
    [SerializeField] private SelectLanguage selectLanguage;
    [SerializeField] private List<string> languages;
    [SerializeField] private Transform buttonsHolder;
    [SerializeField] private GameObject buttonPrefab;


    void Start()
    {
        List<GameObject> langButtons = new List<GameObject>();
        foreach (var lang in languages)
        {
            GameObject newLangButton = Instantiate(buttonPrefab, buttonsHolder, false);
            newLangButton.GetComponentInChildren<TextMeshProUGUI>().text = lang;
            langButtons.Add(newLangButton);
        }
        selectLanguage.SetLangButtons(langButtons);
    }

}
