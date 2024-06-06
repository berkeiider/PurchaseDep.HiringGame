using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        // Singleton yapısı oluştur
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu nesnenin sahneler arasında yok olmamasını sağlar
        }
        else
        {
            Destroy(gameObject); // Zaten bir instance varsa, yenisini yok et
        }
    }

    // Ses çalma fonksiyonu
    public void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
}
