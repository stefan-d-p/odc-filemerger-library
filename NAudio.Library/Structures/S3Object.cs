using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.NAudio.Structures;

[OSStructure(Description = "Single S3 Object")]
public struct S3Object
{
    [OSStructureField(Description = "Bucket",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Bucket;
    
    [OSStructureField(Description = "Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
}