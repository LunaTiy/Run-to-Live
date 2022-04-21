using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageFillAmount : MonoBehaviour
{
    [SerializeField] private Image _fillImage;

	public void SetImageFill(float time, float maxTime)
	{
		_fillImage.fillAmount = time / maxTime;
	}
}
