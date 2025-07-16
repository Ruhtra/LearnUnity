using BreakInfinity;
using UnityEngine;


namespace MyProject.Core
{
    public class UpgradesManager : MonoBehaviour
    {
        public Controller controller;

        public Upgrades clickUpgrade;

        public string clickUpgradeName;

        public BigDouble clickUpgradeBaseCos;
        public BigDouble clickUpgradeBaseMult;

        public void StartUpgradeManager()
        {
            clickUpgradeName = "Flasks Per Click";
            clickUpgradeBaseCos = 10;
            clickUpgradeBaseMult = 1.5;
            UpdateClickUpgradeUI();
        }

        public void UpdateClickUpgradeUI()
        { clickUpgrade.LevelText.text = controller.data.clickUpgradeLevel.ToString();
            clickUpgrade.CostText.text = "Cost: " + Cost().ToString("F2") + " Flasks";
            clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
        }

        public BigDouble Cost()
        {
            return clickUpgradeBaseCos * BigDouble.Pow(clickUpgradeBaseMult, controller.data.clickUpgradeLevel);
        }

        public void BuyUpgrade()
        {
            if (controller.data.flasks >= Cost())
            {
                controller.data.flasks -= Cost();
                controller.data.clickUpgradeLevel++;
            }

            
            UpdateClickUpgradeUI();
        }
    }
}
