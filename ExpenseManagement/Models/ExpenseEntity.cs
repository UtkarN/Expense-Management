using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Models
{
    public class ExpenseEntity
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required(ErrorMessage ="Please Select Expense Date")]
        [DataType(DataType.Date)]
        [Display(Name ="Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Required(ErrorMessage ="please Enter expense Given to details")]
        [MinLength(3,ErrorMessage ="the name of Expense given to is Too Short")]
        [Display(Name = "Paid To ")]
        public string ExpenseGivenTo { get; set; }

        [Required(ErrorMessage = "Please Enter expense Amount")]
        [Range(0,double.MaxValue ,ErrorMessage = "Please Select Expense Date")]
        [Display(Name = "Expense amount ")]
        public Double ExpenseAmount { get; set; }

        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategoryEntity? ExpenseCategory { get; set; } 
      
    }
}
