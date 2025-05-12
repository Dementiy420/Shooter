using Assets.Scripts;
using UnityEngine;
using System.Collections.Generic;

public class SectionPlace : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Section[] SectionPrefabs;
    [SerializeField] Section FirstSection;
    

    private List<Section> _spawnedSections = new();
    void Start()
    {
        _spawnedSections.Add(FirstSection);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y > _spawnedSections[_spawnedSections.Count - 1].End.position.y - 5)
            SpawnChunkY();
        if (Player.position.x > _spawnedSections[_spawnedSections.Count - 1].EndX.position.x - 5)
            SpawnChunkX();
        DestroyChunks();
        
    }

    void SpawnChunkY() 
    {
        Section newSection = Instantiate(SectionPrefabs[Random.Range(0, SectionPrefabs.Length)]);
        newSection.transform.position = _spawnedSections[_spawnedSections.Count - 1].End.position - newSection.Begin.localPosition;
        _spawnedSections.Add(newSection);
    }

    void SpawnChunkX() 
    {
        Section newSection = Instantiate(SectionPrefabs[Random.Range(0, SectionPrefabs.Length)]);
        newSection.transform.position = _spawnedSections[_spawnedSections.Count - 1].EndX.position - newSection.BeginX.localPosition;
        _spawnedSections.Add(newSection);
    }

    void DestroyChunks() 
    {
        if (_spawnedSections.Count >= 6)
        {
            Destroy(_spawnedSections[0].gameObject);
            _spawnedSections.RemoveAt(0);
        }
    }
}