using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
    public TMP_Text text;

    public void Update()
    {
        text.text = GetVillagerType();
    }
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }

    public static string GetVillagerType()
    {
        if (SelectedVillager is Archer)
        {
            return "Archer";
        }

        if (SelectedVillager is Merchant)
        {
            return "Merchant";
        }

        if (SelectedVillager is Thief)
        {
            return "Thief";
        }
        return "";
    }

    
}
