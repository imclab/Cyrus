using UnityEngine;
using System.Collections;

public class SpectrumParser : MonoBehaviour {
	public float mul = 1;

	void OnOscMessage(object[] msg)
	{
		string addr = msg[0] as string;

		if (addr != "/spectrum")
			return;

		float[] spectrum = new float[(msg.Length-3)/2];
		for(int i = 0; i<spectrum.Length; i++)
			spectrum[i] = mul * (float)msg[3+2*i];
		BroadcastMessage("OnAudioSpectrum", spectrum, SendMessageOptions.DontRequireReceiver);
	}
}
