using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.NAudio.Structures;


[OSStructure(Description = "Merge Audio Request Structure")]
public struct MergeAudioRequest
{
    [OSStructureField(Description = "Input files",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<S3Object> InputFiles;
    
    [OSStructureField(Description = "Output S3 Bucket",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string OutputS3Bucket;
    
    [OSStructureField(Description = "Output S3 Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string OutputS3Key;
    
    [OSStructureField(Description = "Content Disposition",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string OutputS3ContentDisposition;
}