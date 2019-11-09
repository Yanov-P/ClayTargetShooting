using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    private int _displayed = 8;
    [SerializeField]
    private Text number1;
    [SerializeField]
    private Text number2;

    private void Start()
    {
        for (int i = 0; i < _displayed; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DisplayAmmo(int ammo)
    {
        Debug.Log("ammo " + ammo);
        if (ammo < 0)
        {
            number1.text = "∞";
            number2.text = "∞";
        }
        else
        {
            number1.text = (ammo / 10).ToString();
            number2.text = (ammo % 10).ToString();
        }
    }

    public void DisplayAmmoInMagazine(int amount)
    {
        if(amount > _displayed)
        {
            for (int i = _displayed; i < amount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = amount; i < _displayed; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        _displayed = amount;
    }
}
