namespace StarterProject;

public class BookDTOConverter
{
    private ModelMapper _modelMapper;
    
    public BookDTO convertBookToBookDTO(Book book)
    {
        return book;
    }

    public Book convertBookDTOToBook(BookDTO bookDTO)
    {
        return bookDTO;
    }
}