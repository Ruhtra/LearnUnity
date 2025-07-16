using UnityEngine;
using TMPro;

namespace MyProject.Core
{
	public class Controller : MonoBehaviour
	{
		public Data data;
		[SerializeField] private TMP_Text flasksText;

		private void Start()
		{
			data = new Data();
		}

		private void Update()
		{
			flasksText.text = data.flasks + " flasks";
		}

		public void GenerateFlasks()
		{
			data.flasks++;
		}
	}
}