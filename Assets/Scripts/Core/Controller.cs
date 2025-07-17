using UnityEngine;
using TMPro;
using BreakInfinity;


namespace MyProject.Core
{
	public class Controller : MonoBehaviour
	{
		public static Controller instance;

		private void Awake()
		{
			instance = this;
		}

		public Data data;
		[SerializeField] private TMP_Text flasksText;
		[SerializeField] private TMP_Text flasksPowerText;

		public BigDouble ClickPower()
		{
			BigDouble total = 1;
			for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
			{
				total += UpgradesManager.instance.clickUpgradeBasePower[i] * data.clickUpgradeLevel[i];
			}

			return total;
		}

		private void Start()
		{
			data = new Data();

			UpgradesManager.instance.StartUpgradeManager();
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