using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    ItemUpgrade,
    PassiveUpgrade
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public int UpgradeCode;
    public string Explain;
    public Sprite icon;
}
