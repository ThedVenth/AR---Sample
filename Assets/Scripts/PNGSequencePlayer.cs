//WARNING : ingat di C# semua kodingannya case sensitive. artinya huruf besar huruf kecil ngaruh
//using ini pada dasarnya buat kasi tahu kita pakainya library apa aja. library adalah kumpulan2 fungsi yg sudah diencapsulate sehingga kita tinggal pakai aja. Advanced tips : buat optimize kurangi jumlah using sebisa mungkin, pakai yg perlu2 aja

using System.Collections; //library .NET yg dipakai buat menjalankan berberapa fungsi koleksinya. disini kita pakai buat IEnumerator
using System.Collections.Generic; //library .NET yg dipakai kalau mau pakai fungsi2 generic. disini kita perlu buat pakai List<Sprite> . Note : sebenarnya ini List<T> yg dimana T bisa dipakai buat type apapun
using UnityEngine; //library yg diperlukan klo mau pakai Unity API. contoh Unity API: MonoBehaviour, Start, Update, OnEnable, OnDisable, OnCollisionEnter, OnTriggerEnter, dan lain-lain.

//Ini using using ga perlu terlalu dipikirkan, cuma perlu dipakai pada waktu perlu aja. klo misalnya mau panggil fungsi yg biasa dipakai tapi ga ga jalan fungsinya, salah satu tipsnya adalah cek using apakah sudah pakai library yg diperlukan
//ini betul2 ga perlu terlalu dipusingkan. seiring waktu berjalan coding pakai unity juga nanti hapal sendiri perlu using apa

public class PNGSequencePlayer : MonoBehaviour //MonoBehaviour wajib diakai kalau mau dipasang sebagai component, klo bisa hindari pakai Monobehaviour klo ga perlu dijadiin component. pakai Class biasa lebih hemat performance. Hints: pelajari Object Oriented Programming
{
	public SpriteRenderer spriteRenderer; //Di Unity buat memakai sprite selain UI, kita pakainya SpriteRenderer
	public float FPS = 60; //Buat perhitungan FPS
	public List<Sprite> PNGSequnces; //kumpulan dari PNG sequence animasi yang mau kita gerakin
	//disini variabenya kita pakai public biar bisa ditampilin di inspectornya unity editor. alternativenya klo ga mau pakai public bisa pakai [ShowInInspector] biar bisa ditampilin di inspector unity editor

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
		while(true) //Disini kita barbarin aja ya, dibikin loop yg selalu berjalan sehingga funsi yg didalam while loop ini selalu berjalan. hints : pelajari basic loops
		{
			spriteRenderer.sprite = PNGSequnces[i]; //Buat memasang Sprite ke sprite renderer. klo dilihat kita ada pakai kurung bracket([]) disini. itu dipakai buat kita kasi tahu pakai   Hints pelajari array

			if( i >= PNGSequnces.Count - 1 ) //Buat ngecek apakah index kita sudah melebihi jumlah PNG sequence kita
				i = 0; //klo indexnya sudah lewat dari jumlah PNG sequence kita, indexnya kembali ke 0
			else //else akan berjalan klo kondisi di if ga masuk
				i = i + 1; //klo masih belum lewat indexnta nambah 1. alternativenya bisa pakai i += 1 ataupun i++. perlu diingat klo cara kerja matematika di codingan dan matematika tradisional agak beda. klo di kodingan matematikanya berurutan dimulai dari kurung
			//if else dan else if biasa kana kamu temui pakai kurung kurawal ({}) untuk menjalankan fungsi2nya. tapi contoh diatas kita bisa ga pakai kurung kurawal karena fungsinya cuma 1 line. ingat jumlah line suatu fungsi dihitung berdasarkan titik koma(;)

			//alternativenya if else di atasnya bisa pakai satu line dibawah ini. diuncomment biar bisa dipakai ( tapi jangan lupa dicomment if else di atas)
			//i = (i >= PNGSequnces.Count - 1) ? 0 : i+1; //operasi ? bisa dipakai untuk mengantikan if

			yield return new WaitForSeconds(1f/FPS); //Ini buat menunggu berapa lama ini while dilananin sekali. note lainnya, buat IEnumerator wajib memakai yield return
		}
	}
}
//Note : penjalasan komen2 diatas klo ga ngerti, sebenarnya bisa diskip sedikit2 dulu. yang penting klo mau bikin yg sejenisnya lagi bisa dulu (ga ngerti apa yg sebenarnya terjadi gpp dulu) dan dengan banyak praktek seiring waktu bisa ngerti sendiri
