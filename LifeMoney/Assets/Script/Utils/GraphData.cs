using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphData
{
	public readonly int[] ArgList = { 20, 23, 16, 1, 13, 3 };
	//�ăh��,�p�|���h,���[��,�J�i�_�h��,�X�C�X�t����,�I�[�X�g�����A�h��
	//USD/JPY GBP/JPY   EUR/JPY CAD/JPY     CHF/JPY       AUD/JPY
	public float[] exDatasHigh;
	public float[] exDatasOpen;

	public float[][] data_trans;

	public GraphData()
	{
		exDatasHigh = new float[6];
		exDatasOpen = new float[6];
		data_trans = new float[6][];
	}
	public void SetPrice()
	{

	}
	public void UpdatePrice()
	{

	}
}