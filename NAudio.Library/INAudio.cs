using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.NAudio
{
    [OSInterface(
        Name = "NAudio",
        Description = "Mp3 Merger",
        IconResourceName = "Without.Systems.NAudio.Resources.FileMerger.png")]
    public interface INAudio
    {

        [OSAction(
            Description = "Merges MP3 Files in a S3 Bucket",
            ReturnName = "result",
            ReturnDescription = "Merge Audio Response",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.NAudio.Resources.FileMerger.png")]
        Structures.MergeAudioResponse MergeAudio(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region System Name",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Merge Audio Request",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.MergeAudioRequest request);
    }
}