using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Note 
{
    [Key]  
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public DateTime DateCreated { get; set; }
    [ForeignKey("UserId")] 
    public User User { get; set; }
    public int UserId { get; set; }
}