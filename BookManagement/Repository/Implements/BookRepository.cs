
public class BookRepository : IGenericRepository<BookListingDTO, BookDetailDTO, BookAddDTO, BookUpdateDTO>
{
    public int Add(BookAddDTO entity)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Update(BookUpdateDTO entity)
    {
        throw new NotImplementedException();
    }

    public List<BookListingDTO> ViewAll()
    {
        throw new NotImplementedException();
    }

    public BookDetailDTO ViewDetail(int id)
    {
        throw new NotImplementedException();
    }
}