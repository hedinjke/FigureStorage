using System.ComponentModel.DataAnnotations;

namespace FigureStorage.Models
{
    public class Figure
    {
        [Key]
        public int Id { get; set; }
        public virtual double Area { get; }
        
        public virtual bool IsValid { get; }

    }
}