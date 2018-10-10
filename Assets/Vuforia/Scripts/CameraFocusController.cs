using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{
	void Start ()
	{
		var vuforia = VuforiaARController.Instance;
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
		vuforia.RegisterOnPauseCallback(OnPaused);
	}

	void OnVuforiaStarted ()
	{
		CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	void OnPaused ( bool paused )
	{
		if (!paused) // resumed
		{
			CameraDevice.Instance.SetFocusMode(
			   CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		}
	}
}