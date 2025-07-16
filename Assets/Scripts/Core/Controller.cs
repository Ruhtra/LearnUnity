using UnityEngine;
using TMPro;
using BreakInfinity;

namespace MyProject.Core
{
	public class Controller : MonoBehaviour
	{
		public UpgradesManager upgradesManager;
		public Data data;
		[SerializeField] private TMP_Text flasksText;
		[SerializeField] private TMP_Text flasksPowerText;

		public BigDouble ClickPower()
		{
			return 1 + data.clickUpgradeLevel;
		}

		private void Start()
		{
			data = new Data();

			upgradesManager.StartUpgradeManager();
		}

		private void Update()
		{
			flasksText.text = data.flasks + " flasks";
			flasksPowerText.text = "+" + ClickPower() + " flasks";
		}

		public void GenerateFlasks()
		{
			data.flasks += ClickPower();
		}
	}
}