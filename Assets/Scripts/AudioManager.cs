using UnityEngine;

public class AudioManager : MonoBehaviour
{
     AudioSource backgroundMusicSource;
     AudioSource coinCollectSource;
     AudioSource dashSoundSource;
     AudioSource timeIncreaseSoundSource;

    void Awake()
    {
        AudioSource[] allAudioSources = GetComponents<AudioSource>();
        backgroundMusicSource = allAudioSources[0];
        coinCollectSource = allAudioSources[1];
        dashSoundSource = allAudioSources[2];
        //timeIncreaseSoundSource = allAudioSources[3];
    }

    public void PlayBackgroundMusic() => backgroundMusicSource.Play();
    public void PlayCoinCollect() => coinCollectSource.Play();
    public void PlaySpeedBoostSound() => dashSoundSource.Play();
    //public void PlayTimeBoostSound() => dashSoundSource.Play();

}
