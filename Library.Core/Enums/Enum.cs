using System.ComponentModel.DataAnnotations;

namespace Library.Core.Enums
{
    public enum BookLogTypes
    {
        [Display(Name = "On Loan")]
        OnLoan = 1,
        [Display(Name = "Returned")]
        Returned = 2,
    }
}
