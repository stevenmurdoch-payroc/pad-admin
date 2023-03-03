using caledon_pad_admin_tests.Drivers;

namespace caledon_pad_admin_tests.Helpers;

public class PathHelper
{
    public static string GetBasePath()
    {
        return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    }
}
