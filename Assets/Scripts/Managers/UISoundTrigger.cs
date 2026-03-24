using UnityEngine;
using UnityEngine.EventSystems;
namespace Managers

{
    public class UISoundTrigger : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
    {
        private const string UI_SFX_AUDIO_SOURCE_TAG = "UI SFX Audio Source";

        [SerializeField] private AudioClip enterSfx;
        [SerializeField] private AudioClip clickSfx;

        private AudioSource _audioSource;

        private void Awake() {
            var audioGameObject = GameObject.FindWithTag(UI_SFX_AUDIO_SOURCE_TAG);

            if (audioGameObject == null)
            {
                Debug.LogError($"Audio Source with tag {UI_SFX_AUDIO_SOURCE_TAG} not found");
                enabled = false;
                return;
            }

            _audioSource = audioGameObject.GetComponent<AudioSource>();

            if (_audioSource != null) return;

            Debug.LogError($"{audioGameObject.name} does not have an audio source component");
            enabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData) => PlaySfx(enterSfx);
        public void OnPointerClick(PointerEventData eventData) => PlaySfx(clickSfx);

        public void OnSelect(BaseEventData eventData) => PlaySfx(clickSfx);
        public void OnSubmit(BaseEventData eventData) => PlaySfx(clickSfx);

        private void PlaySfx(AudioClip sfx) {
            if (_audioSource == null) return;

            _audioSource.PlayOneShot(sfx);
        }
    }
}

