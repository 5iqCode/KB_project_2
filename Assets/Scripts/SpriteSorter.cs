using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    private int _sortingOrderBase = 0;
    private float _offsetDefault;
    [SerializeField] private float _offsetCor; //корректировка центра

    [SerializeField] private bool _isStatic;//если объект статичный, удаляется компонент

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _offsetDefault = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y - _offsetDefault - _offsetCor);



        if (_isStatic)
        {
            Destroy(this);
        }
    }
}
