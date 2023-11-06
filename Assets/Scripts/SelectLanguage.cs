using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLanguage : MonoBehaviour
{
    private List<GameObject> _langButtons = new List<GameObject>();
    [SerializeField] private Sprite _greenButton;
    [SerializeField] private Sprite _blueButton;
    public static event Action OnLangSelect;
    private GameObject _selectedButton;
    
    public void SelectLang(GameObject button)
    {
        ChangeButtonSprite(button);
        OnLangSelect?.Invoke();//при подписке из дургого скрипта можно будет изменять язык в игре
    }
    
    public void SetLangButtons(List<GameObject> buttons)
    {
        _langButtons = buttons;
        _selectedButton = buttons[0];
        ChangeButtonSprite(_selectedButton);
        SubscribeOnClick();
    }

    private void SubscribeOnClick()
    {
        foreach (var button in _langButtons)
        {
            Button buttonComponent = button.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => SelectLang(button));
            }
        }
    }

    private void ChangeButtonSprite(GameObject newButton)
    {
        if (newButton != _selectedButton)
        {
            _selectedButton.GetComponent<Image>().sprite = _blueButton;
            newButton.GetComponent<Image>().sprite = _greenButton;

            _selectedButton = newButton;
        }
        else
        {
            _selectedButton.GetComponent<Image>().sprite = _greenButton;
        }
    }
}
