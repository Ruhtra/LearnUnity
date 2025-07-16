using BreakInfinity;
using UnityEngine;


namespace MyProject.Core
{
    public class Upgradesmanager : MonoBehaviour
    {
        public Controller controller;
        public BigDouble clickUpgradeBaseCos;
        public BigDouble clickUpgradeBaseMult;

        public void Start()
        {
            clickUpgradeBaseCos = 10;
            clickUpgradeBaseMult = 1.5;
        }

        public BigDouble Cost()
        {
            return clickUpgradeBaseCos * BigDouble.Pow(clickUpgradeBaseMult, controller.data.clickUpgradeLevel);
        }
    }
}
