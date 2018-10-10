//using ini pada dasarnya buat kasi tahu kita pakainya library apa aja. Advanced tips : buat optimize kurangi jumlah using sebisa mungkin, pakai yg perlu2 aja

using System.Collections; //library .NET yg dipakai buat menjalankan berberapa fungsi koleksinya. disini kita pakai buat IEnumerator
using System.Collections.Generic; //library .NET yg dipakai kalau mau pakai fungsi2 generic. disini kita perlu buat pakai List<Sprite> . Note : sebenarnya ini List<T> yg dimana T bisa dipakai buat type apapun
using UnityEngine; //library yg diperlukan klo mau pakai Unity API. contoh Unity API: MonoBehaviour, Start, Update, OnEnable, OnDisable, OnCollisionEnter, OnTriggerEnter, dan lain-lain.

//Ini using using ga perlu terlalu dipikirkan, cuma perlu dipakai pada waktu perlu aja. 
//seiring waktu berjalan coding pakai unity juga nanti hapal sendiri

public class PNGSequencePlayer : MonoBehaviour //MonoBehaviour wajib diakai kalau mau dipasang sebagai component, klo bisa hindari paaki Monobehaviour. pakai Class biasa lebih hemat performance. Hints: pelajari Object Oriented Programming
{
	public SpriteRenderer spriteRenderer; //Di Unity buat memakai sprite selain UI, kita pakainya SpriteRenderer
	public float FPS = 60; //Buat perhitungan FPS
	public List<Sprite> PNGSequnces; //

	//OnEnable selalu dipanggil otomatis setiap kali GameObject baru Active (pas baru tercipta GameObjectnya ataupun pas waktu GameObjectnya baru diaktifkan lagi)
	//Note lain Buat OnEnable, cuma jalan klo classnya turunan MonoBehaviour
	void OnEnable ()
	{
		SequenceStart(); //Kita panggil fungsi kita buat menjalankan Coroutine kita
	}

	//Fungsi buat jalanin coroutine(IEnumerator) kita
	void SequenceStart ()
	{
		StartCoroutine(SequenceCoroutine()); //Untuk menjalankan Coroutine(IEnumerator), kita perlu pakai StartCoroutine()
	}

	//Coroutine dari PNG sequnce player kita
	//Alasan kita pakai coroutine karena kita bisa mengatur dia jalanin berapa lama sekali 
	//Contohnya disini kita pakai buat jalanin FPS
	IEnumerator SequenceCoroutine () 
	{
		int i = 0; //Kita bikin variable buat menunjukkan index kita sedang di list PNG sequnce yg mana
		while(true) //Disini kita barbarin aja ya, dibikin loop yg selalu berjalan sehingga funsi yg didalam while loop ini selalu berjalan
		{
			spriteRenderer.sprite = PNGSequnces[i]; //Buat memasang 
			i = (i >= PNGSequnces.Count - 1) ? 0 : i+1; //Buat ngecek apakah index kita sudah melebihi jumlah PNG sequence kita
			yield return new WaitForSeconds(1f/FPS); //Ini buat menunggu berapa lama ini while dilananin sekali. note lainnya, buat IEnumerator wajib memakai yield return
		}
	}
}