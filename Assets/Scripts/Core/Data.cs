using UnityEngine;
using BreakInfinity;
using System.Collections.Generic;

namespace MyProject.Core
{
    public class Data
    {
        public BigDouble flasks;

        public List<BigDouble> clickUpgradeLevel;

        public Data()
        {
            flasks = 0;
            clickUpgradeLevel = Methods.CreateList<BigDouble>(4);
        }
    }

}
