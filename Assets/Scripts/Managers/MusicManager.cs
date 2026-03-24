using UnityEngine;

namespace Managers
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioClip mainMenuMusic;
        [SerializeField] private AudioClip gameMusic;
        [SerializeField] private AudioClip gameOverMusic;

        [SerializeField] private AudioSource audioSource;

        public void PlayMainMenuMusic()
        {
            PlayMusic(mainMenuMusic);

        }

        public void PlayGameMusic() {
            PlayMusic(gameMusic);

        }

        public void PlayGameOverMusic()
        {
            PlayMusic(gameOverMusic);


        }

        private void PlayMusic(AudioClip musicClip) {
            audioSource.Stop();
            audioSource.clip=musicClip;
            audioSource.Play();


        }
    }
}
