using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextValue : MonoBehaviour
{
    [SerializeField] private Text _textTime;

	public void SetDivisionTime(float time, float maxTime)
	{
		_textTime.text = $"{time:F0} / {maxTime:F0}";
	}

	public void SetSoloTime(float time)
	{
		_textTime.text = $"Elapsed time: {time:F1}";
	}
}
