using Microsoft.Extensions.Configuration;
using Without.Systems.NAudio.Structures;

namespace Without.Systems.NAudio.Test;

public class Tests
{
    private static readonly INAudio _actions = new NAudio();
    private Credentials _credentials;
    private readonly string _region = "eu-central-1";

    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        string awsAccessKey = configuration["AWSAccessKey"] ?? throw new InvalidOperationException();
        string awsSecretAccessKey = configuration["AWSSecretAccessKey"] ?? throw new InvalidOperationException();

        _credentials = new Credentials(awsAccessKey, awsSecretAccessKey);
    }

    [Test]
    public void Echo_Returns_Successful()
    {

        List<S3Object> files = new List<S3Object>();
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/1.mp3"
        });
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/2.mp3"
        });
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/3.mp3"
        });
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/4.mp3"
        });
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/5.mp3"
        });
        files.Add(new S3Object
        {
            Bucket = "odc-tbs-storage",
            Key = "podcaster/dc5592fc-52d1-4525-a260-0a3a6f757f98/6.mp3"
        });
 
        MergeAudioRequest request = new MergeAudioRequest
        {
            OutputS3Bucket = "osdemostore",
            OutputS3Key = "podcast-final.mp3",
            InputFiles = files
        };

        var response = _actions.MergeAudio(_credentials, _region, request);
    }
}