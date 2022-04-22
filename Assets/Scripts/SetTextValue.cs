using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetTextValue : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTime;

	public void SetDivisionTime(float time, float maxTime)
	{
		_textTime.text = $"{time:F0} / {maxTime:F0}";
	}

	public void SetSoloTime(float time)
	{
		_textTime.text = $"Your time\n{time:F1}";
	}
}
