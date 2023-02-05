using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;

namespace Rki.CancerData.Clinical.TableConverter.App.Models;

/// <summary>
/// this cannot be seen
/// </summary>
public class ConverterObject
{

    /// <summary>
    /// Define con for server / db
    /// can be null for dbless connections
    /// </summary>
    public required SqlSupportDbConnection? DbConnection { get; init; }

    /// <summary>
    /// Define con for schema / tables
    /// </summary>
    public required SqlSupportTableConnection TableConnection { get; init; }

    public string SerializedContent { get; set; }
    public StructureSupport.SerializerType SourceType { get; set; }
    public StructureSupport.SerializerType TargetType { get; set; }

    // get full path, depending on src/target
    public string SourceFilePath => getFilePathInTemp(SourceType);

    /// <summary>
    /// Get target filepath
    /// </summary>
    /// <returns>full target file path</returns>
    public string TargetFilePath => getFilePathInTemp(TargetType);


    /// <summary>
    /// Gets the desired file in temp subfolder. 
    /// </summary>
    /// <param name="fileType">temp subfolder name</param>
    /// <returns>temp subfolder file</returns>
    private string getFilePathInTemp(StructureSupport.SerializerType fileType) =>
        Path.Combine(GetFolderPathInTemp(fileType)
            , TableConnection.FileNameWithSchemaPrefix)
            + $".{fileType}";


    /// <summary>
    /// Gets the temp subfolder csv|json|sql corresponding to filetype
    /// </summary>
    /// <param name="fileType">temp subfolder name</param>
    /// <returns>temp subfolder path</returns>
    public static string GetFolderPathInTemp(StructureSupport.SerializerType fileType) =>
        Path.Combine(Environment.CurrentDirectory
            , Globals.PATHSUFFIX_FILESDIR
            , fileType.ToString()
        );
}
