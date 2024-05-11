namespace StarterProject;

//This is our Book Data Transfer Object, seperate from the entity
public record BookDTO(
        string Title,
        double Price,
        string Description,
        int Rank,
        string AmazonURL,
        string ImageURL
    );