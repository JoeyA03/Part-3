using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public Villager[] villagers;
    public float Min = 0.5f;
    public float Max = 2f;
    float interpolation;

    public static Villager SelectedVillager { get; private set; }

    public static void SetSelectedVillager(Villager villager)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }
    private void Awake()
    {
        Instance = this;
    }

    public void DropdownMenu (TMP_Dropdown dropdown)
    {
        SetSelectedVillager(villagers[dropdown.value]);
    }

    public void DropdownSelectionHasChanged(Int32 value)
    {
        
    }

    public void OnSliderValueChanged(float value)
    {
        float newScale = Mathf.Clamp(0.5f, 2f, value);
        SelectedVillager.transform.localScale = Vector3.one * newScale;
        interpolation = value;
    }

}
