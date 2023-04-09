using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBox : MonoBehaviour //����������� ����
{
    private PlayerController _playerController;
    private MoneyCotroller _moneyCotroller;

    private void Awake()
    {
        _playerController = GameObject.Find("MainHero").GetComponent<PlayerController>();
        _moneyCotroller = GameObject.Find("MoneyController").GetComponent<MoneyCotroller>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_playerController._takedBlock == gameObject)
        {
            if ((Input.GetKey(KeyCode.LeftShift))&&(_playerController._direction!=Vector2.zero)&&(collision.CompareTag("Trigger")==false) && (collision.CompareTag("Player") == false)) //���� ����� ����� � ���������� � ����������� ���� ���������
            {
                DamageBlock(gameObject);
            }
        }
    }
    public void DamageBlock(GameObject _gameObject)
    {
        Debug.Log("������ ����");
        Destroy(_gameObject);
        _moneyCotroller.BrokeBox();
    }
}
