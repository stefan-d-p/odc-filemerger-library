using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.NAudio.Structures;

[OSStructure(Description = "Media Merge Response")]
public struct MergeAudioResponse
{
    [OSStructureField(Description = "S3 Bucket",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Bucket;
    
    [OSStructureField(Description = "S3 Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
}