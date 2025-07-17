using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;
using UnityEngine.UI;


namespace MyProject.Core
{
    public class UpgradesManager : MonoBehaviour
    {
        public static UpgradesManager instance;
        private void Awake()
        {
            instance = this;

        }

        public List<Upgrades> clickUpgrades;
        public Upgrades clickUpgradePrefab;

        public ScrollRect clickUpgradesScroll;
        public GameObject clickUpgradesPanel;

        public string[] clickUpgradesNames;
        public BigDouble[] clickUpgradeBaseCost;
        public BigDouble[] clickUpgradeCostMult;
        public BigDouble[] clickUpgradeBasePower;

        public void StartUpgradeManager()
        {

            Methods.UpgradeCheck(Controller.instance.data.clickUpgradeLevel, 4);

            clickUpgradesNames = new[] { "CLick Power +1", "Click Power +5", "Click Power +10", "Click Power +250" };
            clickUpgradeBaseCost = new BigDouble[] { 10, 50, 100, 1000 };
            clickUpgradeCostMult = new BigDouble[] { 1.25, 1.35, 1.55, 2 };
            clickUpgradeBasePower = new BigDouble[] { 1, 5, 10, 25 };

            for (int i = 0; i < Controller.instance.data.clickUpgradeLevel.Count; i++)
            {
                Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel.transform);
                upgrade.UpgradeId = i;
                // upgrade.NameText.text = clickUpgradesNames[i];
                // upgrade.CostText.text = "Cost: " + clickUpgradeBaseCos[i].ToString("F2") + " Flasks";
                // upgrade.LevelText.text = Controller.instance.data.clickUpgradeLevel[i].ToString();


                clickUpgrades.Add(upgrade);
            }

            clickUpgradesScroll.normalizedPosition = Vector2.zero;

            UpdateClickUpgradeUI();

        }

        public void UpdateClickUpgradeUI(int UpgradeID = -1)
        {
            var data = Controller.instance.data;

            if (UpgradeID == -1)
            {
                for (int i = 0; i < clickUpgrades.Count; i++)
                {
                    clickUpgrades[i].LevelText.text = data.clickUpgradeLevel[i].ToString();
                    clickUpgrades[i].CostText.text = $"Cost: {ClickUpgradeCost(i):F2} Flasks";
                    clickUpgrades[i].NameText.text = clickUpgradesNames[i];
                }

            }
            else
            {
                clickUpgrades[UpgradeID].LevelText.text = data.clickUpgradeLevel[UpgradeID].ToString();
                clickUpgrades[UpgradeID].CostText.text = $"Cost: {ClickUpgradeCost(UpgradeID):F2} Flasks";
                clickUpgrades[UpgradeID].NameText.text = clickUpgradesNames[UpgradeID];
            }
        }

        public BigDouble ClickUpgradeCost(int UpgradedId)
        {
            return clickUpgradeBaseCost[UpgradedId] * BigDouble.Pow(clickUpgradeCostMult[UpgradedId], Controller.instance.data.clickUpgradeLevel[UpgradedId]);
        }

        public void BuyUpgrade(int UpgradedID)
        {
            var data = Controller.instance.data;
            if (data.flasks >= ClickUpgradeCost(UpgradedID))
            {
                data.flasks -= ClickUpgradeCost(UpgradedID);
                data.clickUpgradeLevel[UpgradedID]++;
            }


            UpdateClickUpgradeUI(UpgradedID);
        }
    }
}
