using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffController : MonoBehaviour
{
    private Slider _fatigue;
    private int _hungerValue;
    private int _stressValue;

    private float _fatigueMaxValueGlobal;

    [SerializeField] private float _damageBecouseHangry;

    [SerializeField] private HPController _hPController;

    private Coroutine ActiveHangryDebafCor;

    private void Start()
    {
        _hPController = GameObject.Find("HpSlider").GetComponent<HPController>();
        _fatigueMaxValueGlobal = GameObject.Find("Main Camera").GetComponent<GlobalObjects>()._MaxFatigue;
        _fatigue = GameObject.Find("fatigue").GetComponent<Slider>();
    }

    public void ChangeMaxFatigue_hunger(int _hungerValue)
    {
        switch (_hungerValue)
        {
            case <=2:
                StopCorountineHangryDebafHp();
                _fatigue.maxValue = _fatigueMaxValueGlobal;
            break;
            case 3:
                StopCorountineHangryDebafHp();
                _fatigue.maxValue = _fatigueMaxValueGlobal * 0.8f;
                Debug.Log("Хочет есть");
            break;
            case <= 5:
                StopCorountineHangryDebafHp();
                _fatigue.maxValue = _fatigueMaxValueGlobal * 0.7f;
            Debug.Log("Хочет есть сильнее");
            break;
            case 6:
            _fatigue.maxValue = _fatigueMaxValueGlobal * 0.5f;
                ActiveHangryDebafCor = StartCoroutine(_hPController.DamageHpBecouseHangry(_damageBecouseHangry));
            break;
        }
    }

    private void StopCorountineHangryDebafHp()
    {
        if (ActiveHangryDebafCor != null)
        {
            StopCoroutine(ActiveHangryDebafCor);
            ActiveHangryDebafCor = null;
        }
    }
}
