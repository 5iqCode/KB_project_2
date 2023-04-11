using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public void LossMoney(float _totalCost) // уменьшение здоровья если вычитают деньги из зп
    {
        Debug.Log(_totalCost + "    " + _totalCost / 100);
        GetComponent<Slider>().value -= _totalCost / 100;
    }

    public IEnumerator DamageHpBecouseHangry(float _damageBecouseHangry)
    {
        while (true)
        {
            GetComponent<Slider>().value -= _damageBecouseHangry;
            yield return new WaitForSeconds(1);
        }
    }
}
