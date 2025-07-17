using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyProject.Core
{
    public class Upgrades : MonoBehaviour
    {
        public int UpgradeId;
        public Image UpgradeButton;
        public TMP_Text LevelText;
        public TMP_Text NameText;
        public TMP_Text CostText;

        public void BuyClickUpgrade()
        {
            UpgradesManager.instance.BuyUpgrade(UpgradeId);
        }
    }
}
