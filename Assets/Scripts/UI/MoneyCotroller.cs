using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCotroller : MonoBehaviour
{
    [SerializeField] private TMP_Text _futureSellary; // будующая зарплата
    [SerializeField] private float _maxCost; // максимальная стоимость

    private HPController _hpController;
    public void BrokeBox()
    {
        float _futureSellaryF = float.Parse(_futureSellary.text);
        float _costOneItem = Random.Range(65, _maxCost);
        float _countDamageItems;
        if (_costOneItem > 1000)
        {
            _countDamageItems = Random.Range(1, 7);
        }
        else if(_costOneItem > 250)
        {
            _countDamageItems = Random.Range(1, 13);
        }
        else
        {
            _countDamageItems = Random.Range(1, 25);
        }
        float _totalCost = _costOneItem * _countDamageItems;

        _hpController = GameObject.Find("HpSlider").GetComponent<HPController>();

        _hpController.LossMoney(_totalCost); // взамодействие с очками жизни

        _futureSellary.text = System.Math.Round((_futureSellaryF - _totalCost), 2).ToString();
    }
}
