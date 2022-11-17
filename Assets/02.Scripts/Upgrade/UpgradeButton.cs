using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI explainText;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        text.text = upgradeData.Name;
        explainText.text = upgradeData.Explain;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
