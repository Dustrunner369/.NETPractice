namespace StarterProject;

public class BookDTOConverter
{
    private ModelMapper _modelMapper;
    
    public BookDTO convertBookToBookDTO(Book book)
    {
        BookDTO bookDTO = _modelMapper.map(book, BookDTO.class);
        
        return bookDTO;
    }
    public Book convertBookDTOToBook(BookDTO bookDTO)
    {
        Book book = _modelMapper.map(bookDTO, Book.class);
        return book;
    }
}