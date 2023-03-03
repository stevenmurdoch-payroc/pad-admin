using System.Runtime.Serialization;
using System.Text.Json;
using caledon_pad_admin_tests.Drivers;

namespace caledon_pad_admin_tests.Helpers;

public class DataFileHelper
{
    private readonly ConfigurationDriver _configurationDriver;
    public DataFileHelper(ConfigurationDriver configurationDriver)
    {
        _configurationDriver = configurationDriver;
    }

    public string DataDirPath()
    {
        return Path.Combine(PathHelper.GetBasePath(), _configurationDriver.Configuration.GetSection("DataFile")["Path"]);
    }

    public string DataFilePath(string filename)
    {
        return Path.Combine(DataDirPath(), filename);
    }

    public async Task<T> Load<T>(string dataFilename)
    {
        var path = DataFilePath(dataFilename);
        return JsonSerializer.Deserialize<T>(await File.ReadAllTextAsync(path)) ??
               throw new SerializationException("Could not deserialize file - " + path);
    }
}
