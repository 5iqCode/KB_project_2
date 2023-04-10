using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazgruzkaController : MonoBehaviour // ��� �������� ������
{
    [SerializeField] private GameObject _blockPrebuf;// ���������� ����
    [SerializeField] private GameObject _blockFriglePrebuf; // �������� ����

    public int _countGrozs; // ����� �������� ������ ��� ���������
    private GameObject _takedBlock; // ������ ����
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
                Debug.Log("� ����� ����");
            }
        }
        else
        {
            Debug.Log("����� ���������");
        }
        }

    private void TakeBlockFromRazgr() //���������� ���� � �����
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
        Debug.Log("�������� " + _countGrozs);
    }
}
