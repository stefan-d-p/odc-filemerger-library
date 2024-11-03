using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Without.Systems.NAudio.Extensions;
using Without.Systems.NAudio.Structures;
using Without.Systems.NAudio.Util;

namespace Without.Systems.NAudio;

public class NAudio : INAudio
{
    public MergeAudioResponse MergeAudio(Structures.Credentials credentials, string region, Structures.MergeAudioRequest request)
    {
        var client = GetAwsS3Client(credentials, region);
        
        string tempFile = Path.GetTempFileName();
        using(var outputStream = File.Create(tempFile))
        {
            foreach (var input in request.InputFiles)
            {
                var s3Input = AsyncUtil.RunSync(() => client.GetObjectAsync(input.Bucket, input.Key));
                ParseResponse(s3Input);
                using var mp3Stream = s3Input.ResponseStream;
                mp3Stream.CopyTo(outputStream);
            }

            PutObjectRequest saveRequest = new PutObjectRequest
            {
                Key = request.OutputS3Key,
                BucketName = request.OutputS3Bucket,
                InputStream = outputStream
            };

            var saveResponse = AsyncUtil.RunSync(() => client.PutObjectAsync(saveRequest));
            ParseResponse(saveResponse);
        }

        return new MergeAudioResponse
        {
            Bucket = request.OutputS3Bucket,
            Key = request.OutputS3Key
        };
    }
    
    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
    
    private AmazonS3Client GetAwsS3Client(Structures.Credentials credentials, string region)
    {
        return new AmazonS3Client(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));
    }
}