using Physalia.Flexi.Samples.CardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PianoHero.PianoSystem
{
    public class PianoController : MonoBehaviour
    {
        public AudioSource audioSource;
        public float movementSpeed = 1f;
        public float songSegmentLength;
        public CardData cardData;
        public PianoController pianoController;
        public List<PianoNote> pianoRows;
        public bool lastNote;
        private Coroutine playSongSegmentCoroutine;
        [SerializeField] float outOfSceneTriggerY;
        [SerializeField] float spawnNewNoteTriggerY;
        [SerializeField] GameObject prefabNote;
        [SerializeField] Transform rootNote;
        [SerializeField] GameCompositionRoot _compositionRoot;
        private void Start()
        {
            SetupData();
        }
        public void SetupData()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var noteObject = Instantiate(prefabNote, rootNote);
                    (noteObject.transform as RectTransform).anchoredPosition = new Vector2();
                    var note = noteObject.GetComponent<PianoNote>();
                    note.controller = this;
                    note.Setup(GenerateCardData());
                }
            }
        }

        public CardData GenerateCardData()
        {
            return new CardData()
            {

            };
        }

        public void Update()
        {
            foreach (var note in pianoRows)
            {
                var pos = (note.transform as RectTransform).anchoredPosition;
                pos.y -= movementSpeed * Time.deltaTime;
                (note.transform as RectTransform).anchoredPosition = pos;
                if (pos.y <= spawnNewNoteTriggerY)
                {
                    ResetNote(note);
                }
            }


        }

        public void ResetNote(PianoNote note)
        {
            var pos = (note.transform as RectTransform).anchoredPosition;
            pos.y = spawnNewNoteTriggerY;
            (note.transform as RectTransform).anchoredPosition = pos;
            note.Setup(GenerateCardData());
        }

        public void OnClickPianoNoteSuccess(PianoNote note)
        {
            _compositionRoot.battleController.UseCard(note.cardData);
        }

        public void OnClickPianoNoteFail()
        {

        }

        public void PlaySomeOfSong()
        {
            if (!audioSource.isPlaying && !lastNote)
            {
                audioSource.Play();
            }
            if (audioSource.clip.length - audioSource.time <= songSegmentLength)
            {
                lastNote = true;
            }
            if (playSongSegmentCoroutine != null) StopCoroutine(playSongSegmentCoroutine);
            playSongSegmentCoroutine = StartCoroutine(PlaySomeOfSongCoroutine());
        }

        private IEnumerator PlaySomeOfSongCoroutine()
        {
            yield return new WaitForSeconds(songSegmentLength);
            audioSource.Pause();
            if (lastNote)
            {
                //PlayerWon = true;
                //StartCoroutine(EndGame());
            }
        }
    }

}