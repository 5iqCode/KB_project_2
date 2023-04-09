using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazgruzkaController : MonoBehaviour // для триггера машины
{
    [SerializeField] private GameObject _blockPrebuf;// небьющийся блок
    [SerializeField] private GameObject _blockFriglePrebuf; // бьющийся блок

    public int _countGrozs; // Всего доступно грузов для разгрузки
    private GameObject _takedBlock; // взятый блок
    private GameObject _mainHero; 

    private void Start()
    {
        _mainHero = GameObject.Find("MainHero");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        _takedBlock = _mainHero.GetComponent<KeyboardEvents>()._takedBlock;
        if (_countGrozs > 0)
        {
            if (_takedBlock == null)
            {
                TakeBlockFromRazgr();
            }
            else
            {
                Debug.Log("В руках блок");
            }
        }
        else
        {
            Debug.Log("Блоки кончились");
        }
        }

    private void TakeBlockFromRazgr() //заспавнить блок в руках
    {
        _countGrozs--;

        GameObject _tempBlock;

        if (Random.value > 0.5f)
        {
            _tempBlock = Instantiate(_blockFriglePrebuf, _mainHero.transform.position, Quaternion.identity, _mainHero.transform);
            _tempBlock.GetComponent<Box>()._isFarigile = true;
        }
        else
        {
            _tempBlock = Instantiate(_blockPrebuf, _mainHero.transform.position, Quaternion.identity, _mainHero.transform);
        }

        _mainHero.GetComponent<KeyboardEvents>()._takedBlock = _tempBlock;
        Debug.Log("Осталось " + _countGrozs);
    }
}
