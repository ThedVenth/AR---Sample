using UnityEngine;

public class AudioPlayer : MonoBehaviour 
{
	public AudioClip helloClip;//suara yg mau dimainkan
	public AudioSource audioSource;//component AudioSourcenya GameObject

	void OnMouseDown () //ini cuma bisa dijalankan klo classnya turunan MonoBehaviour
	{
		audioSource.PlayOneShot(helloClip);//kita memainkan suaranya sekali
	}
}