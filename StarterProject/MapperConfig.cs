using System.Security.Cryptography.X509Certificates;

namespace StarterProject;

public class MapperConfig
{
    public ModelMapper _modelMapper()
    {
        return new ModelMapper();
    }
}