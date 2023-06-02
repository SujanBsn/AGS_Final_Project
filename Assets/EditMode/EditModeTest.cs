using UnityEngine;
using NUnit.Framework;

public class EditModeTest
{
    private const string plotDirectory = "Assets/Plots/";

    [Test]
    public void AudioClips_AssignedAndNotNull()
    {
        // Create a new game object and retrieve the AudioAnalyzer script from the Manager object
        GameObject managerObject = GameObject.Find("Manager");
        AudioSpectrumAnalyzer analyzer = managerObject.GetComponent<AudioSpectrumAnalyzer>();

        // Retrieve the audio clips from the AudioAnalyzer script
        AudioClip audioClip1 = analyzer.audioClip1;
        AudioClip audioClip2 = analyzer.audioClip2;

        // Assert that the audio clips are not null
        Assert.IsNotNull(audioClip1, "AudioClip1 is null");
        Assert.IsNotNull(audioClip2, "AudioClip2 is null");
    }

    [Test]
    public void AnalyzeAudioSpectrum_CompareGraphs_ReturnsExpectedSimilarity()
    {
        // Create a new game object and retrieve the AudioAnalyzer script from the Manager object
        GameObject managerObject = GameObject.Find("Manager");
        AudioSpectrumAnalyzer analyzer = managerObject.GetComponent<AudioSpectrumAnalyzer>();

        // Retrieve the audio clips from the AudioAnalyzer script
        AudioClip audioClip1 = analyzer.audioClip1;
        AudioClip audioClip2 = analyzer.audioClip2;

        // Call the AnalyzeAudioSpectrum method for both audio clips
        analyzer.AnalyzeAudioSpectrum(audioClip1, "SpectrumGraph1.png", analyzer.graphObject1);
        analyzer.AnalyzeAudioSpectrum(audioClip2, "SpectrumGraph2.png", analyzer.graphObject2);

        // Compare the graphs and get the similarity percentage
        float similarityPercentage = analyzer.CalculateSimilarity(plotDirectory + "SpectrumGraph1.png", plotDirectory + "SpectrumGraph2.png");

        // Define the expected similarity percentage (change this according to your test case)
        float expectedSimilarity = 1f;

        // Assert that the similarity percentage matches the expected value
        Assert.AreEqual(expectedSimilarity, similarityPercentage, .01f);
    }
}
