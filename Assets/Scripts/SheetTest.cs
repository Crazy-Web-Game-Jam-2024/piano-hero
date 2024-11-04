using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SheetTest : MonoBehaviour
{
    [SerializeField] TextAsset noteDict;
    [SerializeField] Dictionary<string, AudioClip> noteAudios;
    [SerializeField] TextAsset tab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<string> notes;
    [SerializeField] List<AudioClip> clips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noteAudios = new Dictionary<string, AudioClip>();
        var notes = JsonConvert.DeserializeObject<Dictionary<string, float>>(noteDict.text);
        foreach (var note in notes)
        {
            string path = $"{note.Key}";
            noteAudios[note.Key] = Resources.Load<AudioClip>(path);
        }
        var tabNotes = tab.text.Split().ToList();
        StartCoroutine(PlayTab(tabNotes));
    }

    IEnumerator PlayTab(List<string> tabNotes)
    {
        AudioClip.
        for (int i = 0; i < tabNotes.Count; i++)
        {
            audioSource.clip = noteAudios[tabNotes[i]];
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}


