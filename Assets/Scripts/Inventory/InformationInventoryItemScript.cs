using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationInventoryItemScript : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemHangry;
    [SerializeField] private TMP_Text _itemStress;
    [SerializeField] private TMP_Text _itemHP;

    public void ChangeInformationItem(Sprite _downladedSprite, string _downladedName, string _downladedHangry, string _downladedStress, string _downladedHp)
    {
        _itemImage.sprite = _downladedSprite;
        _itemName.text = _downladedName;
        _itemStress.text = _downladedStress;
        _itemHP.text = _downladedHp;
        _itemHangry.text = _downladedHangry;
    }
}
