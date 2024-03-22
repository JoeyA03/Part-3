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

}
