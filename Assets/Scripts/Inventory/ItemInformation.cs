using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInformation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private GameObject _informationItem;
    private TMP_Text _name;

    private void Awake()
    {
        _informationItem = GameObject.Find("InformationInventoryHeroWindow");


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _informationItem.SetActive(true);
        item temp = Resources.Load<item>("Inventory/" + gameObject.name);
        Debug.Log(gameObject.name);
        _informationItem.GetComponent<InformationInventoryItemScript>().ChangeInformationItem(temp.Sprite, temp.Name, temp.HungryIfEat.ToString(), temp.StressIfEat.ToString(), temp.HpIfEat.ToString());


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _informationItem.SetActive(false);
    }
}
