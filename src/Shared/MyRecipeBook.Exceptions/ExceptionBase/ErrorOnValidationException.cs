using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Exceptions.ExceptionBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    public IList<string> ErrorMessages { get; set; }  
    
    public ErrorOnValidationException(IList<string> erros)
    {
        ErrorMessages = erros;  
    }
}
