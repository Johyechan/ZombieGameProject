using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/EquipmentData")]
public class EquipedUpgradeSO : ScriptableObject
{   
    public bool upgrade01 = false;
    public bool upgrade02 = false;
    public bool upgrade03 = false;
    public bool upgrade04 = false;
    public bool upgrade05 = false;
    public bool upgrade06 = false;
    public bool upgrade07 = false;
    public bool upgrade08 = false;
    public bool upgrade09 = false;
    public bool upgrade10 = false;
    public bool upgrade11 = false;
    public bool upgrade12 = false;
    public bool upgrade13 = false;
    public bool upgrade14 = false;

    public bool upgraded01 = false;
    public bool upgraded02 = false;
    public bool upgraded03 = false;
    public bool upgraded04 = false;
    public bool upgraded05 = false;
    public bool upgraded06 = false;
    public bool upgraded07 = false;
    public bool upgraded08 = false;
    public bool upgraded09 = false;
    public bool upgraded10 = false;
    public bool upgraded11 = false;
    public bool upgraded12 = false;
    public bool upgraded13 = false;
    public bool upgraded14 = false;



    public void OnAfterDeserialize()
    {
        upgrade01 = false;
        upgrade02 = false;
        upgrade03 = false;
        upgrade04 = false;
        upgrade05 = false;
        upgrade06 = false;
        upgrade07 = false;
        upgrade08 = false;
        upgrade09 = false;
        upgrade10 = false;
        upgrade11 = false;
        upgrade12 = false;
        upgrade13 = false;
        upgrade14 = false;
        upgraded01 = false;
        upgraded02 = false;
        upgraded03 = false;
        upgraded04 = false;
        upgraded05 = false;
        upgraded06 = false;
        upgraded07 = false;
        upgraded08 = false;
        upgraded09 = false;
        upgraded10 = false;
        upgraded11 = false;
        upgraded12 = false;
        upgraded13 = false;
        upgraded14 = false;
    }
}
