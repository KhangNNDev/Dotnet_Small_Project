public interface IGenericRepository <L,D,A,U>
{
    public int Add (A entity);
    public int Update(U entity);
    public int Delete (int id);
    public List<L> ViewAll();
    public D ViewDetail(int id);
}