// See https://aka.ms/new-console-template for more information

using Antoine.Mortelier.FeatureMatching;
using System.Text.Json;

var objectImageData = await File.ReadAllBytesAsync(args[0]);

var imageScenesData = new List<byte[]>();
foreach (var imagePath in Directory.EnumerateFiles(args[1]))
{
    var imageBytes = await File.ReadAllBytesAsync(imagePath);
    imageScenesData.Add(imageBytes);
}

var detectObjectInScenesResults = new ObjectDetection().DetectObjectInScenes(objectImageData, imageScenesData);

foreach (var objectDetectionResult in detectObjectInScenesResults)
{
    System.Console.WriteLine($"Points: {JsonSerializer.Serialize(objectDetectionResult.Points)}");
}