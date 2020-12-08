using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    public abstract class Figure
    {
        [Key]
        public int Id { get; set; }

        [NotMapped] 
        public abstract string Type { get; }
        public virtual double Area { get; }
        public virtual bool IsValid { get; }
    }
}