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

	public List<List<float>> progress_data_trans;

	public readonly string[] UnitList = { "�~/��", "�~/��", "�~/?", "�~/��", "�~/?", "�~/��" };

	public GraphData()
	{
		exDatasHigh = new float[6];
		exDatasOpen = new float[6];
		progress_data_trans = new List<List<float>>();

		for(int i = 0; i < 6; i++)
		{
			progress_data_trans.Add(new List<float>());
		}
	}
	public void SetPrice()
	{

	}
	public void UpdatePrice()
	{

	}
}