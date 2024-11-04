using Physalia.Flexi.Samples.CardGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PianoHero.PianoSystem
{
    public class PianoNote : MonoBehaviour
    {
        public PianoController controller;
        [SerializeField] Image border;
        [SerializeField] Image icon;
        [SerializeField] TextMeshProUGUI skillNameLabel;

        public CardData cardData;
        public NoteStatus status;
        public void Setup(CardData cardData)
        {
            this.cardData = cardData;
        }

        public void OnClick()
        {

            if (status == NoteStatus.Active)
            {
                
            }
        }
    }

    public enum NoteStatus
    {
        Active,
        Used,
        Outofscreen
    }
}