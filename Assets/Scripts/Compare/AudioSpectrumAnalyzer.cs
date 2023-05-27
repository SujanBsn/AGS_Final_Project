using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AudioSpectrumAnalyzer : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public int sampleSize = 1024;
    public int graphWidth = 1024;
    public int graphHeight = 512;
    public float amplitudeMultiplier = 10f;
    public string folderName = "Plots";
    public GameObject graphObject1;
    public GameObject graphObject2;
    public Text similarityText;

    private Texture2D graphTexture1;
    private Texture2D graphTexture2;

    void Start()
    {
        // Empty out the Plots folder before generating the graphs
        EmptyPlotsFolder();

        graphTexture1 = new Texture2D(graphWidth, graphHeight, TextureFormat.RGBA32, false);
        graphTexture1.wrapMode = TextureWrapMode.Clamp;

        graphTexture2 = new Texture2D(graphWidth, graphHeight, TextureFormat.RGBA32, false);
        graphTexture2.wrapMode = TextureWrapMode.Clamp;

        AnalyzeAudioSpectrum(audioClip1, "SpectrumGraph1.png", graphObject1);
        AnalyzeAudioSpectrum(audioClip2, "SpectrumGraph2.png", graphObject2);

        // Compare the two generated graphs for similarity
        CompareGraphs("SpectrumGraph1.png", "SpectrumGraph2.png");
    }

    void EmptyPlotsFolder()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        if (Directory.Exists(folderPath))
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            directory.Delete(true);
        }

        Directory.CreateDirectory(folderPath);
    }

    void AnalyzeAudioSpectrum(AudioClip clip, string fileName, GameObject graphObject)
    {
        float[] spectrumData = new float[sampleSize];
        int totalSamples = clip.samples;
        int samplesPerStep = totalSamples / graphWidth;

        Color[] graphPixels = new Color[graphWidth * graphHeight];
        for (int i = 0; i < graphWidth; i++)
        {
            int startIndex = i * samplesPerStep;
            clip.GetData(spectrumData, startIndex);

            float averageAmplitude = 0f;
            for (int j = 0; j < sampleSize; j++)
            {
                averageAmplitude += Mathf.Abs(spectrumData[j]);
            }
            averageAmplitude /= sampleSize;

            float height = averageAmplitude * graphHeight * amplitudeMultiplier;

            for (int j = 0; j < graphHeight; j++)
            {
                if (j < height)
                {
                    int pixelIndex = GetPixelIndex(i, j);
                    graphPixels[pixelIndex] = Color.white;
                }
                else
                {
                    int pixelIndex = GetPixelIndex(i, j);
                    graphPixels[pixelIndex] = Color.black;
                }
            }
        }

        Texture2D graphTexture = (fileName == "SpectrumGraph1.png") ? graphTexture1 : graphTexture2;
        graphTexture.SetPixels(graphPixels);
        graphTexture.Apply();

        byte[] pngBytes = graphTexture.EncodeToPNG();

        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        string filePath = Path.Combine(folderPath, fileName);

        File.WriteAllBytes(filePath, pngBytes);

        Debug.Log("Spectrum graph saved: " + filePath);

        // Load the saved PNG file as a sprite
        Sprite sprite = LoadSpriteFromFilePath(filePath);

        // Assign the sprite to the game object's SpriteRenderer component
        SpriteRenderer spriteRenderer = graphObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
    }

    int GetPixelIndex(int x, int y)
    {
        return x + y * graphWidth;
    }

    Sprite LoadSpriteFromFilePath(string filePath)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }

    void CompareGraphs(string file1, string file2)
    {
        string filePath1 = Path.Combine(Application.persistentDataPath, folderName, file1);
        string filePath2 = Path.Combine(Application.persistentDataPath, folderName, file2);

        // Calculate similarity between the two graphs
        float similarity = CalculateSimilarity(filePath1, filePath2);

        // Calculate similarity percentage
        float similarityPercentage = similarity * 100f;

        Debug.Log("Similarity percentage: " + similarityPercentage + "%");

        // Update the similarity text on UI
        similarityText.text = "Similarity: " + similarityPercentage.ToString("F2") + "%";
    }

    float CalculateSimilarity(string filePath1, string filePath2)
    {
        Texture2D texture1 = LoadTextureFromFile(filePath1);
        Texture2D texture2 = LoadTextureFromFile(filePath2);

        if (texture1 == null || texture2 == null)
        {
            Debug.LogError("Failed to load textures for similarity calculation.");
            return 0f;
        }

        int matchingPixels = 0;
        int totalPixels = texture1.width * texture1.height;

        for (int x = 0; x < texture1.width; x++)
        {
            for (int y = 0; y < texture1.height; y++)
            {
                Color color1 = texture1.GetPixel(x, y);
                Color color2 = texture2.GetPixel(x, y);

                if (color1.Equals(color2))
                {
                    matchingPixels++;
                }
            }
        }

        return (float)matchingPixels / totalPixels;
    }

    Texture2D LoadTextureFromFile(string filePath)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return texture;
    }
}
